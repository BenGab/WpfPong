using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;
using static WpfPong.PongLogic;

namespace WpfPong
{
    public class PongControl : FrameworkElement
    {
        PongModel model;
        PongLogic logic;
        PongRenderer renderer;
        DispatcherTimer tickTimer;

        public PongControl()
        {
            Loaded += PongControl_Loaded;
        }

        private void PongControl_Loaded(object sender, RoutedEventArgs e)
        {
            model = new PongModel();
            logic = new PongLogic(model);
            renderer = new PongRenderer(model);

            Window wnd = Window.GetWindow(this);
            if(wnd != null)
            {
                tickTimer = new DispatcherTimer();
                tickTimer.Interval = TimeSpan.FromMilliseconds(40);
                tickTimer.Tick += TickTimer_Tick;
                tickTimer.Start();

                wnd.KeyDown += Wnd_KeyDown;
                this.MouseLeftButtonDown += PongControl_MouseLeftButtonDown;
            }
            logic.RefreshScreen += (s, e) => InvalidateVisual();
            InvalidateVisual();
        }

        private void PongControl_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            logic.JumpPad(e.GetPosition(this).X);
        }

        private void Wnd_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            switch(e.Key)
            {
                case Key.Left:
                    logic.MovePad(Direction.Left);
                    break;

                case Key.Right:
                    logic.MovePad(Direction.Right);
                    break;
            }
        }

        private void TickTimer_Tick(object sender, EventArgs e)
        {
            logic.MoveBall();
        }
        protected override void OnRender(DrawingContext drawingContext)
        {
            if(renderer != null)
            {
                renderer.DrawThings(drawingContext);
            }
        }
    }
}
