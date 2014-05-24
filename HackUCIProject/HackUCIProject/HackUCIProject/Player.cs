using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace HackUCIProject
{
    public class Player : PixelDetectionSprite
    {
        private PlayerIndex _playerIndex;

        public PlayerIndex PlayerIndex
        {
            get { return _playerIndex; }
        }

        public Player(PlayerIndex player)
        {
            _playerIndex = player;
        }
        public override void Update(GameTime gameTime)
        {
            _speed = new Vector2(InputManager.GetCurrentPlayerState(_playerIndex).ThumbSticks.Left.X, -InputManager.GetCurrentPlayerState(_playerIndex).ThumbSticks.Left.Y);
            base.Update(gameTime);
        }
    }
}
