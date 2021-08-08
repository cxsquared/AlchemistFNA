namespace Fna2dGraphics.Entities.Animation
{
    class Animation : IAnimation
    {
        public string Name { get; }
        int _fps;
        public int FPS
        {
            get
            {
                return _fps;
            }
            set
            {
                _msPerFrame = FpsToMs(value);
                _fps = value;
            }
        }

        int _msPerFrame;
        public int MsPerFrame => _msPerFrame;

        public bool Finished { get; set; }
        public int[] Frames { get; set; }
        public bool Looped { get; set; }
        public int CurrentFrame { get; set; }

        public Animation(string name, int frameRate, int[] frames, bool looped)
        {
            Name = name;
            FPS = frameRate;
            Frames = frames;
            Looped = looped;
        }

        int FpsToMs(int fps)
        {
            return (int)(1.0f / fps * 1000.0f / 1.0f);
        }

    }
}
