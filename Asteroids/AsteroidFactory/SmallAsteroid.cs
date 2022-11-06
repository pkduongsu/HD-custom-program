using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Asteroids.lib;

namespace Asteroids.AsteroidFactory
{
    public class SmallAsteroid : GameObject, Asteroid
    {
        private Velocity _velocity;
        private double _scale;
        private int _health;
        public SmallAsteroid(Bitmap img) : base(img)
        {
            Random rand = new Random();
            X = rand.Next(1, 750);
            Y = 0;
            _velocity.X = 0;
            _velocity.Y = 3;
            _scale = 0.7;
            _health = 1;
        }

        public int Health
        {
            get { return _health; }
            set { _health = value; }
        }
        public float Speed
        {
            get { return (float)_velocity.Y; }
            set { _velocity.Y = value; }
        }

        public override void Draw()
        {
            DrawingOptions opts;
            opts = SplashKit.OptionScaleBmp(_scale, _scale);
            SplashKit.DrawBitmap(Image, X, Y, opts);      
        }

        public void Move()
        {
            X += (float)_velocity.X;
            Y += (float)_velocity.Y;
        }

        public bool ToRemove()
        {
            if (Y > 600) // out of screen
            {
                return true;
            }
            return false;
        }
    }
}
