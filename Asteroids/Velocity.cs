using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids
{
    public struct Velocity
    {
        public double _vel_x;
        public double _vel_y;

        public double X
        {
            get { return _vel_x; }
            set { _vel_x = value; }
        }

        public double Y
        {
            get { return _vel_y; }
            set { _vel_y = value; }
        }

    }
}
