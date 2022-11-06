using Asteroids.GameStates;
using Asteroids.lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Asteroids.AsteroidFactory;

namespace Asteroids
{
    public class GameManager
    {
        private List<Bullet> _bullets;
        private List<Asteroid> _asteroids;
        private Jet _aJet;

        private Button _endButton;
        private Button _startButton;

        private StateManager _stateManager;

        private static GameManager _instance;
        public static GameManager Instance
        {
            get { return _instance ?? (_instance = new GameManager()); }
        }
        private GameManager()
        {
            _instance = this;
            _aJet = new Jet(SplashKit.BitmapNamed("Jet"));
            _bullets = new List<Bullet>();
            _asteroids = new List<Asteroid>();
            _startButton = new Button(240, 300, SplashKit.BitmapNamed("StartButton"), 0.7);
            _endButton = new Button(315, 450, SplashKit.BitmapNamed("ResetButton"), 1.0);
            _stateManager = new StateManager();
        }

        public StateManager StateManager
        {
            get { return _stateManager;}
        }

        public Button StartButton
        {
            get { return _startButton; }
        }

        public Button EndButton
        {
            get { return _endButton; }
        }

        public Jet Jet
        {
            get { return _aJet; }
        }
        public void DrawBackground()
        {
            SplashKit.DrawBitmap(SplashKit.BitmapNamed("Space"), 0, 0);
        }
        public void DrawScore()
        {
            SplashKit.DrawText("Score: " + _aJet.Score, Color.White, SplashKit.FontNamed("scoreFont"), 30, 550, 0);
        }
        public void DrawHealth()
        {
            int heartX = 0;
            for (int i = 0; i < _aJet.Health; i++)
            {
                SplashKit.DrawBitmap(SplashKit.BitmapNamed("Heart"), heartX, 0);
                heartX += 30;
            }
        }
        public void RemoveBullet()
        {
            List<Bullet> toRemove = new List<Bullet>();

            foreach (Bullet b in _bullets)
            {
                if (b.X < 0 || b.X > 800 || b.Y < 0 || b.Y > 600)
                {
                    toRemove.Add(b);
                }
            }

            foreach (Bullet b in toRemove)
            {
                _bullets.Remove(b);
            }
        }

        public void RemoveAsteroid()
        {
            List<Asteroid> toRemove = new List<Asteroid>();

            foreach (Asteroid a in _asteroids)
            {
                if (a.ToRemove())
                {
                    toRemove.Add(a);
                }
            }

            foreach (Asteroid a in toRemove)
            {
                _asteroids.Remove(a);
            }
        }

          public void CheckBulletCollision()
          {
            List<Bullet> bToRemove = new List<Bullet>();
            List<Asteroid> aToRemove = new List<Asteroid>();
       
            for (int i = 0; i < _bullets.Count; i++)
            {
                for (int j = 0; j < _asteroids.Count; j++)
                {
                    if ((_bullets[i]).AsteroidCollided(_asteroids[j]))
                  {
                        _aJet.Score += 10;
                        _asteroids[j].Health--;
                        bToRemove.Add(_bullets[i]);

                        if (_asteroids[j].Health == 0)
                            aToRemove.Add(_asteroids[j]);
                   }
                }
           }

           foreach (Bullet b in bToRemove)
           {
               _bullets.Remove(b);
           }

           foreach (Asteroid a in aToRemove)
            {
               _asteroids.Remove(a);
           }
       }

        public bool CheckJetCollision()
        {
            List<Asteroid> toRemove = new List<Asteroid>();

            for (int i = 0; i < _asteroids.Count; i++)
            {
               if (_aJet.AsteroidCollided(_asteroids[i]))
                {
                    toRemove.Add(_asteroids[i]);
                   _aJet.Health--;
               }
           }

           foreach (Asteroid i in toRemove)
           {
               _asteroids.Remove(i);
           }

           return false;
      }

        public bool GameOver()
        {
            if (_aJet.Health == 0)
            {
                return true;
            }
            return false;
        }
        public void AddBullet()
        {
            if (SplashKit.MouseClicked(MouseButton.LeftButton))
            {
                if (_bullets.Count < 5)
                {
                    Bullet aBullet = _aJet.Shoot();
                    _bullets.Add(aBullet);
                }
            }
        }

        public void InitializeBullet()
        {
            foreach (Bullet b in _bullets)
            {
                b.Draw();
                b.Move();
            }
        }

        public void AddAsteroids()
        {
            if (_asteroids.Count < 40)
            {
                AsteroidCreator creator;
                Random rand = new Random();
                int num = rand.Next(0, 101);
                if (num < 80)
                {
                    creator = new SmallAsteroidCreator();
                }
                else creator = new BigAsteroidCreator();

                creator.Operations(_asteroids);
            }
        }

       public void InitializeAsteroids()
       {
         foreach (Asteroid a in _asteroids)
         {
             a.Draw();
             a.Move();
          }
       
        }
        public void ResetGame()
        {
            _aJet.Health = 3;
            _aJet.Score = 0;
        }
    }
}
