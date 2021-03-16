using System;

namespace WpfPong
{
    public class PongLogic
    {
        private PongModel model;

        public enum Direction { Left, Right};
        public event EventHandler RefreshScreen;

        public PongLogic(PongModel model)
        {
            this.model = model;
        }

        public void MovePad(Direction direction)
        {
            switch(direction)
            {
                case Direction.Left:
                    model.Pad.ChangeX(-10);
                    break;
                case Direction.Right:
                    model.Pad.ChangeX(10);
                    break;
            }

            RefreshScreen?.Invoke(this, EventArgs.Empty);
        }

        public void JumpPad(double x)
        {
            model.Pad.SetXY(x, model.Pad.Area.Y);
            RefreshScreen?.Invoke(this, EventArgs.Empty);
        }
        
        private bool MoveShape(MyShape shape)
        {
            bool isFaulted = false;

            shape.ChangeX(shape.Dx);
            shape.ChangeY(shape.Dy);

            if(shape.Area.Left < 0 || shape.Area.Right > Config.Width)
            {
                shape.Dx = -shape.Dx;
            }

            if(shape.Area.Top < 0 || shape.Area.IntersectsWith(model.Pad.Area))
            {
                shape.Dy = -shape.Dy;
            }

            if(shape.Area.Bottom > Config.Height)
            {
                isFaulted = true;
                shape.SetXY(shape.Area.X, Config.Height / 2);
            }

            return isFaulted;
        }

        public void MoveBall()
        {
            if(MoveShape(model.Ball))
            {
                model.Errors++;
            }
            RefreshScreen?.Invoke(this, EventArgs.Empty);
        }
    }
}
