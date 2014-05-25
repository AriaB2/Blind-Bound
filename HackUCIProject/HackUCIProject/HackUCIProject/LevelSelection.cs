using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using HackUCIProject.WrappedFonts;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace HackUCIProject
{
    public class LevelSelection : Screen
    {
        protected BaseSprite _map;
        protected BaseSprite _playButton;
        protected BaseSprite _backButton;
        protected BaseSprite _highlight;
        //protected float _tintIncrement;
        protected float _highlightTint;
        protected Song song;
        //protected WrapArcadeFont _highlightText;
        //protected WrapArcadeFont _alphaText;
        //protected SpriteFont _font;
        //protected StringBuilder _builder;
        //protected TimeSpan _tintTime = new TimeSpan(0, 0, 0, 0, 400);
        //protected TimeSpan _elapsedTime;
        //protected Color[] _color = new Color[2];

        public LevelSelection( SpriteBatch spriteBatch, Vector2 location, int width, int height):
            base( spriteBatch, location, width, height)
        {
            _backGroundColor = Color.Black;
        }
        public override void LoadContent(Microsoft.Xna.Framework.Content.ContentManager content)
        {
            //_elapsedTime = new TimeSpan();
            _map = new BaseSprite();
            _map.LoadContent(content, "LevelMap/SacredDonutLevel", new Vector2(_spriteBatch.GraphicsDevice.Viewport.Width / 2, _spriteBatch.GraphicsDevice.Viewport.Height / 2), Color.White, 0f, Vector2.Zero, new Vector2(.25f, .25f), SpriteEffects.None,_spriteBatch, 0f);
            _map.Origin = new Vector2(_map.Image.Width / 2, _map.Image.Height / 2);
            song = content.Load<Song>("SoundEffects\\DST-3rdBallad");
            _playButton = new BaseSprite();
            _playButton.LoadContent(content, "LevelMap/PlayButton", new Vector2(_spriteBatch.GraphicsDevice.Viewport.Width / 3, _spriteBatch.GraphicsDevice.Viewport.Height * 7 / 8), Color.White, 0f, Vector2.Zero, Vector2.One, SpriteEffects.None, _spriteBatch, 0f);
            _playButton.Origin = new Vector2(_playButton.Image.Width / 2, _playButton.Image.Height / 2);
            _backButton = new BaseSprite();
            _backButton.LoadContent(content, "LevelMap/BackButton", new Vector2(_spriteBatch.GraphicsDevice.Viewport.Width * 2 / 3, _spriteBatch.GraphicsDevice.Viewport.Height * 7 / 8), Color.White, 0f, Vector2.Zero, Vector2.One, SpriteEffects.None, _spriteBatch, 0f);
            _backButton.Origin = new Vector2(_backButton.Image.Width / 2, _backButton.Image.Height / 2);
            _highlight = new BaseSprite();
            _highlight.LoadContent(content, "LevelMap/HighLight", _playButton.Location, Color.White * .3f, 0f, Vector2.Zero, Vector2.One, SpriteEffects.None, _spriteBatch, 0f);
            _highlight.Origin = new Vector2(_highlight.Image.Width / 2, _highlight.Image.Height / 2);
            //_highlightTint = .5f;
            //_tintIncrement = .1f;
            //_color[0] = Color.Red;
           // _color[1] = Color.White;
            //_font = content.Load<SpriteFont>("StartScreenSpriteFont0");
            //_highlightText = new WrapArcadeFont(_font, new Vector2( 10, 10), _color, _spriteBatch);
            //_alphaText = new WrapArcadeFont(_font, new Vector2(10, 40), _color, _spriteBatch);
            //_builder = new StringBuilder();
            _sprites.Add(_map);
            _sprites.Add(_playButton);
            _sprites.Add(_backButton);
            _sprites.Add(_highlight);
            //_sprites.Add(_highlightText);
            //_sprites.Add(_alphaText);
        }

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            //_elapsedTime += gameTime.ElapsedGameTime;
            //if (_elapsedTime >= _tintTime)
            //{
            //    if (_highlightTint >= 1f || _highlightTint <= 0.1f)
            //    {
            //        _tintIncrement *= -1;
            //    }
            //    _highlightTint += _tintIncrement;
            //    _highlightText.Text.Clear();
            //    _highlightText.Text.Append(_highlightTint.ToString());
            //    _alphaText.Text.Clear();
            //    _alphaText.Text.Append(_highlight.Tint.A.ToString());
            //    _elapsedTime = TimeSpan.Zero;
            //}
            
            //_highlightText.Update(gameTime);

            if ((InputManager.CurrentPlayer1State.ThumbSticks.Left.X < 0 || InputManager.CurrentPlayer1State.ThumbSticks.Left.X > 0) && InputManager.LastPlayer1State.ThumbSticks.Left.X == 0)
            {
                if (_highlight.Location == _playButton.Location)
                {
                    _highlight.Location = _backButton.Location;
                }
                else
                {
                    _highlight.Location = _playButton.Location;
                }
            }
            if (InputManager.CurrentPlayer1State.IsButtonDown(Buttons.A) && InputManager.LastPlayer1State.IsButtonUp(Buttons.A))
            {
                if (_highlight.Location == _playButton.Location)
                {
                    
                    Global.CurrentScreen = ScreenState.game;
                    MediaPlayer.Play(song);
                    MediaPlayer.IsRepeating = true;
                }
                else
                {
                    Global.CurrentScreen = ScreenState.startMenu;
                }
            }
            base.Update(gameTime);
        }

        public override void Render()
        {
            //_spriteBatch.Begin();
            //_spriteBatch.Draw(_highlight.Image, _highlight.Location, Color.White * _highlightTint);
            //_spriteBatch.End();
            base.Render();
        }
    }
}
