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
        public override GameState Update()
        {
            SplashKit.DrawBitmap(SplashKit.BitmapNamed("StartImage"), 0, 0);
            SplashKit.DrawText("Asteroids", Color.Brown, SplashKit.FontNamed("scoreFont"), 100, 150, 0);
            GameManager.Instance.StartButton.Draw();

            if (GameManager.Instance.StartButton.Clicked())
            {
                  return GameState.Ingame;
            }
            return GameState.Start;
        }
    }
}
