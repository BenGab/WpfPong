using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace WpfPong
{
    public class PongRenderer
    {
        PongModel model;
        public PongRenderer(PongModel model)
        {
            this.model = model;
        }

        public void DrawThings(DrawingContext ctx)
        {
            DrawingGroup dg = new DrawingGroup();

            GeometryDrawing background = new GeometryDrawing(Config.BgBrush,
                new Pen(Config.BorderBrush, Config.BorderSize),
                new RectangleGeometry(new Rect(0, 0, Config.Width, Config.Height)));

            GeometryDrawing ball = new GeometryDrawing(Config.BallBgBrush,
                new Pen(Config.BallLineBrush, 1),
                new EllipseGeometry(model.Ball.Area));

            GeometryDrawing pad = new GeometryDrawing(Config.PadBgBrush, 
                new Pen(Config.PadLineBrush, 1),
                new RectangleGeometry(model.Pad.Area));

            FormattedText ft = new FormattedText(model.Errors.ToString(), System.Globalization.CultureInfo.CurrentCulture, FlowDirection.LeftToRight, new Typeface("Arial"),
                16,
                Brushes.Black);
            GeometryDrawing text = new GeometryDrawing(null, new Pen(Brushes.Red, 3), ft.BuildGeometry(new Point(5 ,5)));

            dg.Children.Add(background);
            dg.Children.Add(ball);
            dg.Children.Add(pad);
            dg.Children.Add(text);

            ctx.DrawDrawing(dg);
        }
    }
}
