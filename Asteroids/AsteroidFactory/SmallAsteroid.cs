﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Asteroids.lib;

namespace Asteroids.AsteroidFactory
{
    public class SmallAsteroid : Asteroid
    {
        private Position _position;
        private Velocity _velocity;
        private double _scale;
        private int _health;
        private Bitmap _image;
        public SmallAsteroid()
        {
            Random rand = new Random();
            _position.X = rand.Next(0, 801) * 75;
            _position.Y = 0;
            _velocity.X = 0;
            _velocity.Y = 3;
            _scale = 0.7;
            _health = 1;
            _image = SplashKit.BitmapNamed("Asteroid");
        }

        public int Health
        {
            get { return _health; }
            set { _health = value; }
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

        public float Speed
        {
            get { return (float)_velocity.Y; }
            set { _velocity.Y = value; }
        }

        public Bitmap Image
        {
            get { return _image; }
        }

        public void Draw()
        {
            DrawingOptions opts;
            opts = SplashKit.OptionScaleBmp(_scale, _scale);
            SplashKit.DrawBitmap(_image, _position.X, _position.Y, opts);      
        }

        public void Move()
        {
            _position.X += (float)_velocity.X;
            _position.Y += (float)_velocity.Y;
        }

        public bool ToRemove()
        {
            if (_position.X < 0 || _position.X > 800 || _position.Y < 0 || _position.Y > 600) // out of screen
            {
                return true;
            }
            return false;
        }
    }
}
