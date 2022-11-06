using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids.AsteroidFactory
{
    public abstract class AsteroidCreator
    {
        public abstract Asteroid CreateAsteroid();

        public void Operations(List<Asteroid> asteroids)
        {
            Asteroid asteroid = CreateAsteroid();

            asteroids.Add(asteroid);
        }

    }
}
