using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Media;

namespace HackUCIProject
{
    public class GameScreen : Screen
    {
        PlayerScreen[] _playerScreens;
        Dungeon _dungeon = new Dungeon();
        TimeSpan updateTime = new TimeSpan(0, 0, 0, 2,0);
        TimeSpan timeElapsed;
        WrappedFonts.WrapArcadeFont _continueLabel;
        WrappedFonts.WrapAccelDropInFont _gameOverLabel;
        Microsoft.Xna.Framework.Content.ContentManager Content;
        

        public GameScreen(SpriteBatch spriteBatch, Vector2 location, int width, int height):
            base(spriteBatch, location, width, height)
        {
            _backGroundColor = Color.Blue;
            _playerScreens = new PlayerScreen[4];
        }

        public override void LoadContent(Microsoft.Xna.Framework.Content.ContentManager content)
        {
            Content = content;
            Color[] _colors = { Color.Pink, Color.Black, Color.Red, Color.Green };
            _dungeon.LoadContent(content, "LevelMap/SacredDonutLevelLeverless-05", Vector2.Zero, Color.White, _spriteBatch);
            _dungeon.MapChanged += new EventHandler(_dungeon_MapChanged);
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
            _dungeon.MapStart();

            _continueLabel = new WrappedFonts.WrapArcadeFont(Global.Fonts[0], new Vector2(_screen.Width / 2, _screen.Height / 1.5f), new Color[] { Color.White, Color.Green, Color.Pink, Color.Red }, _spriteBatch);
            _continueLabel.Text.Append("Press A to continue...");
            _continueLabel.SetCenterAsOrigin();
            _continueLabel.IsVisible = false;

            _gameOverLabel = new WrappedFonts.WrapAccelDropInFont(Global.Fonts[3], new Vector2(_screen.Width / 2, -200), new Vector2(_screen.Width / 2, _screen.Height / 2), Vector2.One, Color.Gold, new Vector2(0, 5), _spriteBatch);
            _gameOverLabel.Text.Append("Game Over\nYou Win!!");
            _gameOverLabel.SetCenterAsOrigin();
            _gameOverLabel.StateChanged += new EventHandler<FontEffectsLib.CoreTypes.StateEventArgs>(_gameOverLabel_StateChanged);
        }

        void _gameOverLabel_StateChanged(object sender, FontEffectsLib.CoreTypes.StateEventArgs e)
        {
            if (_gameOverLabel.State == FontEffectsLib.FontTypes.DropInFont.FontState.Done)
            {
                _continueLabel.IsVisible = true;
            }
        }
        
        void _dungeon_MapChanged(object sender, EventArgs e)
        {
            Texture2D newKeyMap =_dungeon.CreateNewKeyMap();

            for (int i = 0; i < _playerScreens.Length; i++)
            {
                _playerScreens[i].Player.KeyMap = newKeyMap;
            }
        }

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            
            timeElapsed += gameTime.ElapsedGameTime;
            for (int i = 0; i < _playerScreens.Length; i++)
            {
                _playerScreens[i].Update(gameTime);
            }
            if (_dungeon.GameState == GameState.levelComplete)
            {
                _continueLabel.Update(gameTime);
                _gameOverLabel.Update(gameTime);

                if (InputManager.CurrentPlayer1State.IsButtonDown(Microsoft.Xna.Framework.Input.Buttons.A))
                {
                    _sprites.Clear();
                    _dungeon.GameState = GameState.playing;
                    Global.CurrentScreen = ScreenState.startMenu;
                    MediaPlayer.Stop();
                    LoadContent(Content);
                }

            }
            if (timeElapsed >= updateTime)
            {
                Texture2D newKeyMap = _dungeon.CreateNewKeyMap();

                for (int i = 0; i < _playerScreens.Length; i++)
                {
                    _playerScreens[i].Player.KeyMap = newKeyMap;
                }
                timeElapsed = TimeSpan.Zero;
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
            _spriteBatch.Begin();
            _continueLabel.Draw();
            _gameOverLabel.Draw();
            _spriteBatch.End();
        }

    }
}
