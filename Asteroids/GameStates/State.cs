using Asteroids.lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids.GameStates
{
    public abstract class State
    {

        public State()
        {

        }

        public abstract GameState Update();

    }
}
