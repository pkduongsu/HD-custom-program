using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Asteroids.lib;

namespace Asteroids.BuffFactory
{
    public class AmmoCreator : BuffCreator
    {
        public override Buff CreateBuff()
        {
            return new Ammo(SplashKit.BitmapNamed("Ammo"));
        }
    }
}
