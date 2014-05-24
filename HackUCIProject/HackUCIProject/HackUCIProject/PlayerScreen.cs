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
        Dungeon _dungeon;
        int _width;
        int _height;

        public PlayerScreen(SpriteBatch spriteBatch, Vector2 location, int width, int height, Player player, Dungeon dungeon) :
            base(spriteBatch, location, width, height)
        {
            _player = player;
            _dungeon = dungeon;
            _width = width;
            _height = height;
        }

        public override void LoadContent(Microsoft.Xna.Framework.Content.ContentManager content)
        {
            //...
        }

        public override void Update(GameTime gameTime)
        {

            base.Update(gameTime);
        }

        public override void Render()
        {
            Rectangle visibleArea = new Rectangle(Convert.ToInt32(_player.Location.X - _width / 2),Convert.ToInt32( _player.Location.Y - _height / 2), _width, _height);

            Color[] pixels = new Color[visibleArea.Width * visibleArea.Height];
            if (visibleArea.X < 0)
            {
                visibleArea.X = 0;
            }
            if(visibleArea.Y < 0)
            {
                visibleArea.Y = 0;
            }

            if (visibleArea.X > _dungeon.Image.Width - _width)
            {
                visibleArea.X = _dungeon.Image.Width - _width;
            }
            if (visibleArea.Y > _dungeon.Image.Height - _height)
            {
                visibleArea.Y = _dungeon.Image.Height - _height;
            }

            _dungeon.Image.GetData<Color>(0, visibleArea, pixels, 0, visibleArea.Width * visibleArea.Height);

            //_spriteBatch.GraphicsDevice.SetRenderTarget(null);
            _screen.SetData<Color>(pixels);

        }
    }
}
