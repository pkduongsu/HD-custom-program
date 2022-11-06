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
        private GameManager _game;

        public State()
        {
            _game = GameManager.Instance;
        }

        public GameManager Game
        {
            get { return _game;  }
        }
        
        public abstract GameState ChangeState();

        public abstract void Update();
    }
}
