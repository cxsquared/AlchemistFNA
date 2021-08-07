using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Fna2dGraphics
{
    class Entity 
    {
        Vector2 _location;
        public Vector2 Location
        {
            get
            {
                return _location;
            }
        }

        public float Rotation { get; set; }
        public float Scale { get; set; }
        public Color Color { get; set; }

        Vector2 SourceOrigin { get; set; }
        Rectangle SourceLocation { get; set; }
        Texture2D SourceTexture { get; set; }

        public Entity(Vector2 location, Color color, float rotation = 0, float scale = 1)
        {
            _location = location;
            Rotation = rotation;
            Scale = scale;
            Color = color;
        }

        public void Move(float dx, float dy)
        {
            _location.X += dx;
            _location.Y += dy;
        }

        public void Teleport(float x, float y)
        {
            _location.X = x;
            _location.Y = y;
        }

        public void Draw(GameTime gameTime, SpriteBatch batch, float layer = 1)
        {
            batch.Draw(SourceTexture,
                Location,
                SourceLocation,
                Color,
                Rotation,
                SourceOrigin,
                Scale,
                SpriteEffects.None,
                layer);
        }

        public void Load(string asset, Rectangle sourceLocation, Vector2 origin)
        {
            SourceTexture = FNAGame.Me.Content.Load<Texture2D>("snow_assets");
            SourceLocation = sourceLocation;
            SourceOrigin = origin;
        }

        public void Update(GameTime gameTime)
        {
        }
    }
}
