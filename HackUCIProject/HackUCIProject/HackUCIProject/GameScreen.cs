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
        Dungeon _dungeon = new Dungeon();

        public GameScreen(SpriteBatch spriteBatch, Vector2 location, int width, int height):
            base(spriteBatch, location, width, height)
        {
            _backGroundColor = Color.Blue;
            _playerScreens = new PlayerScreen[4];
        }

        public override void LoadContent(Microsoft.Xna.Framework.Content.ContentManager content)
        {
            Color[] _colors = { Color.Pink, Color.Black, Color.Red, Color.Green };
            _dungeon.LoadContent(content, "LevelMap/SacredDonutLevel", Vector2.Zero, Color.White, _spriteBatch);
            int y = 0;

            for (int row = 0; row < 2; row++)
            {
                int x = 0;
                for (int col = 0; col < 2; col++)
                {
                    _playerScreens[row * 2 + col] = new PlayerScreen(_spriteBatch, new Vector2(x, y), _spriteBatch.GraphicsDevice.Viewport.Width / 2 - 0, _spriteBatch.GraphicsDevice.Viewport.Height / 2 - 0, _dungeon.Players[row * 2 + col], _dungeon);
                    _playerScreens[row * 2 + col].BackGroundColor = _colors[row * 2 + col];
                    x += _spriteBatch.GraphicsDevice.Viewport.Width / 2;
                }
                y += _spriteBatch.GraphicsDevice.Viewport.Height / 2;
            }

            _sprites.Add(_dungeon);
            
        }

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            for (int i = 0; i < _playerScreens.Length; i++)
            {
                _playerScreens[i].Update(gameTime);
            }

            base.Update(gameTime);
        }

        public override void Render()
        {
            
            base.Render();
            foreach (PlayerScreen playerScreen in _playerScreens)
            {
                playerScreen.Render();
            }
        }

        public override void Draw()
        {//_dungeon.Draw();
            base.Draw();
            
            foreach (PlayerScreen playerScreen in _playerScreens)
            {
                playerScreen.Draw();
            }
        }

    }
}
