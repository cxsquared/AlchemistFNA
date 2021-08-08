using Microsoft.Xna.Framework;

namespace Fna2dGraphics.Entities.Animation
{
    interface IAnimation
    {
        string Name { get; }
        int FPS { get; set; }
        int MsPerFrame { get; }
        bool Finished { get; set; }
        int[] Frames { get; set; }
        bool Looped { get; set; }
        int CurrentFrame { get; set; }
    }
}
