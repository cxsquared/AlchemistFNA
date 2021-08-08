using Fna2dGraphics.Entities;
using Fna2dGraphics.Entities.Animation;
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
        AnimatedEntity runner;

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
                500, 500,
                Color.White);

            snowmanTwo = new Entity(
                400, 400,
                Color.Plum,
                0.0f,
                0.5f);

            runner = new AnimatedEntity(200, 200, Color.White);
            runner.AnimationManager.Add(new Animation(
                "run",
                20,
                new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 },
                true));
            runner.AnimationManager.Play("run");

            base.Initialize();
        }

        protected override void LoadContent()
        {
            // Load Textures, sounds, etc
            spriteBatch = new SpriteBatch(GraphicsDevice);

            var snowmanSourceLocation = new Rectangle(0, 128, 256, 256);
            var snowmanSourceOrigin = new Vector2(128, 192);
            var snowAssets = "snow_assets";

            snowmanOne.LoadGraphic(snowAssets, snowmanSourceLocation, snowmanSourceOrigin);
            snowmanTwo.LoadGraphic(snowAssets, snowmanSourceLocation, snowmanSourceOrigin);

            runner.LoadGraphic("run_cycle", new Rectangle(0, 0, 128, 128), new Vector2(0, 0));

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
                runner.Move(-1, 0);

            if (Keyboard.GetState().IsKeyDown(Keys.Right))
                runner.Move(1, 0);

            if (Keyboard.GetState().IsKeyDown(Keys.Up))
                runner.Move(0, -1);

            if (Keyboard.GetState().IsKeyDown(Keys.Down))
                runner.Move(0, 1);

            runner.Update(gameTime);

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
            runner.Draw(gameTime, spriteBatch, CalculateDepth(runner, 720));

            spriteBatch.End();

            base.Draw(gameTime);
        }

        float CalculateDepth(Entity entity, float screenHeight)
        {
            return entity.Location.Y / screenHeight;
        }
    }
}
