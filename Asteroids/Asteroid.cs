using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Asteroids.lib;

namespace Asteroids
{
    public class Asteroid : GameObject
    {
        private Velocity _velocity;

        public Asteroid(Bitmap img) : base(img)
        {
            Random rand = new Random();
            X = rand.Next(0, 801) * 75;
            Y = 0; 
            _velocity.X = 0;
            _velocity.Y = 6;
        }

        public override void Draw()
        {
            SplashKit.DrawBitmap(Image, X, Y);
        }

        public void Move()
        {
            X += (float)_velocity.X;
            Y += (float)_velocity.Y;
        }
    }
}
