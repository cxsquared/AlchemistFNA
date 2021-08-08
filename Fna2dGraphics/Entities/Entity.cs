using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Fna2dGraphics.Entities
{
    class Entity : IEntity
    {
        Vector2 _location;
        public Vector2 Location => _location;

        public float Rotation { get; set; }
        public float Scale { get; set; }
        public Color Color { get; set; }

        Vector2 _sourceOrigin;
        public Vector2 SourceOrigin => _sourceOrigin;
        protected Rectangle _sourceLocation;
        public Rectangle SourceLocation => _sourceLocation;
        Texture2D _sourceTexture;
        public Texture2D SourceTexture => _sourceTexture;

        public Entity(float x, float y, Color color, float rotation = 0, float scale = 1)
        {
            _location = new Vector2(x, y);
            Rotation = rotation;
            Scale = scale;
            Color = color;
        }

        public void Move(float dx, float dy)
        {
            _location.X += dx;
            _location.Y += dy;
        }

        public virtual void Draw(GameTime gameTime, SpriteBatch batch, float layer = 1)
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

        public virtual void LoadGraphic(string asset, Rectangle sourceLocation, Vector2 sourceOrigin)
        {
            _sourceTexture = ContentManagerProvider.Content.Load<Texture2D>(asset);
            _sourceLocation = sourceLocation;
            _sourceOrigin = sourceOrigin;
        }

        public virtual void Update(GameTime gameTime)
        {
        }

        public void SetLocation(float x, float y)
        {
            _location.X = x;
            _location.Y = y;
        }
    }
}
