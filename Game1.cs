using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Delivery_Dog_Fight
{

    enum Screen 
    {
        LevelSelect, 
        TipScreen,
        Level1,
        LoadingScreen1,
        LoadingScreen2,
        Level2,   
        Level3,
        FailedScreen,
        Done
    }
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        //   Delivery Dogfight
        //   Maxym Fediw

        Screen screen;

        Random generator1, generator2, generator3, generator4, generator5, generator6, generator7, generator8, generator9, generator10;

        MouseState mouseState, prevMouseState;

        KeyboardState keyboardState, prevKeyboardState;

        Texture2D introJetTexture, happyTexture, victoryTexture, homeScreentexture, crossHairTexture, cockpitTexture, upsJetTextureBig, upsJetTextureSmall, fedExJetTextureBig, fedExJetTextureSmall, canJetSmallTexture, canJetBigTexture, dhlJetBigTexture, dhlJetSmallTexture, amazonJetSmallTexture, amazonJetBigTexture, explosionTexture;

        Rectangle upsJetBigRect, tutorialCanRect, happyrect, victoryRect, tutorialAmzRect, playRect, gameHomeRect, crossHairRect, upsJetSmallRect, fedExBigRect, fedExSmallRect, canSmallRect, canBigRect, amazonSmallRect, amazonBigRect, dhlSmallRect, dhlBigRect, introJetRect, window, quitRect, ejectRect, cockpitRect, explosionRect;

        SpriteFont textFont;

        Vector2 upsSmallSpeed, upsBigSpeed, fedExSmallSpeed, fedExBigSpeed, amazonBigSpeed, amazonSmallSpeed, canSmallSpeed, canBigSpeed, dhlSmallSpeed, dhlBigSpeed;

        int timer;

        bool missionFailed, time = false, level1 = false, level2 = false, level3 = false, exploded, exploded1, exploded2, exploded3, exploded4, exploded5, exploded6, exploded7, exploded8, exploded9, reset1, reset2, reset3;

        SoundEffect shootSound, anthemSound, failedSound, explosionSound, dangerZoneSound;

        SoundEffectInstance shootSoundInstance, anthemSoundInstance, failedSoundInstance, explosionSoundInstance, dangerZoneInstance;

        //Last Things: Clean Up "In Between" Screens, Sound Effects, Music, Fix Front page, Make Eject Button Work, Make "Exit" Button Work.


        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = false;

        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here


         //                       X, Y, Width, Height
            window = new Rectangle(0, 0, 1000, 710);    //500, 355

            _graphics.PreferredBackBufferHeight = window.Height;
            _graphics.PreferredBackBufferWidth = window.Width;
            _graphics.ApplyChanges();

            timer = 0;

            missionFailed = false;
            reset1 = false;
            reset2 = false;
            reset3 = false;
            exploded = false;
            exploded1 = false;
            exploded2 = false;
            exploded3 = false;
            exploded4 = false;
            exploded5 = false;
            exploded6 = false;
            exploded7 = false;
            exploded8 = false;
            exploded9 = false;

            //                            X, Y, Width, Height

            explosionRect = new Rectangle(0, 0, 100, 100);

            upsJetBigRect = new Rectangle(20, 20, 300, 98);

            tutorialAmzRect = new Rectangle(838, 382 ,100, 32); //chf

            tutorialCanRect = new Rectangle(890, 301, 100, 32); //chf

            fedExBigRect = new Rectangle(300, 40, 300, 98);

            victoryRect = new Rectangle(0, 0, 1000, 571);

            happyrect = new Rectangle(681, 511, 250, 123);

            upsJetSmallRect = new Rectangle(40, 190, 100, 32); //s

            fedExSmallRect = new Rectangle(80, 210, 100, 32); //s

            amazonBigRect = new Rectangle(20, 120, 350, 110); //300 before it was 350

            amazonSmallRect = new Rectangle(40, 160, 100, 32); //s

            introJetRect = new Rectangle(244, 25, 500, 144);

            cockpitRect = new Rectangle(0, 10, 1000, 710);

            quitRect = new Rectangle(431, 673, 123, 29);

            ejectRect = new Rectangle(429, 689,127, 20);

            canBigRect = new Rectangle(5, 204, 300, 86);

            dhlBigRect = new Rectangle(300, 204, 300, 96);

            playRect = new Rectangle(395, 339, 200, 50);

            quitRect = new Rectangle(448, 400, 102, 46);

            dhlSmallRect = new Rectangle(540, 204, 100, 32); //s

            gameHomeRect = new Rectangle(0, 0, 1000, 710);

            canSmallRect = new Rectangle(540, 160, 100, 29);  //s

            crossHairRect = new Rectangle(mouseState.X, mouseState.Y, 39, 50);

            //if (level1) 
            //{

            //    upsBigSpeed = new Vector2(0, 2);
            //    upsSmallSpeed = new Vector2(0, 2);

            //    fedExBigSpeed = new Vector2(0, 2);
            //    fedExSmallSpeed = new Vector2(0, 2);
            //}

            upsBigSpeed = new Vector2(6, 0);
            upsSmallSpeed = new Vector2(2, 0);

            fedExBigSpeed = new Vector2(1, 0);     //Play around with these speeds...
            fedExSmallSpeed = new Vector2(3, 0);

            canSmallSpeed = new Vector2(4, 0);
            canBigSpeed = new Vector2(5, 0);

            dhlSmallSpeed = new Vector2(3, 0);
            dhlBigSpeed = new Vector2(4, 0);

            amazonBigSpeed = new Vector2(2, 0);
            amazonSmallSpeed = new Vector2(4, 0);   

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            introJetTexture = Content.Load<Texture2D>("canadaPostIntro");

            cockpitTexture = Content.Load<Texture2D>("CockpitTransparentDone");

            victoryTexture = Content.Load<Texture2D>("YouWin");

            upsJetTextureBig = Content.Load<Texture2D>("UPSJetBig");

            dangerZoneSound = Content.Load<SoundEffect>("DangerZone");

            happyTexture = Content.Load<Texture2D>("1");

            dangerZoneInstance = dangerZoneSound.CreateInstance();

            anthemSound = Content.Load<SoundEffect>("topGunAnthem");

            anthemSoundInstance = anthemSound.CreateInstance();

            upsJetTextureSmall = Content.Load<Texture2D>("UPSJetSmall");

            failedSound = Content.Load<SoundEffect>("missionFailed");

            failedSoundInstance = failedSound.CreateInstance();

            fedExJetTextureBig = Content.Load<Texture2D>("fedExJetBig");

            fedExJetTextureSmall = Content.Load<Texture2D>("fedExJetSmall");

            explosionTexture = Content.Load<Texture2D>("explosion");

            homeScreentexture = Content.Load<Texture2D>("DDIntro");

            canJetBigTexture = Content.Load<Texture2D>("canadaPostBig");

            crossHairTexture = Content.Load<Texture2D>("crosshairTransparent");

            canJetSmallTexture = Content.Load<Texture2D>("canadaPostSmall");

            dhlJetBigTexture = Content.Load<Texture2D>("dhlJetBig");

            dhlJetSmallTexture = Content.Load<Texture2D>("DHLJetSmall");

            amazonJetBigTexture = Content.Load<Texture2D>("AmazonJetBig");

            amazonJetSmallTexture = Content.Load<Texture2D>("AmazonJetSmall");

            explosionSoundInstance = Content.Load<SoundEffect>("explosion (1)").CreateInstance();

            textFont = Content.Load<SpriteFont>("TextFont1");

            explosionSound = Content.Load<SoundEffect>("explosion (1)");

            


            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            prevMouseState = mouseState;

            prevKeyboardState = keyboardState;

            mouseState = Mouse.GetState();

            keyboardState = Keyboard.GetState();

            crossHairRect = new Rectangle(mouseState.X - 20, mouseState.Y - 25, 39, 50);

            this.Window.Title = "" + mouseState.X + "," + mouseState.Y;



            if (mouseState.LeftButton == ButtonState.Pressed && prevMouseState.LeftButton == ButtonState.Released && quitRect.Contains(mouseState.Position)) 
            {
                Exit();
            }

            if (mouseState.LeftButton == ButtonState.Pressed && prevMouseState.LeftButton == ButtonState.Released && ejectRect.Contains(mouseState.Position))
            {
                Exit();
            }


            if (screen == Screen.LevelSelect)
            {
                failedSoundInstance.Stop();
                anthemSoundInstance.Stop();
                explosionSoundInstance.Stop();

                dangerZoneInstance.Play();


                if (mouseState.LeftButton == ButtonState.Pressed && prevMouseState.LeftButton == ButtonState.Released && playRect.Contains(mouseState.Position))
                {
                    screen = Screen.TipScreen;
                }
            }


            else if (screen == Screen.TipScreen)
            {
                dangerZoneInstance.Stop();
                explosionSoundInstance.Stop();
                anthemSoundInstance.Play();

                if (keyboardState.IsKeyDown(Keys.E) && prevKeyboardState.IsKeyUp(Keys.E))
                {
                    screen = Screen.Level1;
                    reset1 = true;
                }

            }

            else if(screen == Screen.LoadingScreen1)
            {
                explosionSoundInstance.Stop();
                anthemSoundInstance.Play();

                if (keyboardState.IsKeyDown(Keys.E) && prevKeyboardState.IsKeyUp(Keys.E))
                {
                    screen = Screen.Level2;
                    reset2 = true;
                }
            }

            else if (screen == Screen.LoadingScreen2)
            {
                explosionSoundInstance.Stop();
                anthemSoundInstance.Play();

                upsBigSpeed = new Vector2(6, 0);

                upsSmallSpeed = new Vector2(7, 0);

                fedExBigSpeed = new Vector2(4, 0);

                fedExSmallSpeed = new Vector2(10, 0);

                canBigSpeed = new Vector2(6, 0);

                canSmallSpeed = new Vector2(10, 0);

                dhlBigSpeed = new Vector2(6, 0);

                dhlSmallSpeed = new Vector2(9, 0);

                amazonBigSpeed = new Vector2(8, 0);

                if (keyboardState.IsKeyDown(Keys.E) && prevKeyboardState.IsKeyUp(Keys.E))
                {
                    screen = Screen.Level3;
                    reset3 = true;

                }
            }


            else if (screen == Screen.Level1)
            {
                anthemSoundInstance.Stop();

                if (reset1)
                {
                    upsJetBigRect.X = 20;
                    upsJetBigRect.Y = 20;
                    fedExBigRect.X = 300;
                    fedExBigRect.Y = 40;
                    upsJetSmallRect.X = 40;
                    upsJetSmallRect.Y = 190;
                    fedExSmallRect.X = 80;
                    fedExSmallRect.Y = 210;
                    amazonBigRect.X = 20;
                    amazonBigRect.Y = 120;
                    amazonSmallRect.X = 40;
                    amazonSmallRect.Y = 160;
                    canBigRect.X = 5;
                    canBigRect.Y = 204;
                    dhlBigRect.X = 300;
                    dhlBigRect.Y = 204;
                    dhlSmallRect.X = 540;
                    dhlSmallRect.Y = 204;
                    canSmallRect.X = 540;
                    canSmallRect.Y = 160;

                    upsBigSpeed = new Vector2(2, 0);

                    fedExBigSpeed = new Vector2(1, 0);

                    canBigSpeed = new Vector2(3, 0);

                    dhlBigSpeed = new Vector2(2, 0);

                    amazonBigSpeed = new Vector2(3, 0);

                    exploded = false;
                    exploded1 = false;
                    exploded2 = false;
                    exploded3 = false;
                    exploded4 = false;
                    exploded5 = false;
                    exploded6 = false;
                    exploded7 = false;
                    exploded8 = false;
                    exploded9 = false;



                    reset1 = false;
                }


                IsMouseVisible = false;



                upsJetSmallRect.X += (int)upsSmallSpeed.X;
                upsJetSmallRect.Y += (int)upsSmallSpeed.Y;

                upsJetBigRect.X += (int)upsBigSpeed.X;
                upsJetBigRect.Y += (int)upsBigSpeed.Y;


                fedExBigRect.X += (int)fedExBigSpeed.X;
                fedExBigRect.Y += (int)fedExBigSpeed.Y;

                fedExSmallRect.X += (int)fedExSmallSpeed.X;
                fedExSmallRect.Y += (int)fedExSmallSpeed.Y;

                canSmallRect.X += (int)canSmallSpeed.X;
                canSmallRect.Y += (int)canSmallSpeed.Y;

                canBigRect.X += (int)canBigSpeed.X;
                canBigRect.Y += (int)canBigSpeed.Y;

                dhlSmallRect.X += (int)dhlSmallSpeed.X;
                dhlSmallRect.Y += (int)dhlSmallSpeed.Y;

                dhlBigRect.X += (int)dhlBigSpeed.X;
                dhlBigRect.Y += (int)dhlBigSpeed.Y;

                amazonSmallRect.X += (int)amazonSmallSpeed.X;
                amazonSmallRect.Y += (int)amazonSmallSpeed.Y;

                amazonBigRect.X += (int)amazonBigSpeed.X;
                amazonBigRect.Y += (int)amazonBigSpeed.Y;


                // Resolve Big UPS Jet
                if (mouseState.LeftButton == ButtonState.Pressed && prevMouseState.LeftButton == ButtonState.Released && upsJetBigRect.Contains(mouseState.Position))
                {
                    exploded = true;
                    upsBigSpeed.Y = 1;
                    explosionRect = upsJetBigRect;
                    ExplosionSound();

                }
                if (upsJetBigRect.Left >= window.Right)
                {
                    upsJetBigRect.X = -300;
                    upsJetBigRect.Y = 20;
                    exploded = false;
                    upsBigSpeed.Y = 0f;
                }

                // Resolve Small UPS Jet
                if (mouseState.LeftButton == ButtonState.Pressed && prevMouseState.LeftButton == ButtonState.Released && upsJetSmallRect.Contains(mouseState.Position))
                {
                    exploded1 = true;
                    upsSmallSpeed.Y = 1;
                    explosionRect = upsJetSmallRect;
                    ExplosionSound();
                }

                if (upsJetSmallRect.Left >= window.Right)
                {
                    upsJetSmallRect.X = -300;
                    upsJetSmallRect.Y = 190;
                    exploded1 = false;
                    upsSmallSpeed.Y = 0f;

                }

                //Resolve Big CanPost Jet

                if (mouseState.LeftButton == ButtonState.Pressed && prevMouseState.LeftButton == ButtonState.Released && canBigRect.Contains(mouseState.Position))
                {
                    exploded4 = true;
                    canBigSpeed.Y = 1;
                    explosionRect = canBigRect;
                    ExplosionSound();
                    screen = Screen.FailedScreen;
                    missionFailed = true;
                }

                if (canBigRect.Left >= window.Right)
                {
                    canBigRect.X = -300;
                    canBigRect.Y = 204;
                    exploded4 = false;
                    canBigSpeed.Y = 0f;
                }

                //Resolve Small CanPost Jet

                if (mouseState.LeftButton == ButtonState.Pressed && prevMouseState.LeftButton == ButtonState.Released && canSmallRect.Contains(mouseState.Position))
                {
                    exploded5 = true;
                    canSmallSpeed.Y = 1;
                    explosionRect = canSmallRect;
                    ExplosionSound();
                    screen = Screen.FailedScreen;
                    missionFailed = true;
                }

                if (canSmallRect.Left >= window.Right)
                {
                    canSmallRect.X = -300;
                    canSmallRect.Y = 160;
                    canSmallSpeed.Y = 0f;
                    exploded5 = false;
                }

                //Resolve Big Amazon Jet

                if (mouseState.LeftButton == ButtonState.Pressed && prevMouseState.LeftButton == ButtonState.Released && amazonBigRect.Contains(mouseState.Position))
                {
                    exploded8 = true;
                    amazonBigSpeed.Y = 1;
                    explosionRect = amazonBigRect;
                    ExplosionSound();
                    screen = Screen.LoadingScreen1;
                    upsBigSpeed = new Vector2(3, 0);

                    upsSmallSpeed = new Vector2(4, 0);

                    fedExBigSpeed = new Vector2(2, 0);

                    fedExSmallSpeed = new Vector2(4, 0);

                    canBigSpeed = new Vector2(4, 0);

                    canSmallSpeed = new Vector2(5, 0);

                    dhlBigSpeed = new Vector2(3, 0);

                    dhlSmallSpeed = new Vector2(4, 0);

                    amazonBigSpeed = new Vector2(4, 0);
                }

                if (amazonBigRect.Left >= window.Right)
                {
                    amazonBigRect.X = -300;
                    amazonBigRect.Y = 120;
                    amazonBigSpeed.Y = 0f;
                    exploded8 = false;
                }

                //Resolve Small Amazon Jet

                if (mouseState.LeftButton == ButtonState.Pressed && prevMouseState.LeftButton == ButtonState.Released && amazonSmallRect.Contains(mouseState.Position))
                {
                    exploded9 = true;
                    amazonSmallSpeed.Y = 1;
                    explosionRect = amazonSmallRect;
                    ExplosionSound();
                    screen = Screen.LoadingScreen1;
                    upsBigSpeed = new Vector2(3, 0);

                    upsSmallSpeed = new Vector2(4, 0);

                    fedExBigSpeed = new Vector2(2, 0);

                    fedExSmallSpeed = new Vector2(4, 0);

                    canBigSpeed = new Vector2(4, 0);

                    canSmallSpeed = new Vector2(5, 0);

                    dhlBigSpeed = new Vector2(3, 0);

                    dhlSmallSpeed = new Vector2(4, 0);

                    amazonBigSpeed = new Vector2(4, 0);
                }

                if (amazonSmallRect.Left >= window.Right)
                {
                    amazonSmallRect.X = -300;
                    amazonSmallRect.Y = 160;
                    amazonSmallSpeed.Y = 0f;
                    exploded9 = false;
                }

                //Resolve DHL Big Jet

                if (mouseState.LeftButton == ButtonState.Pressed && prevMouseState.LeftButton == ButtonState.Released && dhlBigRect.Contains(mouseState.Position))
                {
                    exploded6 = true;
                    dhlBigSpeed.Y = 1;
                    ExplosionSound();
                    explosionRect = dhlBigRect;
                }

                if (dhlBigRect.Left >= window.Right)
                {
                    dhlBigRect.X = -300;
                    dhlBigRect.Y = 204;
                    dhlBigSpeed.Y = 0f;
                    exploded6 = false;
                }

                //Resolve DHL Small Jet

                if (mouseState.LeftButton == ButtonState.Pressed && prevMouseState.LeftButton == ButtonState.Released && dhlSmallRect.Contains(mouseState.Position))
                {
                    exploded7 = true;
                    dhlSmallSpeed.Y = 1;
                    ExplosionSound();
                    explosionRect = dhlSmallRect;
                }

                if (dhlSmallRect.Left >= window.Right)
                {
                    dhlSmallRect.X = -300;
                    dhlSmallRect.Y = 277;
                    dhlSmallSpeed.Y = 0f;
                    exploded7 = false;
                }

                //Resolve Big FedEx Jet

                if (mouseState.LeftButton == ButtonState.Pressed && prevMouseState.LeftButton == ButtonState.Released && fedExBigRect.Contains(mouseState.Position))
                {
                    exploded2 = true;
                    fedExBigSpeed.Y = 1;
                    ExplosionSound();
                    explosionRect = fedExBigRect;
                }

                if (fedExBigRect.Left >= window.Right)
                {
                    fedExBigRect.X = -300;
                    fedExBigRect.Y = 40;
                    fedExBigSpeed.Y = 0f;
                    exploded2 = false;

                }

                //Resolve Small FedEx Jet

                if (mouseState.LeftButton == ButtonState.Pressed && prevMouseState.LeftButton == ButtonState.Released && fedExSmallRect.Contains(mouseState.Position))
                {
                    exploded3 = true;
                    fedExSmallSpeed.Y = 1;
                    explosionRect = fedExSmallRect;
                    ExplosionSound();
                }

                if (fedExSmallRect.Left >= window.Right)
                {
                    fedExSmallRect.X = -300;
                    fedExSmallRect.Y = 210;
                    fedExSmallSpeed.Y = 0f;
                    exploded3 = false;
                }



            }


            else if (screen == Screen.Level2)
            {
                anthemSoundInstance.Stop();

                if (reset2)
                {
                    upsJetBigRect.X = 20;
                    upsJetBigRect.Y = 20;
                    fedExBigRect.X = 300;
                    fedExBigRect.Y = 40;
                    upsJetSmallRect.X = 40;
                    upsJetSmallRect.Y = 190;
                    fedExSmallRect.X = 80;
                    fedExSmallRect.Y = 210;
                    amazonBigRect.X = 20;
                    amazonBigRect.Y = 120;
                    amazonSmallRect.X = 40;
                    amazonSmallRect.Y = 160;
                    canBigRect.X = 5;
                    canBigRect.Y = 204;
                    dhlBigRect.X = 300;
                    dhlBigRect.Y = 204;
                    dhlSmallRect.X = 540;
                    dhlSmallRect.Y = 204;
                    canSmallRect.X = 540;
                    canSmallRect.Y = 160;

                    upsBigSpeed = new Vector2(2, 0);

                    fedExBigSpeed = new Vector2(1, 0);

                    canBigSpeed = new Vector2(3, 0);

                    dhlBigSpeed = new Vector2(2, 0);

                    amazonBigSpeed = new Vector2(3, 0);

                    exploded = false;
                    exploded1 = false;
                    exploded2 = false;
                    exploded3 = false;
                    exploded4 = false;
                    exploded5 = false;
                    exploded6 = false;
                    exploded7 = false;
                    exploded8 = false;
                    exploded9 = false;



                    reset2 = false;
                }





                upsJetSmallRect.X += (int)upsSmallSpeed.X;
                upsJetSmallRect.Y += (int)upsSmallSpeed.Y;

                upsJetBigRect.X += (int)upsBigSpeed.X;
                upsJetBigRect.Y += (int)upsBigSpeed.Y;


                fedExBigRect.X += (int)fedExBigSpeed.X;
                fedExBigRect.Y += (int)fedExBigSpeed.Y;

                fedExSmallRect.X += (int)fedExSmallSpeed.X;
                fedExSmallRect.Y += (int)fedExSmallSpeed.Y;

                canSmallRect.X += (int)canSmallSpeed.X;
                canSmallRect.Y += (int)canSmallSpeed.Y;

                canBigRect.X += (int)canBigSpeed.X;
                canBigRect.Y += (int)canBigSpeed.Y;

                dhlSmallRect.X += (int)dhlSmallSpeed.X;
                dhlSmallRect.Y += (int)dhlSmallSpeed.Y;

                dhlBigRect.X += (int)dhlBigSpeed.X;
                dhlBigRect.Y += (int)dhlBigSpeed.Y;

                amazonSmallRect.X += (int)amazonSmallSpeed.X;
                amazonSmallRect.Y += (int)amazonSmallSpeed.Y;

                amazonBigRect.X += (int)amazonBigSpeed.X;
                amazonBigRect.Y += (int)amazonBigSpeed.Y;

                // Resolve Big UPS Jet
                if (mouseState.LeftButton == ButtonState.Pressed && prevMouseState.LeftButton == ButtonState.Released && upsJetBigRect.Contains(mouseState.Position))
                {
                    exploded = true;
                    upsBigSpeed.Y = 1;
                    explosionRect = upsJetBigRect;

                    ExplosionSound();
                }
                if (upsJetBigRect.Left >= window.Right)
                {
                    upsJetBigRect.X = -300;
                    upsJetBigRect.Y = 20;
                    exploded = false;
                    upsBigSpeed.Y = 0f;
                }

                // Resolve Small UPS Jet
                if (mouseState.LeftButton == ButtonState.Pressed && prevMouseState.LeftButton == ButtonState.Released && upsJetSmallRect.Contains(mouseState.Position))
                {
                    exploded1 = true;
                    upsSmallSpeed.Y = 1;
                    explosionRect = upsJetSmallRect;
                    ExplosionSound();
                }

                if (upsJetSmallRect.Left >= window.Right)
                {
                    upsJetSmallRect.X = -300;
                    upsJetSmallRect.Y = 190;
                    exploded1 = false;
                    upsSmallSpeed.Y = 0f;

                }

                //Resolve Big CanPost Jet

                if (mouseState.LeftButton == ButtonState.Pressed && prevMouseState.LeftButton == ButtonState.Released && canBigRect.Contains(mouseState.Position))
                {
                    exploded4 = true;
                    canBigSpeed.Y = 1;
                    explosionRect = canBigRect;
                    ExplosionSound();
                    screen = Screen.FailedScreen;
                    missionFailed = true;
                }

                if (canBigRect.Left >= window.Right)
                {
                    canBigRect.X = -300;
                    canBigRect.Y = 204;
                    exploded4 = false;
                    canBigSpeed.Y = 0f;
                }

                //Resolve Small CanPost Jet

                if (mouseState.LeftButton == ButtonState.Pressed && prevMouseState.LeftButton == ButtonState.Released && canSmallRect.Contains(mouseState.Position))
                {
                    exploded5 = true;
                    canSmallSpeed.Y = 1;
                    explosionRect = canSmallRect;
                    ExplosionSound();
                    screen = Screen.FailedScreen;
                    missionFailed = true;
                }

                if (canSmallRect.Left >= window.Right)
                {
                    canSmallRect.X = -300;
                    canSmallRect.Y = 160;
                    canSmallSpeed.Y = 0f;
                    exploded5 = false;
                }

                //Resolve Big Amazon Jet

                if (mouseState.LeftButton == ButtonState.Pressed && prevMouseState.LeftButton == ButtonState.Released && amazonBigRect.Contains(mouseState.Position))
                {
                    exploded8 = true;
                    amazonBigSpeed.Y = 1;
                    explosionRect = amazonBigRect;
                    ExplosionSound();
                    screen = Screen.LoadingScreen2;
                    upsBigSpeed = new Vector2(6, 0);

                    upsSmallSpeed = new Vector2(7, 0);

                    fedExBigSpeed = new Vector2(4, 0);

                    fedExSmallSpeed = new Vector2(10, 0);

                    canBigSpeed = new Vector2(6, 0);

                    canSmallSpeed = new Vector2(10, 0);

                    dhlBigSpeed = new Vector2(6, 0);

                    dhlSmallSpeed = new Vector2(9, 0);

                    amazonBigSpeed = new Vector2(12, 0);

                    amazonSmallSpeed = new Vector2(12, 0);
                }

                if (amazonBigRect.Left >= window.Right)
                {
                    amazonBigRect.X = -300;
                    amazonBigRect.Y = 120;
                    amazonBigSpeed.Y = 0f;
                    exploded8 = false;
                }

                //Resolve Small Amazon Jet

                if (mouseState.LeftButton == ButtonState.Pressed && prevMouseState.LeftButton == ButtonState.Released && amazonSmallRect.Contains(mouseState.Position))
                {
                    exploded9 = true;
                    amazonSmallSpeed.Y = 1;
                    explosionRect = amazonSmallRect;
                    ExplosionSound();
                    screen = Screen.LoadingScreen2;
                    upsBigSpeed = new Vector2(6, 0);

                    upsSmallSpeed = new Vector2(7, 0);

                    fedExBigSpeed = new Vector2(4, 0);

                    fedExSmallSpeed = new Vector2(10, 0);

                    canBigSpeed = new Vector2(6, 0);

                    canSmallSpeed = new Vector2(10, 0);

                    dhlBigSpeed = new Vector2(6, 0);

                    dhlSmallSpeed = new Vector2(9, 0);

                    amazonBigSpeed = new Vector2(12, 0);

                    amazonSmallSpeed = new Vector2(12, 0);
                }

                if (amazonSmallRect.Left >= window.Right)
                {
                    amazonSmallRect.X = -300;
                    amazonSmallRect.Y = 160;
                    amazonSmallSpeed.Y = 0f;
                    exploded9 = false;
                }

                //Resolve DHL Big Jet

                if (mouseState.LeftButton == ButtonState.Pressed && prevMouseState.LeftButton == ButtonState.Released && dhlBigRect.Contains(mouseState.Position))
                {
                    exploded6 = true;
                    dhlBigSpeed.Y = 1;
                    ExplosionSound();
                    explosionRect = dhlBigRect;
                }

                if (dhlBigRect.Left >= window.Right)
                {
                    dhlBigRect.X = -300;
                    dhlBigRect.Y = 204;
                    dhlBigSpeed.Y = 0f;
                    exploded6 = false;
                }

                //Resolve DHL Small Jet

                if (mouseState.LeftButton == ButtonState.Pressed && prevMouseState.LeftButton == ButtonState.Released && dhlSmallRect.Contains(mouseState.Position))
                {
                    exploded7 = true;
                    dhlSmallSpeed.Y = 1;
                    ExplosionSound();
                    explosionRect = dhlSmallRect;
                }

                if (dhlSmallRect.Left >= window.Right)
                {
                    dhlSmallRect.X = -300;
                    dhlSmallRect.Y = 277;
                    dhlSmallSpeed.Y = 0f;
                    exploded7 = false;
                }

                //Resolve Big FedEx Jet

                if (mouseState.LeftButton == ButtonState.Pressed && prevMouseState.LeftButton == ButtonState.Released && fedExBigRect.Contains(mouseState.Position))
                {
                    exploded2 = true;
                    fedExBigSpeed.Y = 1;
                    ExplosionSound();
                    explosionRect = fedExBigRect;
                }

                if (fedExBigRect.Left >= window.Right)
                {
                    fedExBigRect.X = -300;
                    fedExBigRect.Y = 40;
                    fedExBigSpeed.Y = 0f;
                    exploded2 = false;

                }

                //Resolve Small FedEx Jet

                if (mouseState.LeftButton == ButtonState.Pressed && prevMouseState.LeftButton == ButtonState.Released && fedExSmallRect.Contains(mouseState.Position))
                {
                    exploded3 = true;
                    fedExSmallSpeed.Y = 1;
                    explosionRect = fedExSmallRect;
                    ExplosionSound();
                }

                if (fedExSmallRect.Left >= window.Right)
                {
                    fedExSmallRect.X = -300;
                    fedExSmallRect.Y = 210;
                    fedExSmallSpeed.Y = 0f;
                    exploded3 = false;
                }


            }



            else if (screen == Screen.Level3)
            {
                anthemSoundInstance.Stop();

                if (reset3)
                {
                    upsJetBigRect.X = 20;
                    upsJetBigRect.Y = 20;
                    fedExBigRect.X = 300;
                    fedExBigRect.Y = 40;
                    upsJetSmallRect.X = 40;
                    upsJetSmallRect.Y = 190;
                    fedExSmallRect.X = 80;
                    fedExSmallRect.Y = 210;
                    amazonBigRect.X = 20;
                    amazonBigRect.Y = 120;
                    amazonSmallRect.X = 40;
                    amazonSmallRect.Y = 160;
                    canBigRect.X = 5;
                    canBigRect.Y = 204;
                    dhlBigRect.X = 300;
                    dhlBigRect.Y = 204;
                    dhlSmallRect.X = 540;
                    dhlSmallRect.Y = 204;
                    canSmallRect.X = 540;
                    canSmallRect.Y = 160;

                    upsBigSpeed = new Vector2(2, 0);

                    fedExBigSpeed = new Vector2(1, 0);

                    canBigSpeed = new Vector2(3, 0);

                    dhlBigSpeed = new Vector2(2, 0);

                    amazonBigSpeed = new Vector2(3, 0);

                    exploded = false;
                    exploded1 = false;
                    exploded2 = false;
                    exploded3 = false;
                    exploded4 = false;
                    exploded5 = false;
                    exploded6 = false;
                    exploded7 = false;
                    exploded8 = false;
                    exploded9 = false;



                    reset3 = false;
                }


                

                upsJetSmallRect.X += (int)upsSmallSpeed.X;
                upsJetSmallRect.Y += (int)upsSmallSpeed.Y;

                upsJetBigRect.X += (int)upsBigSpeed.X;
                upsJetBigRect.Y += (int)upsBigSpeed.Y;


                fedExBigRect.X += (int)fedExBigSpeed.X;
                fedExBigRect.Y += (int)fedExBigSpeed.Y;

                fedExSmallRect.X += (int)fedExSmallSpeed.X;
                fedExSmallRect.Y += (int)fedExSmallSpeed.Y;

                canSmallRect.X += (int)canSmallSpeed.X;
                canSmallRect.Y += (int)canSmallSpeed.Y;

                canBigRect.X += (int)canBigSpeed.X;
                canBigRect.Y += (int)canBigSpeed.Y;

                dhlSmallRect.X += (int)dhlSmallSpeed.X;
                dhlSmallRect.Y += (int)dhlSmallSpeed.Y;

                dhlBigRect.X += (int)dhlBigSpeed.X;
                dhlBigRect.Y += (int)dhlBigSpeed.Y;

                amazonSmallRect.X += (int)amazonSmallSpeed.X;
                amazonSmallRect.Y += (int)amazonSmallSpeed.Y;

                amazonBigRect.X += (int)amazonBigSpeed.X;
                amazonBigRect.Y += (int)amazonBigSpeed.Y;


                // Resolve Big UPS Jet
                //if (mouseState.LeftButton == ButtonState.Pressed && prevMouseState.LeftButton == ButtonState.Released && upsJetBigRect.Contains(mouseState.Position))
                //{
                //    exploded = true;
                //    upsBigSpeed.Y = 1;
                //    explosionRect = upsJetBigRect;
                //    explosionSound.Play();

                //}
                //if (upsJetBigRect.Left >= window.Right)
                //{
                //    upsJetBigRect.X = -300;
                //    upsJetBigRect.Y = 20;
                //    exploded = false;
                //    upsBigSpeed.Y = 0f;
                //}

                // Resolve Small UPS Jet
                if (mouseState.LeftButton == ButtonState.Pressed && prevMouseState.LeftButton == ButtonState.Released && upsJetSmallRect.Contains(mouseState.Position))
                {
                    exploded1 = true;
                    upsSmallSpeed.Y = 1;
                    explosionRect = upsJetSmallRect;
                    ExplosionSound();
                }

                if (upsJetSmallRect.Left >= window.Right)
                {
                    
                    upsJetSmallRect.X = -300;
                    upsJetSmallRect.Y = 190;
                    exploded1 = false;
                    upsSmallSpeed.Y = 0f;
                    
                }

                ////Resolve Big CanPost Jet

                //if (mouseState.LeftButton == ButtonState.Pressed && prevMouseState.LeftButton == ButtonState.Released && canBigRect.Contains(mouseState.Position))
                //{
                //    exploded4 = true;
                //    canBigSpeed.Y = 1;
                //    explosionRect = canBigRect;
                //    explosionSound.Play();
                //    screen = Screen.FailedScreen;
                //}

                //if (canBigRect.Left >= window.Right)
                //{
                //    canBigRect.X = -300;
                //    canBigRect.Y = 204;
                //    exploded4 = false;
                //    canBigSpeed.Y = 0f;
                //}

                //Resolve Small CanPost Jet

                if (mouseState.LeftButton == ButtonState.Pressed && prevMouseState.LeftButton == ButtonState.Released && canSmallRect.Contains(mouseState.Position))
                {
                    exploded5 = true;
                    canSmallSpeed.Y = 1;
                    explosionRect = canSmallRect;
                    ExplosionSound();
                    screen = Screen.FailedScreen;
                    missionFailed = true;
                }

                if (canSmallRect.Left >= window.Right)
                {
                    
                    canSmallRect.X = -300;
                    canSmallRect.Y = 160;
                    canSmallSpeed.Y = 0f;
                    
                    exploded5 = false;
                }

                //Resolve Big Amazon Jet

                //if (mouseState.LeftButton == ButtonState.Pressed && prevMouseState.LeftButton == ButtonState.Released && amazonBigRect.Contains(mouseState.Position))
                //{
                //    exploded8 = true;
                //    amazonBigSpeed.Y = 1;
                //    explosionRect = amazonBigRect;
                //    explosionSound.Play();
                //    screen = Screen.LoadingScreen2;
                //    upsBigSpeed = new Vector2(6, 0);

                //    upsSmallSpeed = new Vector2(8, 0);

                //    fedExBigSpeed = new Vector2(4, 0);

                //    fedExSmallSpeed = new Vector2(8, 0);

                //    canBigSpeed = new Vector2(8, 0);

                //    canSmallSpeed = new Vector2(10, 0);

                //    dhlBigSpeed = new Vector2(6, 0);

                //    dhlSmallSpeed = new Vector2(8, 0);

                //    amazonBigSpeed = new Vector2(8, 0);
                //}

                //if (amazonBigRect.Left >= window.Right)
                //{
                //    amazonBigRect.X = -300;
                //    amazonBigRect.Y = 120;
                //    amazonBigSpeed.Y = 0f;
                //    exploded8 = false;
                //}

                //Resolve Small Amazon Jet

                if (mouseState.LeftButton == ButtonState.Pressed && prevMouseState.LeftButton == ButtonState.Released && amazonSmallRect.Contains(mouseState.Position))
                {
                    exploded9 = true;
                    amazonSmallSpeed.Y = 1;
                    explosionRect = amazonSmallRect;
                    ExplosionSound();
                    screen = Screen.Done;
                    upsBigSpeed = new Vector2(6, 0);

                    upsSmallSpeed = new Vector2(8, 0);

                    fedExBigSpeed = new Vector2(4, 0);

                    fedExSmallSpeed = new Vector2(8, 0);

                    canBigSpeed = new Vector2(8, 0);

                    canSmallSpeed = new Vector2(10, 0);

                    dhlBigSpeed = new Vector2(6, 0);

                    dhlSmallSpeed = new Vector2(8, 0);

                    amazonBigSpeed = new Vector2(8, 0);
                }

                if (amazonSmallRect.Left >= window.Right)
                {
                    
                    amazonSmallRect.X = -300;
                    amazonSmallRect.Y = 160;
                    amazonSmallSpeed.Y = 0f;
                    exploded9 = false;
                    
                }

                //Resolve DHL Big Jet

                //if (mouseState.LeftButton == ButtonState.Pressed && prevMouseState.LeftButton == ButtonState.Released && dhlBigRect.Contains(mouseState.Position))
                //{
                //    exploded6 = true;
                //    dhlBigSpeed.Y = 1;
                //    explosionSound.Play();
                //    explosionRect = dhlBigRect;
                //}

                //if (dhlBigRect.Left >= window.Right)
                //{
                //    dhlBigRect.X = -300;
                //    dhlBigRect.Y = 204;
                //    dhlBigSpeed.Y = 0f;
                //    exploded6 = false;
                //}

                //Resolve DHL Small Jet

                if (mouseState.LeftButton == ButtonState.Pressed && prevMouseState.LeftButton == ButtonState.Released && dhlSmallRect.Contains(mouseState.Position))
                {
                    exploded7 = true;
                    dhlSmallSpeed.Y = 1;
                    ExplosionSound();
                    explosionRect = dhlSmallRect;
                }

                if (dhlSmallRect.Left >= window.Right)
                {
                    
                    dhlSmallRect.X = -300;
                    dhlSmallRect.Y = 277;
                    dhlSmallSpeed.Y = 0f;
                    exploded7 = false;
                    
                }

                ////Resolve Big FedEx Jet

                //if (mouseState.LeftButton == ButtonState.Pressed && prevMouseState.LeftButton == ButtonState.Released && fedExBigRect.Contains(mouseState.Position))
                //{
                //    exploded2 = true;
                //    fedExBigSpeed.Y = 1;
                //    explosionSound.Play();
                //    explosionRect = fedExBigRect;
                //}

                //if (fedExBigRect.Left >= window.Right)
                //{
                //    fedExBigRect.X = -300;
                //    fedExBigRect.Y = 40;
                //    fedExBigSpeed.Y = 0f;
                //    exploded2 = false;

                //}

                //Resolve Small FedEx Jet

                if (mouseState.LeftButton == ButtonState.Pressed && prevMouseState.LeftButton == ButtonState.Released && fedExSmallRect.Contains(mouseState.Position))
                {
                    exploded3 = true;
                    fedExSmallSpeed.Y = 1;
                    explosionRect = fedExSmallRect;
                    ExplosionSound();
                }

                if (fedExSmallRect.Left >= window.Right)
                {
                    
                    fedExSmallRect.X = -300;
                    fedExSmallRect.Y = 210;
                    fedExSmallSpeed.Y = 0f;
                    exploded3 = false;
                    
                }

            }



            else if (screen == Screen.FailedScreen)
            {
                explosionSoundInstance.Stop();
                

                if (missionFailed)
                {
                    failedSoundInstance.Play();
                    missionFailed = false;
                }
                if (keyboardState.IsKeyDown(Keys.R) && prevKeyboardState.IsKeyUp(Keys.R))
                {
                    screen = Screen.LevelSelect;
                }
            }


            else if (screen == Screen.Done)
            {
                explosionSoundInstance.Stop();
                anthemSoundInstance.Play();

                if (keyboardState.IsKeyDown(Keys.E) && prevKeyboardState.IsKeyUp(Keys.E))
                {
                    screen = Screen.LevelSelect;
                }
            }



            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();

            if (screen == Screen.LevelSelect)
            {
                
                _spriteBatch.Draw(homeScreentexture, gameHomeRect, Color.White);

                _spriteBatch.Draw(introJetTexture, introJetRect, Color.White);

                _spriteBatch.DrawString(textFont, " ", new Vector2(400, 300), Color.Black); //fix the background w/ Chat to get rid of the plane and title

                IsMouseVisible = true;
            }


            if (screen == Screen.TipScreen) 
            {
                _spriteBatch.DrawString(textFont, "Tip: Canada Post are friendly-Don't shoot them! \n\n Shoot Amazon Jets to go to the next level. \n\n Click E To Continue!", new Vector2(44, 300), Color.White);
                _spriteBatch.Draw(canJetSmallTexture, tutorialCanRect, Color.White);
                _spriteBatch.Draw(amazonJetSmallTexture, tutorialAmzRect, Color.White);
            }

            if (screen == Screen.LoadingScreen1) 
            {
                _spriteBatch.DrawString(textFont, "Press E to start Level 2!", new Vector2(300, 300), Color.White); //was 400
                _spriteBatch.Draw(introJetTexture, introJetRect, Color.White);
                IsMouseVisible = true;
            }    

            if (screen == Screen.LoadingScreen2) 
            {
                _spriteBatch.DrawString(textFont, "Press E to start Level 3!", new Vector2(300, 300), Color.White);
                _spriteBatch.Draw(introJetTexture, introJetRect, Color.White);
                IsMouseVisible = true;
            }

            if (screen == Screen.Level1) 
            {
                _spriteBatch.DrawString(textFont, "Take out All Enemy Planes!", new Vector2(20, 20), Color.White);

                
                
                
                
                _spriteBatch.Draw(upsJetTextureBig, upsJetBigRect, Color.White);
                if (exploded)
                {
                    _spriteBatch.Draw(explosionTexture, upsJetBigRect, Color.White);

                    

                }
               
                _spriteBatch.Draw(fedExJetTextureBig, fedExBigRect, Color.White);
                if (exploded2)
                {
                    _spriteBatch.Draw(explosionTexture, fedExBigRect, Color.White);

                    
                }

                _spriteBatch.Draw(canJetBigTexture, canBigRect, Color.White);
                if (exploded4)
                {
                    _spriteBatch.Draw(explosionTexture, canBigRect, Color.White);
                    
                }

                _spriteBatch.Draw(dhlJetBigTexture, dhlBigRect, Color.White);
                if(exploded6)
                {
                    _spriteBatch.Draw(explosionTexture, dhlBigRect, Color.White);
                    
                }

                _spriteBatch.Draw(amazonJetBigTexture, amazonBigRect, Color.White);
                if(exploded8)
                {
                    _spriteBatch.Draw(explosionTexture, amazonBigRect, Color.White);
                    
                }

                _spriteBatch.Draw(cockpitTexture, cockpitRect, Color.White);

                _spriteBatch.Draw(crossHairTexture, crossHairRect, Color.White);


            }

            if(screen == Screen.Level2) 
            {
                _spriteBatch.DrawString(textFont, "Level 2: Take out All Enemy Planes!", new Vector2(20, 20), Color.White);
                _spriteBatch.Draw(upsJetTextureBig, upsJetBigRect, Color.White);
                if (exploded)
                {
                    _spriteBatch.Draw(explosionTexture, upsJetBigRect, Color.White);
                    
                }
                
                _spriteBatch.Draw(upsJetTextureSmall, upsJetSmallRect, Color.White);
                if (exploded1)
                {
                    _spriteBatch.Draw(explosionTexture, upsJetSmallRect, Color.White);
                    
                }

                _spriteBatch.Draw(fedExJetTextureBig, fedExBigRect, Color.White);
                if (exploded2)
                {
                    _spriteBatch.Draw(explosionTexture, fedExBigRect, Color.White);
                    
                }
                
                _spriteBatch.Draw(fedExJetTextureSmall, fedExSmallRect, Color.White);
                if (exploded3)
                {
                    _spriteBatch.Draw(explosionTexture, fedExSmallRect, Color.White);
                    
                }

                _spriteBatch.Draw(canJetBigTexture, canBigRect, Color.White);
                if (exploded4)
                {
                    _spriteBatch.Draw(explosionTexture, canBigRect, Color.White);
                    
                }

                _spriteBatch.Draw(canJetSmallTexture, canSmallRect, Color.White);
                if (exploded5)
                {
                    _spriteBatch.Draw(explosionTexture, canSmallRect, Color.White);
                    
                }

                _spriteBatch.Draw(dhlJetBigTexture, dhlBigRect, Color.White);
                if (exploded6)
                {
                    _spriteBatch.Draw(explosionTexture, dhlBigRect, Color.White);
                    
                }

                _spriteBatch.Draw(dhlJetSmallTexture, dhlSmallRect, Color.White);
                if (exploded7)
                {
                    _spriteBatch.Draw(explosionTexture, dhlSmallRect, Color.White);
                    
                }

                _spriteBatch.Draw(amazonJetBigTexture, amazonBigRect, Color.White);
                if (exploded8)
                {
                    _spriteBatch.Draw(explosionTexture, amazonBigRect, Color.White);
                    
                }
                
                _spriteBatch.Draw(amazonJetSmallTexture, amazonSmallRect, Color.White);
                if (exploded9)
                {
                    _spriteBatch.Draw(explosionTexture, amazonSmallRect, Color.White);
                    
                }

                _spriteBatch.Draw(cockpitTexture, cockpitRect, Color.White);
                _spriteBatch.Draw(crossHairTexture, crossHairRect, Color.White);
            }

            if (screen == Screen.FailedScreen) 
            {
                _spriteBatch.DrawString(textFont, "You Failed! Press R to Go Back To Menu!", new Vector2(200, 300), Color.White);
                _spriteBatch.Draw(introJetTexture, introJetRect, Color.White);
                
                

                IsMouseVisible = true;
            }

            if (screen == Screen.Done) 
            {
                _spriteBatch.DrawString(textFont, "Mission Complete! \n\n Press E to Go Back To Menu!", new Vector2(200, 300), Color.White);
                _spriteBatch.Draw(happyTexture, happyrect, Color.White);
                _spriteBatch.Draw(victoryTexture, victoryRect, Color.White);

                IsMouseVisible = true;
            }

            if (screen == Screen.Level3) 
            {
                _spriteBatch.DrawString(textFont, "Level 3: Take out All Enemy Planes!", new Vector2(20, 20), Color.White);

                _spriteBatch.Draw(upsJetTextureSmall, upsJetSmallRect, Color.White);
                if (exploded1)
                {
                    _spriteBatch.Draw(explosionTexture, upsJetSmallRect, Color.White);
                    
                }

                _spriteBatch.Draw(fedExJetTextureSmall, fedExSmallRect, Color.White);
                if (exploded3)
                {
                    _spriteBatch.Draw(explosionTexture, fedExSmallRect, Color.White);
                    
                }

                _spriteBatch.Draw(canJetSmallTexture, canSmallRect, Color.White);
                if (exploded5)
                {
                    _spriteBatch.Draw(explosionTexture, canSmallRect, Color.White);
                    
                }

                _spriteBatch.Draw(dhlJetSmallTexture, dhlSmallRect, Color.White);
                if (exploded7)
                {
                    _spriteBatch.Draw(explosionTexture, dhlSmallRect, Color.White);
                    
                }

                _spriteBatch.Draw(amazonJetSmallTexture, amazonSmallRect, Color.White);
                if (exploded9)
                {
                    _spriteBatch.Draw(explosionTexture, amazonSmallRect, Color.White);
                    
                }

                _spriteBatch.Draw(cockpitTexture, cockpitRect, Color.White);
                _spriteBatch.Draw(crossHairTexture, crossHairRect, Color.White);
            }


            //Create the explosion, and how to detect when a plane was shot  :D

            _spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }

        public void ExplosionSound() 
        {
            explosionSoundInstance.Stop();
            explosionSoundInstance.Play();
        }
    }
}
