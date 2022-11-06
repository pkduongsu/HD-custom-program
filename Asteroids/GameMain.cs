using System.Collections.Generic;
using System;
using Asteroids.lib;
using Asteroids.GameStates;

namespace Asteroids
{
    public class GameMain
    {
        public static void LoadResources()
        {
            SplashKit.LoadSoundEffect("Collision", "C:\\Asteroids\\sounds\\collision.wav");
            SplashKit.LoadSoundEffect("Explosion", "C:\\Asteroids\\sounds\\explosion.wav");
            SplashKit.LoadSoundEffect("Gunsound", "C:\\Asteroids\\sounds\\gunsound.wav");
            SplashKit.LoadBitmap("Asteroid", "C:\\Asteroids\\images\\asteroid.png");
            SplashKit.LoadBitmap("Bullet", "C:\\Asteroids\\images\\bullet.png");
            SplashKit.LoadBitmap("Heart", "C:\\Asteroids\\images\\heart.png");
            SplashKit.LoadBitmap("Jet", "C:\\Asteroids\\images\\jetfighter.png");
            SplashKit.LoadBitmap("Space", "C:\\Asteroids\\images\\space.jpg");
            SplashKit.LoadBitmap("StartImage", "C:\\Asteroids\\images\\startimage.jpeg");
            SplashKit.LoadBitmap("ResetButton", "C:\\Asteroids\\images\\resetbutton.png");
            SplashKit.LoadBitmap("GameOver", "C:\\Asteroids\\images\\gameover.png");
            SplashKit.LoadBitmap("StartButton", "C:\\Asteroids\\images\\startbutton.png");
            SplashKit.LoadFont("scoreFont", "C:\\Asteroids\\fonts\\PixeloidSans-nR3g1.ttf");
        }
        public static void Main()
        {
            //game setups
            LoadResources();

            Window window = new Window("Asteroids", 800, 600);

            GameManager game = GameManager.Instance;

            //main game loop
            while (!window.CloseRequested)
            {
                SplashKit.ProcessEvents();

                game.StateManager.Update();

                SplashKit.RefreshScreen(60);
                SplashKit.ClearScreen();
            }
        }
    }
}