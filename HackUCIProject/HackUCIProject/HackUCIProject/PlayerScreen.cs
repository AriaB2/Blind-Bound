using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace HackUCIProject
{
    public class PlayerScreen : Screen
    {
        Player _player;

        public PlayerScreen(SpriteBatch spriteBatch, Vector2 location, int width, int height, Player player) :
            base(spriteBatch, location, width, height)
        {
            _player = player;
            _backGroundColor = Color.White;
        }

        public override void LoadContent(Microsoft.Xna.Framework.Content.ContentManager content)
        {
            //...
        }

        public override void Update(GameTime gameTime)
        {
            _camera.Pos = _player.Location;

            base.Update(gameTime);
        }
    }
}
