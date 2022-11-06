using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Asteroids.lib;
using Asteroids.AsteroidFactory;

namespace Asteroids
{
    public class Bullet : GameObject
    {
        private Velocity _velocity;
        private SoundEffect _sound;

        public Bullet(Bitmap img, double jetAngle, float jetPosX, float jetPosY, SoundEffect sound) : base(img)
        {
            X = jetPosX;
            Y = jetPosY;
            _velocity.X = 0;
            _velocity.Y = 0;
            Angle = jetAngle;
            _sound = sound;
        }
        public override void Draw()
        {
            DrawingOptions opts;
            opts = SplashKit.OptionRotateBmp(Angle);
            opts = SplashKit.OptionScaleBmp(0.7, 0.7);
            SplashKit.DrawBitmap(Image, X, Y, opts);
            
        }

        public void Move()
        {
            SetVelocity();

            //UPDATE POSITION
            X += (int)_velocity.X;
            Y += (int)_velocity.Y;
        }

        public void SetVelocity()
        {
            Vector2D offset = SplashKit.VectorFromAngle(Angle - 90, 0.5);
            _velocity.X += offset.X;
            _velocity.Y += offset.Y;
        }

        public void PlaySound() 
        {
            SplashKit.PlaySoundEffect(_sound);
        }

    }
}
