using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfPong
{
    public class PongModel
    {
        public int Errors { get; set; }

        public MyShape Pad { get; set; }
        public MyShape Ball { get; set; }

        public PongModel()
        {
            Ball = new MyShape(Config.Width / 2, Config.Height / 2, Config.BallSize, Config.BallSize);
            Pad = new MyShape(Config.Width / 2, Config.Height - Config.PadHeight, Config.PadHeight, Config.PadWidht);
        }
    }
}
