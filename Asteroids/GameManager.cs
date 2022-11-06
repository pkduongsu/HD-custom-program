using Asteroids.GameStates;
using Asteroids.lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Asteroids.AsteroidFactory;
using Asteroids.BuffFactory;
using System.Reflection.PortableExecutable;

namespace Asteroids
{
    public class GameManager
    {
        private List<Bullet> _bullets;
        private List<Asteroid> _asteroids;
        private List<Buff> _buffs;
        private Jet _aJet;

        private Button _endButton;
        private Button _startButton;

        private int _score;
        private int _level;
        private int _timer;
        private int _highScore;

        private int _spawnThreshold;
        private int _spawnGap;

        string _scorefile;

        private StateManager _stateManager;

        private static GameManager _instance;
        public static GameManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new GameManager();
                }
                return _instance;
            }
        }
        private GameManager()
        {
            _instance = this;
            _aJet = new Jet(SplashKit.BitmapNamed("Jet"));
            _bullets = new List<Bullet>();
            _asteroids = new List<Asteroid>();
            _buffs = new List<Buff>();
            _startButton = new Button(240, 300, SplashKit.BitmapNamed("StartButton"), 0.7);
            _endButton = new Button(315, 450, SplashKit.BitmapNamed("ResetButton"), 1.0);
            _stateManager = new StateManager();
            _score = 0;
            _timer = 0;
            _level = 0;
            _spawnThreshold = 3; //initial threshold
            _spawnGap = 100; //2 seconds
            _highScore = 0;
            _scorefile = "C:\\Asteroids\\highscore.txt";
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

        public void Run()
        {
            _stateManager.Update();
        }

        public void StartTimer()
        {
            _timer++;
        }

        public void ResetTimer()
        {
            _timer = 0;
        }

        public void UpdateLevel()
        {
            if (_timer % 300 == 0) // for every 5 seconds, raise level;
            {
                _level++;
                if (_spawnGap > 15) //maximum spawngap
                {
                    _spawnGap -= 15;
                }

                if (_level % 3 == 0) //for every 3 level, raise asteroid speed
                {
                    for (int i = 0; i < _asteroids.Count; i++)
                    {
                        _asteroids[i].Speed += 1;
                    }
                    if (_spawnThreshold < 8) //maximum threshold
                        _spawnThreshold += 1;
                }
            }
        }

        public void StartSetup()
        {
            SplashKit.DrawBitmap(SplashKit.BitmapNamed("StartImage"), 0, 0);
            SplashKit.DrawText("Asteroids", Color.Brown, SplashKit.FontNamed("scoreFont"), 100, 150, 0);
            _startButton.Draw();
        }

        public void IngameSetup()
        {
            //DrawIngameBackground();
            SplashKit.DrawBitmap(SplashKit.BitmapNamed("Space"), 0, 0);

            SplashKit.HideMouse();

            //DrawScore();
            SplashKit.DrawText("Score: " + _score, Color.White, SplashKit.FontNamed("scoreFont"), 30, 550, 0);

            //DrawHealth();
            int heartX = 0;
            for (int i = 0; i < _aJet.Health; i++)
            {
                SplashKit.DrawBitmap(SplashKit.BitmapNamed("Heart"), heartX, 0);
                heartX += 30;
            }

            //Draw level
            SplashKit.DrawText("Level: " + _level, Color.White, SplashKit.FontNamed("scoreFont"), 30, 0, 570);

            //Draw gun level
            SplashKit.DrawText("Gun level: " + _aJet.GunLevel, Color.White, SplashKit.FontNamed("scoreFont"), 30, 570, 570);
        }

        public void EndSetup()
        {
            SaveHighScore();
            SplashKit.DrawBitmap(SplashKit.BitmapNamed("GameOver"), 0, 0);
            SplashKit.ShowMouse();
            _endButton.Draw();
            SplashKit.DrawText("Your Score: " + _score, Color.White, SplashKit.FontNamed("scoreFont"), 30, 270, 35);
            SplashKit.DrawText("High Score: " + _highScore, Color.White, SplashKit.FontNamed("scoreFont"), 30, 270, 70);
        }

        public void LoadHighScore()
        {
            int score;
            StreamReader reader = new StreamReader(_scorefile); //read high score file
            score = Convert.ToInt32(reader.ReadLine());
            if (score > _highScore)
                _highScore = score;
            reader.Close();
        }

        public void SaveHighScore()
        {
            StreamWriter writer = new StreamWriter(_scorefile);
            try
            {
                if (_score > _highScore)
                {
                    writer.WriteLine(_score);
                    _highScore = _score;
                }
            }
            finally
            {
                writer.Close();
            }
        }


        public void AddBuffs()
        {
            if (_timer % _spawnGap == 0) //for every "gap" secconds
            {
                Random rand = new Random();
                int num = rand.Next(1, 11);
                if (num == 1) //20%
                {
                    BuffCreator creator;
                    int num2 = rand.Next(0, 10);
                    if (num2 < 3) //30%
                    {
                        creator = new HeartCreator();
                    }
                    else creator = new AmmoCreator(); //70%

                    creator.Operations(_buffs);
                }
            }
        }

        public void RemoveBuffs()
        {
            List<Buff> toRemove = new List<Buff>();

            foreach (Buff b in _buffs)
            {
                if (b.JetCollided(_aJet))
                {
                    toRemove.Add(b);
                }
            }

            foreach (Buff b in toRemove)
            {
                _buffs.Remove(b);
            }
        }

        public void CheckBuffCollision()
        {
            List<Buff> toRemove = new List<Buff>();

            for (int i = 0; i < _buffs.Count; i++)
            {
                if (_buffs[i].JetCollided(_aJet))
                {
                    _buffs[i].Update(_aJet);
                    toRemove.Add(_buffs[i]);
                }
            }

            foreach (Buff i in toRemove)
            {
                _buffs.Remove(i);
            }
        }

        public void InitializeBuffs()
        {
            foreach(Buff b in _buffs)
            {
                b.Draw();
                b.Move();
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
                    _aJet.Health--;
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
                        _score += 10;
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

        public void CheckJetCollision()
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
      }

        public bool GameOver()
        {
            if (_aJet.Health <= 0)
            {
                return true;
            }
            return false;
        }


        public void AddBullet()
        {
            if (SplashKit.MouseClicked(MouseButton.LeftButton))
            {
                if (_bullets.Count < _aJet.GunLevel)
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
            if (_timer % _spawnGap == 0) //for every "gap" secconds
            {
                if (_asteroids.Count < _spawnThreshold)
                {
                    AsteroidCreator creator;
                    Random rand = new Random();
                    int num = rand.Next(0, 11);
                    if (num < 9)
                    {
                        creator = new SmallAsteroidCreator();
                    }
                    else creator = new BigAsteroidCreator();

                    creator.Operations(_asteroids);
                }
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
            _score = 0;
            _bullets.Clear();
            _asteroids.Clear();
            _timer = 0;
            _level = 0;
            _spawnGap = 180;
            _spawnThreshold = 3;
            _aJet.GunLevel = 1;
        }
    }
}
