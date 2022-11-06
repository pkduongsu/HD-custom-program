using Asteroids.lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids.GameStates
{ 
    public class StartState : State
    { 
        public StartState() : base()
        {

        }
        public override void Update()
        {
            Game.StartSetup();
        }

        public override GameState ChangeState()
        {
            if (Game.StartButton.Clicked())
            {
                return GameState.Ingame;
            }
            return GameState.Start;
        }
    }
}
