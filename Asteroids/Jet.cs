using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Asteroids.AsteroidFactory;
using Asteroids.lib;

namespace Asteroids
{
    public class Jet : GameObject
    {
        private int _health;
        private int _score;
        private int _gunLevel;
        private Velocity _velocity;
        
        public Jet(Bitmap img) : base(img) 
        {
            _health = 3; //default health value
            _score = 0;
            _velocity.X = 0;
            _velocity.Y = 0;
            _gunLevel = 1; //default gun level
        }

        public int Health 
        { 
            get { return _health; } 
            set { _health = value; }
        }

        public int Score 
        { 
            get { return _score; } 
            set { _score = value; }
        }

        public int GunLevel
        {
            get { return _gunLevel; }
            set { _gunLevel = value; }
        }

        public void Move(float posX, float posY)
        {
            X = posX - SplashKit.BitmapWidth(Image) / 2;
            Y = posY - SplashKit.BitmapHeight(Image) / 2;
        }

        public override void Draw()
        {
            DrawingOptions opts;
            opts = SplashKit.OptionRotateBmp(Angle);
            opts.ScaleX = (float)0.7;
            opts.ScaleY = (float)0.7;
            SplashKit.DrawBitmap(Image, X, Y, opts);
        }

        public Bullet Shoot()
        {
            float bulletX = X + 15;
            float bulletY = Y - 20;
            Bullet aBullet = new Bullet(SplashKit.BitmapNamed("Bullet"), Angle, bulletX, bulletY, SplashKit.SoundEffectNamed("Gunsound"));
            aBullet.PlaySound();
            return aBullet;
        }

    }
}
