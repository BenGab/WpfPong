using System.Windows.Media;

namespace WpfPong
{
    public static class Config
    {
        public static Brush BorderBrush = Brushes.DarkGray;
        public static Brush BgBrush = Brushes.Cyan;

        public static Brush BallBgBrush = Brushes.Yellow;
        public static Brush BallLineBrush = Brushes.Red;
        public static Brush PadBgBrush = Brushes.Brown;
        public static Brush PadLineBrush = Brushes.Black;

        public static double Width = 700;
        public static double Height = 300;
        public static int BorderSize = 4;

        public static int BallSize = 20;
        public static int PadWidht = 100;
        public static int PadHeight = 20;
    }
}
