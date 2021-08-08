using Microsoft.Xna.Framework.Content;
using System;

namespace Fna2dGraphics
{
    static class ContentManagerProvider
    {
        static ContentManager _content;
        public static ContentManager Content
        {
            get
            {
                if (_content == null)
                    _content = FNAGame.Me.Content;

                return _content;
            }
            set
            {
                if (_content != null)
                    throw new ArgumentException("Content cannot be set more than once");

                _content = value;
            }
        }
    }
}
