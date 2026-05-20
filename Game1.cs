using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

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

        MouseState mouseState, prevMouseState;

        Texture2D introJetTexture, cockpitTexture, upsJetTextureBig, upsJetTextureSmall, fedExJetTextureBig, fedExJetTextureSmall, explosionTexture;

        Rectangle upsJetBigRect, upsJetSmallRect, fedExBigRect, fedExSmallRect, introJetRect, window, cockpitRect;

        SpriteFont textFont;

        bool level1 = false, level2 = false, level3 = false;

        


        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

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

            fedExBigRect = new Rectangle(20, 40, 300, 98);  //   Was:  150, 49 --- Now: 300, 98

            upsJetSmallRect = new Rectangle (40, 160, 100, 32);

            fedExSmallRect = new Rectangle(20, 80, 100, 32);

            introJetRect = new Rectangle(200, 100, 400, 136);

            cockpitRect = new Rectangle(0, 10, 1000, 710);  // Smaller: 0, 20, 500, 355   Bigger: 0, 10, 1000, 710


            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            introJetTexture = Content.Load<Texture2D>("IntroJet");

            cockpitTexture = Content.Load<Texture2D>("CockpitTransparentDone");

            upsJetTextureBig = Content.Load<Texture2D>("UPSJetBig");

            upsJetTextureSmall = Content.Load<Texture2D>("UPSJetSmall");

            fedExJetTextureBig = Content.Load<Texture2D>("fedExJetBig");

            fedExJetTextureSmall = Content.Load<Texture2D>("fedExJetSmall");

            explosionTexture = Content.Load<Texture2D>("explosion");

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            prevMouseState = mouseState;
           
            mouseState = Mouse.GetState();
            
            this.Window.Title = "" + mouseState.X + "," + mouseState.Y; 

            

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

            _spriteBatch.Draw(upsJetTextureSmall, upsJetSmallRect, Color.White);

            _spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
