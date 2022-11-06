using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Asteroids.lib;

namespace Asteroids.GameStates
{
    public class IngameState : State
    {
        public IngameState() : base()
        {
            
        }
        public override void Update()
        {
            Game.IngameSetup();

            Game.StartTimer();
            Game.UpdateLevel();
             
            Game.Jet.Draw();
            Game.Jet.Move(SplashKit.MouseX(), SplashKit.MouseY());

            Game.AddBullet();
            Game.InitializeBullet();

            Game.AddAsteroids();
            Game.InitializeAsteroids();

            Game.AddBuffs();
            Game.InitializeBuffs();

            Game.CheckBulletCollision();
            Game.CheckJetCollision();
            Game.CheckBuffCollision();

            Game.RemoveBullet();
            Game.RemoveAsteroid();
            Game.RemoveBuffs();
        }

        public override GameState ChangeState()
        {
            if (Game.GameOver())
            {
                return GameState.End;
            }
            return GameState.Ingame;
        }
    }
}
