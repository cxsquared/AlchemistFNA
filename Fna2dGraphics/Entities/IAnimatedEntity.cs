using Fna2dGraphics.Entities.Animation;

namespace Fna2dGraphics.Entities
{
    interface IAnimatedEntity : IEntity
    {
        IAnimationManager AnimationManager { get; }
        void SetAnimationFrame(int frame);
    }
}
