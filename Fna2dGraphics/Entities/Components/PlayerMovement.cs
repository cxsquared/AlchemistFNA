using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fna2dGraphics.Entities.Components
{
    class PlayerMovement
    {
        public float Velocity = 0;
        public float Speed = 5;
        public float MaxVelocity = 10;
        public float Friction = 0.9f;
    }
}
