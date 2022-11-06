using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Asteroids.lib;

namespace Asteroids.AsteroidFactory
{
    public interface Asteroid
    {
        public int Health
        {
            get;
            set;
        }

        public float X
        {
            get;
            set;
        }

        public float Y
        {
            get;
            set;
        }
        
        public float Speed
        {
            get;
            set;
        }

        public Bitmap Image
        {
            get;
        }

        public void Draw();

        public void Move();

        public bool ToRemove();
    }
}
