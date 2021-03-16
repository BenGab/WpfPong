using System.Windows;

namespace WpfPong
{
    public class MyShape
    {
        Rect area;

        public Rect Area { get => area; }

        public int Dx { get; set; }

        public int Dy { get; set; }

        public MyShape(double x, double y, double h, double w)
        {
            area = new Rect(x, y, w, h);
            Dx = 5;
            Dy = 5;
        }

        public void ChangeX(double diff)
        {
            area.X += diff;
        }

        public void ChangeY(double diff)
        {
            area.Y += diff;
        }

        public void SetXY(double x, double y)
        {
            area.X = x;
            area.Y = y;
        }
    }
}
