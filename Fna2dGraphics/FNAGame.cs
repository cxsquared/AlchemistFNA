using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Fna2dGraphics
{
    class FNAGame : Game
    {
        static void Main(string[] args)
        {
            using (var game = new FNAGame())
            {
                game.Run();
            }
        }

        public static FNAGame Me;
        readonly GraphicsDeviceManager graphis;

        SpriteBatch spriteBatch;

        Entity snowmanOne;
        Entity snowmanTwo;

        private FNAGame()
        {
            Me = this;

            graphis = new GraphicsDeviceManager(this)
            {
                // TODO: Change this to a config
                PreferredBackBufferWidth = 1280,
                PreferredBackBufferHeight = 720,
                IsFullScreen = false,
                SynchronizeWithVerticalRetrace = true
            };

            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            /* This is a nice place to start up the engine, after
             * loading configuration stuff in the constructor
             */
            snowmanOne = new Entity(
                new Vector2(500, 500),
                Color.White);

            snowmanTwo = new Entity(
                new Vector2(400, 400),
                Color.Plum,
                0.0f,
                0.5f);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            // Load Textures, sounds, etc
            spriteBatch = new SpriteBatch(GraphicsDevice);

            var snowmanSourceLocation = new Rectangle(0, 128, 256, 256);
            var snowmanSourceOrigin = new Vector2(128, 192);
            var snowAssets = "snow_assets";

            snowmanOne.Load(snowAssets, snowmanSourceLocation, snowmanSourceOrigin);
            snowmanTwo.Load(snowAssets, snowmanSourceLocation, snowmanSourceOrigin);

            base.LoadContent();
        }

        protected override void UnloadContent()
        {
            // Clean up stuff
            base.UnloadContent();
        }

        protected override void Update(GameTime gameTime)
        {
            // Game Logic (DO NOT RENDER HERE)
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            if (Keyboard.GetState().IsKeyDown(Keys.Left))
                snowmanTwo.Move(-1, 0);

            if (Keyboard.GetState().IsKeyDown(Keys.Right))
                snowmanTwo.Move(1, 0);

            if (Keyboard.GetState().IsKeyDown(Keys.Up))
                snowmanTwo.Move(0, -1);

            if (Keyboard.GetState().IsKeyDown(Keys.Down))
                snowmanTwo.Move(0, 1);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            // Rendering only, no logic
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.AlphaBlend);

            //Create a loop of draw commands
            snowmanOne.Draw(gameTime, spriteBatch, CalculateDepth(snowmanOne, 720));
            snowmanTwo.Draw(gameTime, spriteBatch, CalculateDepth(snowmanTwo, 720));

            spriteBatch.End();

            base.Draw(gameTime);
        }

        float CalculateDepth(Entity entity, float screenHeight)
        {
            return entity.Location.Y / screenHeight;
        }
    }
}
