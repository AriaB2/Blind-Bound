using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace HackUCIProject
{
    public class GameScreen : Screen
    {

        PlayerScreen[] _playerScreens;

        public GameScreen(SpriteBatch spriteBatch, Vector2 location, int width, int height):
            base(spriteBatch, location, width, height)
        {
            _backGroundColor = Color.Blue;
            _playerScreens = new PlayerScreen[4];
        }

        public override void LoadContent(Microsoft.Xna.Framework.Content.ContentManager content)
        {
            Color[] _colors = { Color.Pink, Color.Black, Color.Red, Color.Green };

            int y = 0;
            for (int row = 0; row < 2; row++)
            {
                int x = 0;
                for (int col = 0; col < 2; col++)
                {
                    _playerScreens[row * 2 + col] = new PlayerScreen(_spriteBatch, new Vector2(x, y), _spriteBatch.GraphicsDevice.Viewport.Width / 2 - 1, _spriteBatch.GraphicsDevice.Viewport.Height / 2 - 1, new Player());
                    _playerScreens[row * 2 + col].BackGroundColor = _colors[row * 2 + col];
                    x += _spriteBatch.GraphicsDevice.Viewport.Width / 2;
                }
                y += _spriteBatch.GraphicsDevice.Viewport.Height / 2;
            }
            
            
            
        }

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Render()
        {
            foreach (PlayerScreen playerScreen in _playerScreens)
            {
                playerScreen.Render();
            }
            base.Render();
        }

        public override void Draw()
        {
            base.Draw();
            foreach (PlayerScreen playerScreen in _playerScreens)
            {
                playerScreen.Draw();
            }
        }

    }
}
