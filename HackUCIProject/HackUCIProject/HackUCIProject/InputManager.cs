using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;

namespace HackUCIProject
{
    public static class InputManager
    {
        public static GamePadState CurrentPlayer1State;

        public static GamePadState CurrentPlayer2State;

        public static GamePadState CurrentPlayer3State;

        public static GamePadState CurrentPlayer4State;

        public static GamePadState LastPlayer1State;

        public static GamePadState LastPlayer2State;

        public static GamePadState LastPlayer3State;

        public static GamePadState LastPlayer4State;

        public static KeyboardState CurrentKeyboardState;

        public static KeyboardState LastKeyboardState;

        public static MouseState CurrentMouseState;

        public static MouseState LastMouseState;
    }
}
