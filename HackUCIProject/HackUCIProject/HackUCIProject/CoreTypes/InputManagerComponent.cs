using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;

namespace HackUCIProject
{
    public class InputManagerComponent
    {
        public void Update()
        {
            InputManager.LastMouseState = InputManager.CurrentMouseState;
            InputManager.LastKeyboardState = InputManager.CurrentKeyboardState;
            InputManager.LastPlayer1State = InputManager.CurrentPlayer1State;
            InputManager.LastPlayer2State = InputManager.CurrentPlayer2State;
            InputManager.LastPlayer3State = InputManager.CurrentPlayer3State;
            InputManager.LastPlayer4State = InputManager.CurrentPlayer4State;

            InputManager.CurrentPlayer1State = GamePad.GetState(Microsoft.Xna.Framework.PlayerIndex.One);
            InputManager.CurrentPlayer2State = GamePad.GetState(Microsoft.Xna.Framework.PlayerIndex.Two);
            InputManager.CurrentPlayer3State = GamePad.GetState(Microsoft.Xna.Framework.PlayerIndex.Three);
            InputManager.CurrentPlayer4State = GamePad.GetState(Microsoft.Xna.Framework.PlayerIndex.Four);
            InputManager.CurrentKeyboardState = Keyboard.GetState();
            InputManager.CurrentMouseState = Mouse.GetState();
        }
    }
}
