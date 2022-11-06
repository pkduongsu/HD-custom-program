using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Asteroids.lib;
using static System.Net.Mime.MediaTypeNames;

namespace Asteroids.BuffFactory
{
    public class Heart : GameObject, Buff
    {
        private Velocity _velocity;
        public Heart(Bitmap bmp) : base(bmp)
        {
            Random rand = new Random();
            X = rand.Next(0, 758);
            Y = 0;
            _velocity.X = 0;
            _velocity.Y = 3;
        }

        public override void Draw()
        {
            DrawingOptions opts;
            opts = SplashKit.OptionScaleBmp(0.8, 0.8);
            SplashKit.DrawBitmap(Image, X, Y, opts);
        }

        public void Move()
        {
            X += (float)_velocity.X;
            Y += (float)_velocity.Y;
        }

        public bool JetCollided(Jet jet)
        {
            return SplashKit.BitmapCollision(jet.Image, jet.X, jet.Y, Image, X, Y);
        }

        public void Update(Jet jet)
        {
            jet.Health++;
        }

    }
}
