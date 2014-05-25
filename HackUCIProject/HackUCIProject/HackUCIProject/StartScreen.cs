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
        private WrapFadingFont _titleFont;
        private WrapSlidingFont _startFont;
        private WrapSlidingFont _optionsFont;
        private WrapSlidingFont _exitFont;
        private WrapSlidingFont _creditsFont;

        public bool EndGame = false;

        private WrapSlidingFont[] menu;
        int currentItem = 0;

        TimeSpan _elapsedGameTIme = new TimeSpan();
        TimeSpan _timeForScale = new TimeSpan(0, 0, 0, 0, 1);

        bool resetScreen = false;
        bool skippedIntro = false;

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


            _titleFont = new WrapFadingFont(_spriteFontList[6], new Vector2(_spriteBatch.GraphicsDevice.Viewport.Width / 2 , _spriteBatch.GraphicsDevice.Viewport.Height / 2 - 50), Color.DarkRed, _spriteBatch);
            _titleFont.Text.Append("BlindBound");
            _titleFont.EnableShadow = false;
            _titleFont.StateChanged += new EventHandler<FontEffectsLib.CoreTypes.StateEventArgs>(_fadingFont_StateChanged);
            _titleFont.Origin = new Vector2(_titleFont.Font.MeasureString("BlindBound").X / 2, _titleFont.Font.MeasureString("BlindBound").Y / 2);
            _sprites.Add(_titleFont);

            _startFont = new WrapSlidingFont(_spriteFontList[1], new Vector2(0, _spriteBatch.GraphicsDevice.Viewport.Height / 2 + 25), Vector2.Zero, 1.0f, Color.Black, _spriteBatch);
            _startFont.Text.Append("Start");
            _startFont.Origin = new Vector2(_startFont.Font.MeasureString("Start").X/2, _startFont.Font.MeasureString("Start").Y/2);
            _startFont.TargetPosition = new Vector2(_spriteBatch.GraphicsDevice.Viewport.Width / 2, _spriteBatch.GraphicsDevice.Viewport.Height / 2 + 25);
            _startFont.EnableShadow = false;
            _startFont.IsVisible = false;
            _sprites.Add(_startFont);

            _optionsFont = new WrapSlidingFont(_spriteFontList[1], new Vector2(_spriteBatch.GraphicsDevice.Viewport.Width, _spriteBatch.GraphicsDevice.Viewport.Height / 2 + 75), Vector2.Zero, 1.0f, Color.Black, _spriteBatch);
            _optionsFont.Text.Append("Options");
            _optionsFont.Origin = new Vector2(_optionsFont.Font.MeasureString("Options").X / 2, _optionsFont.Font.MeasureString("Options").Y / 2);
            _optionsFont.TargetPosition = new Vector2(_spriteBatch.GraphicsDevice.Viewport.Width / 2, _spriteBatch.GraphicsDevice.Viewport.Height / 2 + 75);
            _optionsFont.EnableShadow = false;
            _optionsFont.IsVisible = false;
            _sprites.Add(_optionsFont);

            _exitFont = new WrapSlidingFont(_spriteFontList[1], new Vector2(0, _spriteBatch.GraphicsDevice.Viewport.Height / 2 + 175), Vector2.Zero, 1.0f, Color.Black, _spriteBatch);
            _exitFont.Text.Append("Exit");
            _exitFont.Origin = new Vector2(_exitFont.Font.MeasureString("Exit").X / 2, _exitFont.Font.MeasureString("Exit").Y / 2);
            _exitFont.TargetPosition = new Vector2(_spriteBatch.GraphicsDevice.Viewport.Width / 2, _spriteBatch.GraphicsDevice.Viewport.Height / 2 + 175);
            _exitFont.EnableShadow = false;
            _exitFont.IsVisible = false;
            _sprites.Add(_exitFont);

            _creditsFont = new WrapSlidingFont(_spriteFontList[1], new Vector2(_spriteBatch.GraphicsDevice.Viewport.Width, _spriteBatch.GraphicsDevice.Viewport.Height / 2 + 125), Vector2.Zero, 1.0f, Color.Black, _spriteBatch);
            _creditsFont.Text.Append("Credits");
            _creditsFont.Origin = new Vector2(_exitFont.Font.MeasureString("Credits").X / 2, _exitFont.Font.MeasureString("Credits").Y / 2);
            _creditsFont.TargetPosition = new Vector2(_spriteBatch.GraphicsDevice.Viewport.Width / 2, _spriteBatch.GraphicsDevice.Viewport.Height / 2 + 125);
            _creditsFont.EnableShadow = false;
            _creditsFont.IsVisible = false;
            _sprites.Add(_creditsFont);

            menu = new WrapSlidingFont[4];
            menu[0] = _startFont;
            menu[1] = _optionsFont;
            menu[2] = _creditsFont;
            menu[3] = _exitFont;
            menu[0].TintColor = Color.White;
        }

       

        void _fadingFont_StateChanged(object sender, FontEffectsLib.CoreTypes.StateEventArgs e)
        {
            fadeFontStateNum++;
            if (fadeFontStateNum == 2)
            {
                _startFont.IsVisible = true;
                _startFont.Slide();
                _optionsFont.IsVisible = true;
                _optionsFont.Slide();
                _exitFont.IsVisible = true;
                _exitFont.Slide();
                _creditsFont.IsVisible = true;
                _creditsFont.Slide();
            }
        }

        public override void Update(GameTime gameTime)
        {
            if (resetScreen)
            {
                skippedIntro = false;
                fadeFontStateNum = 0;
                _titleFont.Reset();
                _titleFont.Scale = Vector2.One;
                for (int i = 0; i < menu.Length; i++)
                {
                    menu[i].Reset();
                    menu[i].IsVisible = false;
                    //menu[i].Slide();
                    resetScreen = false;
                }
            }

            if (_titleFont.State == FadingFont.FontState.Fading)
            {
                _elapsedGameTIme += gameTime.ElapsedGameTime;
                if (_elapsedGameTIme >= _timeForScale)
                {
                    _titleFont.Scale += new Vector2(0.02f, 0.02f);
                    _elapsedGameTIme = new TimeSpan();
                }
            }
            
            else if (_titleFont.State == FadingFont.FontState.NotFading && _titleFont.Scale.X != 1.0f && _titleFont.Scale.Y != 1.0f)
            {
                _elapsedGameTIme += gameTime.ElapsedGameTime;
                if (_elapsedGameTIme >= _timeForScale)
                {
                    _titleFont.Scale -= new Vector2(0.02f, 0.02f);
                    _elapsedGameTIme = new TimeSpan();
                }
            }
            
            if (InputManager.CurrentPlayer1State.ThumbSticks.Left.Y > 0 && InputManager.LastPlayer1State.ThumbSticks.Left.Y <= 0)
            {
                menu[currentItem].TintColor = Color.Black;
                currentItem--;
                if (currentItem < 0)
                {
                    currentItem = menu.Length - 1;
                }
                menu[currentItem].TintColor = Color.White;

            }

            else if (InputManager.CurrentPlayer1State.ThumbSticks.Left.Y < 0 && InputManager.LastPlayer1State.ThumbSticks.Left.Y >= 0)
            {
                menu[currentItem].TintColor = Color.Black;
                currentItem++;

                if (currentItem >= menu.Length)
                {
                    currentItem = 0;
                }

                menu[currentItem].TintColor = Color.White;

            }
            if (InputManager.CurrentPlayer1State.Buttons.A == Microsoft.Xna.Framework.Input.ButtonState.Pressed && fadeFontStateNum <= 2 && !skippedIntro)
            {
                for (int i = 0; i < menu.Length; i++)
                {
                    menu[i].Position = menu[i].TargetPosition;
                    menu[i].IsVisible = true;
                }
                skippedIntro = true;
            }
            else if (InputManager.CurrentPlayer1State.Buttons.A == Microsoft.Xna.Framework.Input.ButtonState.Pressed && InputManager.LastPlayer1State.Buttons.A == Microsoft.Xna.Framework.Input.ButtonState.Released)
            {
                if (currentItem == 0)
                {
                    Global.CurrentScreen = ScreenState.levelSelection;
                    resetScreen = true;
                }
                //else if (currentItem == 1)
                //{
                //    Global.CurrentScreen = ScreenState.option;
                //    resetScreen = true;
                //}
                else if (currentItem == 2)
                {
                    Global.CurrentScreen = ScreenState.credits;
                    resetScreen = true;
                }
                else if (currentItem == 3)
                {
                    EndGame = true;
                }
            }



            

            
          
            base.Update(gameTime);
        }

 

    }
}
