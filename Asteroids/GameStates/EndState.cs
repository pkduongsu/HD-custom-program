using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Asteroids.lib;

namespace Asteroids.GameStates
{
    public class EndState : State
    {

        public EndState() : base()
        {

        }
        public override void Update()
        {
            Game.EndSetup();
        }

        public override GameState ChangeState()
        {
            if (Game.EndButton.Clicked())
            {
                Game.ResetGame();
                return GameState.Ingame;
            }
            return GameState.End;
        }


    }
}
