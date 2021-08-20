using Fna2dGraphics.Entities.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Linq;

namespace Fna2dGraphics.Entities.ComponentManagers
{
    class PressedKeyInputManager
    {
        readonly List<PressedKeyInput> PressedKeys = new List<PressedKeyInput>();

        public List<PressedKeyInput> GetAll => PressedKeys;

        public void UpdateInputs()
        {
            var keyboardCur = Keyboard.GetState();
            var gpCur = GamePad.GetState(PlayerIndex.One);

            if (keyboardCur.IsKeyDown(Keys.W) || keyboardCur.IsKeyDown(Keys.Up)
                || gpCur.IsButtonDown(Buttons.DPadUp) || gpCur.IsButtonDown(Buttons.LeftThumbstickUp))
            {
                UpdateState(KeyInputs.UP, true);
            }
            else
            {
                UpdateState(KeyInputs.UP, false);
            }

            if (keyboardCur.IsKeyDown(Keys.S) || keyboardCur.IsKeyDown(Keys.Down)
                || gpCur.IsButtonDown(Buttons.DPadDown) || gpCur.IsButtonDown(Buttons.LeftThumbstickDown))
            {
                UpdateState(KeyInputs.DOWN, true);
            }
            else
            {
                UpdateState(KeyInputs.DOWN, false);
            }

            if (keyboardCur.IsKeyDown(Keys.A) || keyboardCur.IsKeyDown(Keys.Left)
                || gpCur.IsButtonDown(Buttons.DPadLeft) || gpCur.IsButtonDown(Buttons.LeftThumbstickLeft))
            {
                UpdateState(KeyInputs.LEFT, true);
            }
            else
            {
                UpdateState(KeyInputs.LEFT, false);
            }

            if (keyboardCur.IsKeyDown(Keys.D) || keyboardCur.IsKeyDown(Keys.Right)
                || gpCur.IsButtonDown(Buttons.DPadRight) || gpCur.IsButtonDown(Buttons.LeftThumbstickRight))
            {
                UpdateState(KeyInputs.RIGHT, true);
            }
            else
            {
                UpdateState(KeyInputs.RIGHT, false);
            }

            if (keyboardCur.IsKeyDown(Keys.J) || keyboardCur.IsKeyDown(Keys.Z)
                || gpCur.IsButtonDown(Buttons.A) || gpCur.IsButtonDown(Buttons.Y))
            {
                UpdateState(KeyInputs.A, true);
            }
            else
            {
                UpdateState(KeyInputs.A, false);
            }

            if (keyboardCur.IsKeyDown(Keys.K) || keyboardCur.IsKeyDown(Keys.X)
                || gpCur.IsButtonDown(Buttons.B) || gpCur.IsButtonDown(Buttons.X))
            {
                UpdateState(KeyInputs.B, true);
            }
            else
            {
                UpdateState(KeyInputs.B, false);
            }
        }

        void UpdateState(KeyInputs key, bool isPressed)
        {
            var alreadyPressed = PressedKeys.FirstOrDefault(pk => pk.Key == key);
            if (alreadyPressed != null)
            {
                if (!isPressed)
                    PressedKeys.Remove(alreadyPressed);

                return;
            }

            if (isPressed)
                PressedKeys.Add(new PressedKeyInput
                {
                    Key = key
                });
        }
    }
}
