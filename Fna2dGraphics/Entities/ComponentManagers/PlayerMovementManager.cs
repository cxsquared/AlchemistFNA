using Fna2dGraphics.Entities.Components;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace Fna2dGraphics.Entities.ComponentManagers
{
    class PlayerMovementManager
    {
        readonly Dictionary<long, PlayerMovement> PlayerMovements = new Dictionary<long, PlayerMovement>();
        readonly HashSet<long> MovingEntities = new HashSet<long>();
        readonly TransformManager TransformManager;
        readonly PressedKeyInputManager PressedKeyInputManager;

        public PlayerMovementManager(TransformManager tm, PressedKeyInputManager pkim)
        {
            TransformManager = tm;
            PressedKeyInputManager = pkim;
        }

        public void Insert(long id, PlayerMovement movement)
        {
            PlayerMovements.Add(id, movement);
        }

        public void Update(GameTime gt)
        {
            var pressedKeys = PressedKeyInputManager.GetAll;


            foreach (var kvp in PlayerMovements)
            {
                var id = kvp.Key;
                var movement = kvp.Value;
                var newVelocity = 0.0f;

                foreach (var key in pressedKeys)
                {
                    switch (key.Key)
                    {
                        case KeyInputs.LEFT:
                            newVelocity = movement.Velocity - (float)(movement.Speed * gt.ElapsedGameTime.TotalMilliseconds);
                            movement.Velocity = MathHelper.Clamp(newVelocity, -movement.MaxVelocity, movement.MaxVelocity);
                            UpdateIsMoving(id, movement.Velocity);
                            break;
                        case KeyInputs.RIGHT:
                            newVelocity = movement.Velocity + (float)(movement.Speed * gt.ElapsedGameTime.TotalMilliseconds);
                            movement.Velocity = MathHelper.Clamp(newVelocity, -movement.MaxVelocity, movement.MaxVelocity);
                            UpdateIsMoving(id, movement.Velocity);
                            break;
                    }
                }

            }

            var stopped = new List<long>();

            foreach (var entityId in MovingEntities)
            {
                var transform = TransformManager.Get(entityId);
                var movement = PlayerMovements[entityId];
                transform.Position.X += movement.Velocity;
                movement.Velocity = movement.Velocity * movement.Friction;

                if (movement.Velocity <= 0.1 && movement.Velocity >= -0.1)
                    stopped.Add(entityId);
            }

            foreach (var id in stopped)
            {
                MovingEntities.Remove(id);
            }
        }

        void UpdateIsMoving(long id, float velocity)
        {
            if (velocity <= 0.1 && velocity >= -0.1 && MovingEntities.Contains(id))
                MovingEntities.Remove(id);

            if (velocity > 0.1 || velocity < -0.1 && !MovingEntities.Contains(id))
                MovingEntities.Add(id);
        }
    }
}
