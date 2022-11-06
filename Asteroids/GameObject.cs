using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Asteroids.lib;
using Asteroids.AsteroidFactory;

namespace Asteroids
{
    public abstract class GameObject
    {
        private Position _position;
        private double _angle;
        private Bitmap _image;

        public GameObject(Bitmap img)
        {
            _angle = 0;
            _image = img;
        }
        
        public float X
        {
            get { return _position.X; }
            set { _position.X = value; }
        }
        public float Y
        {
            get { return _position.Y; }
            set { _position.Y = value; }
        }

        public Bitmap Image
        {
            get { return _image; }
        }

        public double Angle 
        { 
            get { return _angle; } 
            set { _angle = value;  }
        }

        public abstract void Draw();

        public bool AsteroidCollided(Asteroid asteroid)
        {
            return SplashKit.BitmapCollision(Image, X, Y, asteroid.Image, asteroid.X, asteroid.Y);
        }
    }
}
