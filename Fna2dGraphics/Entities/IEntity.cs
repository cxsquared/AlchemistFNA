using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Fna2dGraphics.Entities
{
    interface IEntity
    {
        Vector2 Location { get; }
        float Rotation { get; set; }
        float Scale { get; set; }
        Color Color { get; set; }

        Vector2 SourceOrigin { get; }
        Rectangle SourceLocation { get; }
        Texture2D SourceTexture { get; }

        void SetLocation(float x, float y);
        void Move(float x, float y);
        void Update(GameTime gameTime);

        void Draw(GameTime gameTime, SpriteBatch batch, float layer);
        void LoadGraphic(string asset, Rectangle sourceLocation, Vector2 origin);
    }
}
