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

        public override void Render()
        {
            _dungeon.Render();
            Rectangle visibleArea = new Rectangle((int)_camera.Pos.X,(int)_camera.Pos.Y, _width, _height);

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

            _dungeon.Drawn.GetData<Color>(0, visibleArea, pixels, 0, pixels.Length);
            //_dungeon.Image.GetData<Color>(0, visibleArea, pixels, 0, visibleArea.Width * visibleArea.Height);

            //_spriteBatch.GraphicsDevice.SetRenderTarget(null);
            _screen.SetData<Color>(pixels);

        }
    }
}
