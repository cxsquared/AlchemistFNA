using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Fna2dGraphics.Entities.Components
{
    class Renderable
    {
        public long TransformId;
        public Texture2D Texture;
        public Rectangle TextureRectangle;
        public Color Color;
        public Vector2 Origin;
        public SpriteEffects Effect;
        public float Layer;
    }
}
