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

        public override GameState Update()
        {

            GameManager.Instance.DrawBackground();
             
            GameManager.Instance.Jet.Draw();
            GameManager.Instance.Jet.Move(SplashKit.MouseX(), SplashKit.MouseY());

            GameManager.Instance.AddBullet();
            GameManager.Instance.InitializeBullet();

            GameManager.Instance.AddAsteroids();
            GameManager.Instance.InitializeAsteroids();

            GameManager.Instance.RemoveBullet();
            GameManager.Instance.RemoveAsteroid();

            GameManager.Instance.CheckBulletCollision();
            GameManager.Instance.CheckJetCollision();

            GameManager.Instance.DrawHealth();
            GameManager.Instance.DrawScore();

            if (GameManager.Instance.GameOver())
            {
                return GameState.End;
            }
            return GameState.Ingame;
        }


    }
}
