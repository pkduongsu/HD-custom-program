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

        public override GameState Update()
        { 
            SplashKit.DrawBitmap(SplashKit.BitmapNamed("GameOver"), 0, 0);
            SplashKit.ShowMouse();

            GameManager.Instance.EndButton.Draw();

            if (GameManager.Instance.EndButton.Clicked())
            {
                 GameManager.Instance.ResetGame();
                 return GameState.Ingame;
            }
            return GameState.End;
        }


    }
}
