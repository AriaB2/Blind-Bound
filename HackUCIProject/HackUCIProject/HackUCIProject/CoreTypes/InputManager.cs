using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace HackUCIProject
{
    public static class InputManager
    {
        public static GamePadState CurrentPlayer1State;

        public static GamePadState CurrentPlayer2State;

        public static GamePadState CurrentPlayer3State;

        public static GamePadState CurrentPlayer4State;

        public static GamePadState GetCurrentPlayerState(PlayerIndex player)
        {
            if (player == PlayerIndex.One)
            {
                return CurrentPlayer1State;
            }
            else if (player == PlayerIndex.Two)
            {
                return CurrentPlayer2State;
            }
            else if (player == PlayerIndex.Three)
            {
                return CurrentPlayer3State;
            }
            else
            {
                return CurrentPlayer4State;
            }
        }


        public static GamePadState GetLastPlayerState(PlayerIndex player)
        {
            if (player == PlayerIndex.One)
            {
                return LastPlayer1State;
            }
            else if (player == PlayerIndex.Two)
            {
                return LastPlayer2State;
            }
            else if (player == PlayerIndex.Three)
            {
                return LastPlayer3State;
            }
            else
            {
                return LastPlayer4State;
            }
        }

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