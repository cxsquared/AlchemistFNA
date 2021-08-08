using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace Fna2dGraphics.Entities.Animation
{
    class AnimationManager : IAnimationManager
    {
        public IAnimatedEntity Parent { get; }
        public IAnimation CurrentAnimation { get; set; }
        public bool Finished => CurrentAnimation?.Finished ?? false;
        public int CurrentFrame => CurrentAnimation?.CurrentFrame ?? -1;

        Dictionary<string, IAnimation> animations = new Dictionary<string, IAnimation>();
        bool playing = false;

        int elapsedMs;


        public AnimationManager(IAnimatedEntity parent)
        {
            Parent = parent;
        }

        public void Add(IAnimation animation)
        {
            animations.Add(animation.Name, animation);
        }

        public void Play(string animationName)
        {
            IAnimation anim;
            if (!animations.TryGetValue(animationName, out anim))
                throw new ArgumentException($"Animation {animationName} not loaded");

            CurrentAnimation = anim;
            playing = true;
        }

        public void Stop()
        {
            playing = false;
            CurrentAnimation = null;
        }

        public void Pause()
        {
            playing = false;
        }

        public void Resume()
        {
            playing = true;
        }

        public void Update(GameTime gameTime)
        {
            if (CurrentAnimation == null && !playing)
                return;

            elapsedMs += gameTime.ElapsedGameTime.Milliseconds;

            if (elapsedMs >= CurrentAnimation.MsPerFrame)
            {
                CurrentAnimation.Finished = false;
                CurrentAnimation.CurrentFrame++;
                elapsedMs -= CurrentAnimation.MsPerFrame;

                if (CurrentAnimation.CurrentFrame >= CurrentAnimation.Frames.Length)
                {
                    CurrentAnimation.Finished = true;

                    if (CurrentAnimation.Looped)
                        CurrentAnimation.CurrentFrame = 0;
                }

                Parent.SetAnimationFrame(CurrentAnimation.Frames[CurrentAnimation.CurrentFrame]);
            }
        }

    }
}
