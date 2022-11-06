using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Asteroids.lib;

namespace Asteroids
{
    public class Button
    {
        private int _x;
        private int _y;
        private Bitmap _image;
        private double _scale;
        public Button(int X, int Y, Bitmap bmp, double scale)
        {
            _x = X;
            _y = Y;
            _image = bmp;
            _scale = scale;
        }

        public int X
        {
            get { return _x; }
        }

        public int Y
        {
            get { return _y; }
        }

        public void Draw()
        {
            DrawingOptions opts;
            opts = SplashKit.OptionScaleBmp(_scale, _scale);

            SplashKit.DrawBitmap(_image, _x, _y, opts);
        }

        public bool Clicked()
        {
            return SplashKit.BitmapPointCollision(_image, _x, _y, SplashKit.MouseX(), SplashKit.MouseY()) && SplashKit.MouseClicked(MouseButton.LeftButton);
        }

    }
}
