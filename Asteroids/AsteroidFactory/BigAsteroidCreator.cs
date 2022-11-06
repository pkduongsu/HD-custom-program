using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Asteroids.lib;

namespace Asteroids.AsteroidFactory
{
    public class BigAsteroidCreator : AsteroidCreator
    {
        public override Asteroid CreateAsteroid()
        {
            return new BigAsteroid();
        }

    }
}
