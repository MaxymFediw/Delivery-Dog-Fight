using Microsoft.Xna.Framework;
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
        Level2,
        Level3,
        Done
    }
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        //   Delivery Dogfight
        //   Maxym Fediw

        Random generator1, generator2, generator3, generator4, generator5, generator6, generator7, generator8, generator9, generator10;

        MouseState mouseState, prevMouseState;

        Texture2D introJetTexture, crossHairTexture, cockpitTexture, upsJetTextureBig, upsJetTextureSmall, fedExJetTextureBig, fedExJetTextureSmall, canJetSmallTexture, canJetBigTexture, dhlJetBigTexture, dhlJetSmallTexture, amazonJetSmallTexture, amazonJetBigTexture, explosionTexture;

        Rectangle upsJetBigRect, crossHairRect, upsJetSmallRect, fedExBigRect, fedExSmallRect, canSmallRect, canBigRect, amazonSmallRect, amazonBigRect, dhlSmallRect, dhlBigRect, introJetRect, window, quitRect, cockpitRect;

        SpriteFont textFont;

        Vector2 upsSmallSpeed, upsBigSpeed, fedExSmallSpeed, fedExBigSpeed, amazonBigSpeed, amazonSmallSpeed, canSmallSpeed, canBigSpeed, dhlSmallSpeed, dhlBigSpeed;

        bool level1 = false, level2 = false, level3 = false;

        


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

            upsJetBigRect = new Rectangle(20, 20, 300, 98);

            fedExBigRect = new Rectangle(300, 40, 300, 98);  //   Was: 150, 49 ---> Now: 300, 98

            upsJetSmallRect = new Rectangle (40, 160, 100, 32);

            fedExSmallRect = new Rectangle(80, 210, 100, 32);

            introJetRect = new Rectangle(200, 100, 500, 144);

            cockpitRect = new Rectangle(0, 10, 1000, 710);  // Smaller: 0, 20, 500, 355   Bigger: 0, 10, 1000, 710

            quitRect = new Rectangle(431, 673, 123, 29); //Click "Eject" to end early.

            canBigRect = new Rectangle(5, 204, 300, 86);

            dhlBigRect = new Rectangle(300, 204, 300, 96); 

            dhlSmallRect = new Rectangle(540, 204, 100, 32);


            canSmallRect = new Rectangle(540, 160, 100, 29);

            //crossHairRect = new Rectangle(mouseState.X, mouseState.Y, 39, 50);

            //if (level1) 
            //{

            //    upsBigSpeed = new Vector2(0, 2);
            //    upsSmallSpeed = new Vector2(0, 2);

            //    fedExBigSpeed = new Vector2(0, 2);
            //    fedExSmallSpeed = new Vector2(0, 2);
            //}

            upsBigSpeed = new Vector2(6, 0);
            upsSmallSpeed = new Vector2(2, 0);

            fedExBigSpeed = new Vector2(1, 0);     //Play around with these speeds to make the game more fun and challenging!
            fedExSmallSpeed = new Vector2(3, 0);

            canSmallSpeed = new Vector2(4, 0);
            canBigSpeed = new Vector2(5, 0);

            dhlSmallSpeed = new Vector2(3, 0);
            dhlBigSpeed = new Vector2(4, 0);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            introJetTexture = Content.Load<Texture2D>("canadaPostIntro");

            cockpitTexture = Content.Load<Texture2D>("CockpitTransparentDone");

            upsJetTextureBig = Content.Load<Texture2D>("UPSJetBig");

            upsJetTextureSmall = Content.Load<Texture2D>("UPSJetSmall");

            fedExJetTextureBig = Content.Load<Texture2D>("fedExJetBig");

            fedExJetTextureSmall = Content.Load<Texture2D>("fedExJetSmall");

            explosionTexture = Content.Load<Texture2D>("explosion");

            canJetBigTexture = Content.Load<Texture2D>("canadaPostBig");

            crossHairTexture = Content.Load<Texture2D>("crosshairTransparent");

            canJetSmallTexture = Content.Load<Texture2D>("canadaPostSmall");

            dhlJetBigTexture = Content.Load<Texture2D>("dhlJetBig");

            dhlJetSmallTexture = Content.Load<Texture2D>("DHLJetSmall");

            textFont = Content.Load<SpriteFont>("textFont");

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            prevMouseState = mouseState;
           
            mouseState = Mouse.GetState();

            crossHairRect = new Rectangle(mouseState.X - 39, mouseState.Y - 50, 39, 50);

            this.Window.Title = "" + mouseState.X + "," + mouseState.Y;

            upsJetSmallRect.X += (int)upsSmallSpeed.X;

            upsJetBigRect.X += (int)upsBigSpeed.X;

            fedExBigRect.X += (int)fedExBigSpeed.X;

            fedExSmallRect.X += (int)fedExSmallSpeed.X;

            canSmallRect.X += (int)canSmallSpeed.X;

            canBigRect.X += (int)canBigSpeed.X;

            dhlSmallRect.X += (int)dhlSmallSpeed.X;

            dhlBigRect.X += (int)dhlBigSpeed.X;


            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();

            _spriteBatch.Draw(cockpitTexture, cockpitRect, Color.White);

            _spriteBatch.Draw(upsJetTextureBig, upsJetBigRect, Color.White);

            _spriteBatch.Draw(upsJetTextureSmall, upsJetSmallRect, Color.White);

            _spriteBatch.Draw(fedExJetTextureSmall, fedExSmallRect, Color.White);

            _spriteBatch.Draw(fedExJetTextureBig, fedExBigRect, Color.White);

            _spriteBatch.Draw(crossHairTexture, crossHairRect, Color.White);

            _spriteBatch.Draw(canJetBigTexture, canBigRect, Color.White);

            _spriteBatch.Draw(canJetSmallTexture, canSmallRect, Color.White);

            _spriteBatch.Draw(dhlJetBigTexture, dhlBigRect, Color.White);

            _spriteBatch.Draw(dhlJetSmallTexture, dhlSmallRect, Color.White);

            /* _spriteBatch.DrawString(textFont, ("Test"), new Vector2 (20, 20), Color.White);  */   // fix this - "textFont" is bugging


            _spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
