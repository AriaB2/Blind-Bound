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
            _sprites.Add(_dungeon);
            _player.Camera = _camera;
            _player.ScreenSize = new Vector2(_screen.Width, _screen.Height);
            _dungeon.MapChanged += new EventHandler(_dungeon_MapChanged);

            _localKeyMap = new Texture2D(_spriteBatch.GraphicsDevice, _screen.Width, _screen.Height);
            _colorData = new Color[_screen.Width * _screen.Height];
            _dungeon.Drawn.GetData<Color>(0, new Rectangle((int)_camera.Pos.X - _screen.Width / 2, (int)_camera.Pos.Y - (int)_screen.Height / 2, (int)_screen.Width, (int)_screen.Height), _colorData, 0, _colorData.Length);
            _localKeyMap.SetData<Color>(_colorData);
            _player.KeyMap = _localKeyMap;
        }

        void _dungeon_MapChanged(object sender, EventArgs e)
        {
            _localKeyMap = new Texture2D(_spriteBatch.GraphicsDevice, _screen.Width, _screen.Height);
            _colorData = new Color[_screen.Width * _screen.Height];
            _dungeon.Drawn.GetData<Color>(0, new Rectangle((int)_camera.Pos.X - _screen.Width / 2, (int)_camera.Pos.Y - (int)_screen.Height / 2, (int)_screen.Width, (int)_screen.Height), _colorData, 0, _colorData.Length);
            _localKeyMap.SetData<Color>(_colorData);
            _player.KeyMap = _localKeyMap;
        }

        public override void LoadContent(Microsoft.Xna.Framework.Content.ContentManager content)
        {    

        }
        Texture2D _localKeyMap;
        Color[] _colorData;         
        public override void Update(GameTime gameTime)
        {
            _camera.Pos = _player.Location;
            if (_camera.Pos.X - _screen.Width / 2 <= 0)
            {
                _camera._pos.X = _screen.Width/2;
            }
            else if (_camera.Pos.X + _screen.Width / 2 >= _dungeon.Width)
            {
                _camera._pos.X = _dungeon.Width - _screen.Width / 2;
            }
            if (_camera.Pos.Y - _screen.Height / 2 <= 0)
            {
                _camera._pos.Y = _screen.Height / 2 ;
            }
            else if (_camera.Pos.Y + _screen.Height / 2 >= _dungeon.Height)
            {
                _camera._pos.Y = _dungeon.Height - _screen.Height / 2;
            }

           

            base.Update(gameTime);
        }

        public override void Render()
        {
            
            //Rectangle visibleArea = new Rectangle((int)_camera.Pos.X,(int)_camera.Pos.Y, _width, _height);

            //Color[] pixels = new Color[visibleArea.Width * visibleArea.Height];
            //if (visibleArea.X < 0)
            //{
            //    visibleArea.X = 0;
            //}
            //if(visibleArea.Y < 0)
            //{
            //    visibleArea.Y = 0;
            //}

            //if (visibleArea.X > _dungeon.Image.Width - _width)
            //{
            //    visibleArea.X = _dungeon.Image.Width - _width;
            //}
            //if (visibleArea.Y > _dungeon.Image.Height - _height)
            //{
            //    visibleArea.Y = _dungeon.Image.Height - _height;
            //}

            //_dungeon.Drawn.GetData<Color>(0, visibleArea, pixels, 0, pixels.Length);
            ////_dungeon.Image.GetData<Color>(0, visibleArea, pixels, 0, visibleArea.Width * visibleArea.Height);

            ////_spriteBatch.GraphicsDevice.SetRenderTarget(null);
            //_screen.SetData<Color>(pixels);
            base.Render();
            _dungeon.Render();
        }
    }
}
