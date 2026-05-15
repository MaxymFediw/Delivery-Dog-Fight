using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Delivery_Dog_Fight
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        //   Delivery Dogfight
        //   Maxym Fediw

        MouseState mouseState, prevMouseState;

        Texture2D introJetTexture, cockpitTexture, upsJetTexture, fedExJetTexture, explosionTexture;

        Rectangle upsJetBigRect, upsJetSmallRect, fedExBigRect, fedExSmallRect, introJetRect, window;

        SpriteFont textFont;

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
            window = new Rectangle(0, 0, 500, 355);

            _graphics.PreferredBackBufferHeight = window.Height;
            _graphics.PreferredBackBufferWidth = window.Width;
            _graphics.ApplyChanges();

            upsJetBigRect = new Rectangle(20, 20, 150, 49);

            fedExBigRect = new Rectangle(20, 40, 150, 49);

            upsJetSmallRect = new Rectangle (20, 60, 100, 32);

            fedExSmallRect = new Rectangle(20, 80, 100, 32);

            introJetRect = new Rectangle(200, 100, 400, 136);


            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
