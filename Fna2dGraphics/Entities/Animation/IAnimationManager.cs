using Microsoft.Xna.Framework;

namespace Fna2dGraphics.Entities.Animation
{
    interface IAnimationManager
    {
        IAnimatedEntity Parent { get; }
        IAnimation CurrentAnimation { get; set; }
        bool Finished { get; }
        int CurrentFrame { get; }
        void Add(IAnimation animation);

        void Play(string animationName);
        void Stop();
        void Pause();
        void Resume();

        void Update(GameTime gameTime);
    }
}
