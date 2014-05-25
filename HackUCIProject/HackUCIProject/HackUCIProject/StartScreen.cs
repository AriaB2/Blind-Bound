using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using FontEffectsLib.SpriteTypes;
using FontEffectsLib.FontTypes;
using HackUCIProject.WrappedFonts;

namespace HackUCIProject
{

    public class StartScreen : Screen 
    {
        private WrapFadingFont _fadingFont;
        private WrapSlidingFont _slidingFont;
        private WrapSlidingFont _slidingFont1;
        private WrapSlidingFont _slidingFont2;

        TimeSpan _elapsedGameTIme = new TimeSpan();
        TimeSpan _timeForScale = new TimeSpan(0, 0, 0, 0, 1);



        int fadeFontStateNum = 0;

        private BaseSprite _backGroundImage;
        

        private List<SpriteFont> _spriteFontList;
        public List<SpriteFont> SpriteFontList
        {
            get
            {
                return _spriteFontList;
            }
            set
            {
                _spriteFontList = value;
            }
        }

        public StartScreen(SpriteBatch spriteBatch, Vector2 location, int width, int height, List<SpriteFont> spriteFontList)
            :base(spriteBatch, location, width, height)
        {
            _spriteFontList = spriteFontList;
        }

        public StartScreen(SpriteBatch spriteBatch, Vector2 location, int width, int height, SpriteFont singleSpriteFont)
            : base(spriteBatch, location, width, height)
        {
            _spriteFontList = new List<SpriteFont>();
            _spriteFontList.Add(singleSpriteFont);
        }

        public override void LoadContent(Microsoft.Xna.Framework.Content.ContentManager content)
        {
            /*
      Color[] colorList = { Color.Black, Color.DarkGray, Color.Gray, Color.Gray };
      _arcadeFont = new WrapArcadeFont(_spriteFontList[5], new Vector2(_spriteBatch.GraphicsDevice.Viewport.Width / 2, _spriteBatch.GraphicsDevice.Viewport.Height / 2 - 50), colorList, _spriteBatch);
      _arcadeFont.Text.Append("BlindBound");
      _arcadeFont.IsVisible = false;
      _arcadeFont.Position = new Vector2(_arcadeFont.Position.X - _arcadeFont.Font.MeasureString("BlindBound").X / 2, _arcadeFont.Position.Y - _arcadeFont.Font.MeasureString("BlindBound").Y / 2);
      _arcadeFont.EnableShadow = false;
      _arcadeFont.ColorCyclesPerSecond = 0.2f;
      _sprites.Add(_arcadeFont);
      */


            _backGroundImage = new BaseSprite();
            _backGroundColor = Color.Beige;
            
            
            _backGroundImage.LoadContent(content, "StartScreenImage", Vector2.Zero, Color.White, _spriteBatch);
            _backGroundImage.Origin = new Vector2(_backGroundImage.Width / 2, _backGroundImage.Height / 2);
            _backGroundImage.Location = new Vector2(_spriteBatch.GraphicsDevice.Viewport.Width / 2 - 5, _spriteBatch.GraphicsDevice.Viewport.Height / 2);
            _backGroundImage.Scale = new Vector2(0.42f, 0.42f);
            _sprites.Add(_backGroundImage);


            _fadingFont = new WrapFadingFont(_spriteFontList[6], new Vector2(_spriteBatch.GraphicsDevice.Viewport.Width / 2 , _spriteBatch.GraphicsDevice.Viewport.Height / 2 - 50), Color.DarkRed, _spriteBatch);
            _fadingFont.Text.Append("BlindBound");
            _fadingFont.EnableShadow = false;
            _fadingFont.StateChanged += new EventHandler<FontEffectsLib.CoreTypes.StateEventArgs>(_fadingFont_StateChanged);
            _fadingFont.Origin = new Vector2(_fadingFont.Font.MeasureString("BlindBound").X / 2, _fadingFont.Font.MeasureString("BlindBound").Y / 2);
            _sprites.Add(_fadingFont);

            _slidingFont = new WrapSlidingFont(_spriteFontList[1], new Vector2(0, _spriteBatch.GraphicsDevice.Viewport.Height / 2 + 25), Vector2.Zero, 1.0f, Color.Black, _spriteBatch);
            _slidingFont.Text.Append("Start");
            _slidingFont.Origin = new Vector2(_slidingFont.Font.MeasureString("Start").X/2, _slidingFont.Font.MeasureString("Start").Y/2);
            _slidingFont.TargetPosition = new Vector2(_spriteBatch.GraphicsDevice.Viewport.Width / 2, _spriteBatch.GraphicsDevice.Viewport.Height / 2 + 25);
            _slidingFont.EnableShadow = false;
            _slidingFont.IsVisible = false;
            _sprites.Add(_slidingFont);

            _slidingFont1 = new WrapSlidingFont(_spriteFontList[1], new Vector2(_spriteBatch.GraphicsDevice.Viewport.Width, _spriteBatch.GraphicsDevice.Viewport.Height / 2 + 75), Vector2.Zero, 1.0f, Color.Black, _spriteBatch);
            _slidingFont1.Text.Append("Options");
            _slidingFont1.Origin = new Vector2(_slidingFont1.Font.MeasureString("Options").X / 2, _slidingFont1.Font.MeasureString("Options").Y / 2);
            _slidingFont1.TargetPosition = new Vector2(_spriteBatch.GraphicsDevice.Viewport.Width / 2, _spriteBatch.GraphicsDevice.Viewport.Height / 2 + 75);
            _slidingFont1.EnableShadow = false;
            _slidingFont1.IsVisible = false;
            _sprites.Add(_slidingFont1);

            _slidingFont2 = new WrapSlidingFont(_spriteFontList[1], new Vector2(0, _spriteBatch.GraphicsDevice.Viewport.Height / 2 + 125), Vector2.Zero, 1.0f, Color.Black, _spriteBatch);
            _slidingFont2.Text.Append("Exit");
            _slidingFont2.Origin = new Vector2(_slidingFont2.Font.MeasureString("Exit").X / 2, _slidingFont2.Font.MeasureString("Exit").Y / 2);
            _slidingFont2.TargetPosition = new Vector2(_spriteBatch.GraphicsDevice.Viewport.Width / 2, _spriteBatch.GraphicsDevice.Viewport.Height / 2 + 125);
            _slidingFont2.EnableShadow = false;
            _slidingFont2.IsVisible = false;
            _sprites.Add(_slidingFont2);
            
            

        }

       

        void _fadingFont_StateChanged(object sender, FontEffectsLib.CoreTypes.StateEventArgs e)
        {
            fadeFontStateNum++;
            if (fadeFontStateNum == 2)
            {
                _slidingFont.IsVisible = true;
                _slidingFont.Slide();
                _slidingFont1.IsVisible = true;
                _slidingFont1.Slide();
                _slidingFont2.IsVisible = true;
                _slidingFont2.Slide();
            }
        }

        public override void Update(GameTime gameTime)
        {
            if (_fadingFont.State == FadingFont.FontState.Fading)
            {
                _elapsedGameTIme += gameTime.ElapsedGameTime;
                if (_elapsedGameTIme >= _timeForScale)
                {
                    _fadingFont.Scale += new Vector2(0.02f, 0.02f);
                    _elapsedGameTIme = new TimeSpan();
                }
            }
            if (_fadingFont.State == FadingFont.FontState.NotFading && _fadingFont.Scale.X != 1.0f && _fadingFont.Scale.Y != 1.0f)
            {
                _elapsedGameTIme += gameTime.ElapsedGameTime;
                if (_elapsedGameTIme >= _timeForScale)
                {
                    _fadingFont.Scale -= new Vector2(0.02f, 0.02f);
                    _elapsedGameTIme = new TimeSpan();
                }
            }
          
            base.Update(gameTime);
        }

 

    }
}
