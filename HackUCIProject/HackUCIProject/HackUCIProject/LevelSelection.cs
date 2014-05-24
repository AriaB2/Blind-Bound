using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace HackUCIProject
{
    public class LevelSelection : Screen
    {
        protected BaseSprite _map;
        protected BaseSprite _playButton;
        protected BaseSprite _backButton;
        protected BaseSprite _highlight;
        protected float _tintIncrement;
        protected float _highlightTint;
        protected TimeSpan _tintTime = new TimeSpan(0, 0, 0, 0, 40);
        protected TimeSpan _elapsedTime;

        public LevelSelection( SpriteBatch spriteBatch, Vector2 location, int width, int height):
            base( spriteBatch, location, width, height)
        {

        }
        public override void LoadContent(Microsoft.Xna.Framework.Content.ContentManager content)
        {
            _elapsedTime = new TimeSpan();
            _map = new BaseSprite();
            _map.LoadContent(content, "LevelMap/SacredDonutLevel", new Vector2(_spriteBatch.GraphicsDevice.Viewport.Width / 2, _spriteBatch.GraphicsDevice.Viewport.Height / 2), Color.White, 0f, Vector2.Zero, new Vector2(.25f, .25f), SpriteEffects.None,_spriteBatch, 0f);
            _map.Origin = new Vector2(_map.Image.Width / 2, _map.Image.Height / 2);
            
            _playButton = new BaseSprite();
            _playButton.LoadContent(content, "LevelMap/PlayButton", new Vector2(_spriteBatch.GraphicsDevice.Viewport.Width / 3, _spriteBatch.GraphicsDevice.Viewport.Height * 5 / 6), Color.White, 0f, Vector2.Zero, Vector2.One, SpriteEffects.None, _spriteBatch, 0f);
            _playButton.Origin = new Vector2(_playButton.Image.Width / 2, _playButton.Image.Height / 2);
            _backButton = new BaseSprite();
            _backButton.LoadContent(content, "LevelMap/BackButton", new Vector2(_spriteBatch.GraphicsDevice.Viewport.Width * 2 / 3, _spriteBatch.GraphicsDevice.Viewport.Height * 5 / 6), Color.White, 0f, Vector2.Zero, Vector2.One, SpriteEffects.None, _spriteBatch, 0f);
            _backButton.Origin = new Vector2(_backButton.Image.Width / 2, _backButton.Image.Height / 2);
            _highlight = new BaseSprite();
            _highlight.LoadContent(content, "LevelMap/HighLight", _playButton.Location, Color.White * _highlightTint, 0f, Vector2.Zero, Vector2.One, SpriteEffects.None, _spriteBatch, 0f);
            _highlightTint = 1f;
            _tintIncrement = .05f;
            _sprites.Add(_map);
            _sprites.Add(_playButton);
            _sprites.Add(_backButton);
            _sprites.Add(_highlight);
        }

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            _elapsedTime += gameTime.ElapsedGameTime;
            if (_elapsedTime >= _tintTime)
            {
                if (_highlightTint >= 1f || _highlightTint <= 0f)
                {
                    _highlightTint *= -1;
                }
                _highlightTint += _tintIncrement;
                _highlight.Tint *= _highlightTint;
                _elapsedTime = TimeSpan.Zero;
            }
            base.Update(gameTime);
        }

        
    }
}
