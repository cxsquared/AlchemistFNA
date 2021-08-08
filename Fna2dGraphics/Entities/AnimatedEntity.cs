using Fna2dGraphics.Entities.Animation;
using Microsoft.Xna.Framework;

namespace Fna2dGraphics.Entities
{
    class AnimatedEntity : Entity, IAnimatedEntity
    {
        public IAnimationManager AnimationManager { get; }

        public AnimatedEntity(float x, float y, Color color, float rotation = 0, float scale = 1)
            : base(x, y, color, rotation, scale)
        {
            AnimationManager = new AnimationManager(this);
        }

        public override void Update(GameTime gameTime)
        {
            AnimationManager.Update(gameTime);
            base.Update(gameTime);
        }

        public void SetAnimationFrame(int frame)
        {
            _sourceLocation.X = SourceLocation.Width * frame;
        }
    }
}
