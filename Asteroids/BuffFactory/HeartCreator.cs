using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Asteroids.lib;

namespace Asteroids.BuffFactory
{
    public class HeartCreator : BuffCreator
    {
        public override Buff CreateBuff()
        {
            return new Heart(SplashKit.BitmapNamed("Heart"));
        }
    }
}
