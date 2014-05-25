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
    public class CreditScreen : Screen
    {
        
        string _sideKirbyOneText;
        string _sideKirbyTwoText;
        string _midKirbyText;

        List<WrapSlidingFont> _creditSlideList;
        List<WrapFadingFont> _creditFadeList;

        int creditSlideStateCounter = 0;

        List<string> _creditNames;

        WrapFadingFont _midKirbyFade;
        WrapDropInFont _midKirbyBounce;
        WrapDropInFont _leftKirbyPartOne;
        WrapDropInFont _rightKirbyPartOne;
        WrapSlidingFont _leftKirbyPartTwo;
        WrapSlidingFont _rightKirbyPartTwo;


        TimeSpan _compressElapsedGameTime;
        TimeSpan _timeForCompress = new TimeSpan(0, 0, 0, 0, 60);

        TimeSpan _expandElapsedGameTime;
        TimeSpan _timeforExpand = new TimeSpan(0, 0, 0, 0, 60);

        bool _compress = false;
        bool _startBounce = false;

        int slidePositionY;
        int slideTargetY;

        int fadePositionY;



        public CreditScreen(SpriteBatch spriteBatch, Vector2 location, int width, int height)
            : base(spriteBatch, location, width, height)
        {

        }


        public override void LoadContent(Microsoft.Xna.Framework.Content.ContentManager content)
        {
            _backGroundColor = Color.Black;

            _sideKirbyOneText = "(>^_^)>";
            _sideKirbyTwoText = "<(^_^<)";
            _midKirbyText = "<(^_^)>";

            _midKirbyFade = new WrapFadingFont(content.Load<SpriteFont>("Fonts/StartScreenSpriteFont3"), Vector2.Zero, Color.White, _spriteBatch);
            _midKirbyFade.Text.Append(_midKirbyText);
            _midKirbyFade.Origin = new Vector2(_midKirbyFade.Font.MeasureString(_midKirbyText).X / 2, _midKirbyFade.Font.MeasureString(_midKirbyText).Y / 2);
            _midKirbyFade.Position = new Vector2(_spriteBatch.GraphicsDevice.Viewport.Width / 2, _midKirbyFade.Font.MeasureString(_midKirbyText).Y / 2);
            _midKirbyFade.EnableShadow = false;
            _sprites.Add(_midKirbyFade);

            _midKirbyBounce = new WrapDropInFont(content.Load<SpriteFont>("Fonts/StartScreenSpriteFont3"), Vector2.Zero, Vector2.Zero, new Vector2(1.5f, 1.5f), Color.White, _spriteBatch);
            _midKirbyBounce.Text.Append(_midKirbyText);
            _midKirbyBounce.SetCenterAsOrigin();
            _midKirbyBounce.EnableShadow = false;
            _midKirbyBounce.IsVisible = false;
            _sprites.Add(_midKirbyBounce);

            _creditSlideList = new List<WrapSlidingFont>();
            _creditFadeList = new List<WrapFadingFont>();
            _creditNames = new List<string>();

            
            _creditNames.Add("Abdurrahman Alatas");
            _creditNames.Add("Aria Bidgoli");
            _creditNames.Add("Rene Elias");
            _creditNames.Add("Ben Villalobos");
            _creditNames.Add("Font Effects Library");
            _creditNames.Add("(https://github.com/GreatMindsRobotics/FontEffectsLib)");

            slidePositionY = _screen.Height;
            slideTargetY = 100;

            for (int i = 0; i < _creditNames.Count(); i++)
            {
                WrapSlidingFont tempFont;
                if (i == _creditNames.Count - 1)
                {
                    tempFont = new WrapSlidingFont(content.Load<SpriteFont>("Fonts/StartScreenSpriteFont0"), Vector2.Zero, Vector2.Zero, 0.2f, Color.White, _spriteBatch);
                }
                else
                {
                    tempFont = new WrapSlidingFont(content.Load<SpriteFont>("Fonts/StartScreenSpriteFont2"), Vector2.Zero, Vector2.Zero, 0.2f, Color.White, _spriteBatch);
                }
                
                _creditSlideList.Add(tempFont);
                _creditSlideList[i].Text.Append(_creditNames[i]);
                _creditSlideList[i].Origin = new Vector2(_creditSlideList[i].Font.MeasureString(_creditNames[i]).X / 2, _creditSlideList[i].Font.MeasureString(_creditNames[i]).Y / 2);
                _creditSlideList[i].Position = new Vector2(_screen.Width / 2, slidePositionY);
                _creditSlideList[i].TargetPosition = new Vector2(_screen.Width / 2, slideTargetY);
                slidePositionY += 50;
                slideTargetY += 50;
            }

            /*
            for (int i = 0; i < _creditNames.Count(); i++)
            {
                WrapFadingFont tempFont;
                if (i == _creditNames.Count - 1)
                {
                    tempFont = new WrapFadingFont(content.Load<SpriteFont>("Fonts/StartScreenSpriteFont0"), Vector2.Zero, Color.White, _spriteBatch);
                }
                else if (i == 0 || i == 5 || i == 7)
                {
                    tempFont = new WrapFadingFont(content.Load<SpriteFont>("Fonts/StartScreenSpriteFont4"), Vector2.Zero, Color.White, _spriteBatch);
                }
                else
                {
                    tempFont = new WrapFadingFont(content.Load<SpriteFont>("Fonts/StartScreenSpriteFont2"), Vector2.Zero, Color.White, _spriteBatch);
                }
                _creditFadeList.Add(tempFont);
                _creditFadeList[i].Text.Append(_creditNames[i]);
                _creditFadeList[i].Origin = new Vector2(_creditFadeList[i].Font.MeasureString(_creditNames[i]).X / 2, _creditFadeList[i].Font.MeasureString(_creditNames[i]).Y / 2);
                _creditFadeList[i].Position = new Vector2(_screen.Width / 2, fadePositionY);
                
            }
             * */

            foreach (WrapSlidingFont creditText in _creditSlideList)
            {
                _sprites.Add(creditText);
            }

            _leftKirbyPartOne = new WrapDropInFont(content.Load<SpriteFont>("Fonts/StartScreenSpriteFont3"), Vector2.Zero, Vector2.Zero, new Vector2(1.5f, 1.5f), Color.White, _spriteBatch);
            _leftKirbyPartOne.Text.Append(_sideKirbyOneText);
            _leftKirbyPartOne.Position = new Vector2(_screen.Width / 2 - _leftKirbyPartOne.Font.MeasureString(_sideKirbyOneText).X / 2, 0);
            _leftKirbyPartOne.Origin = new Vector2(_leftKirbyPartOne.Font.MeasureString(_sideKirbyOneText).X / 2, _leftKirbyPartOne.Font.MeasureString(_sideKirbyOneText).Y / 2);
            _leftKirbyPartOne.TargetPosition = new Vector2(_screen.Width / 2 - _leftKirbyPartOne.Font.MeasureString(_sideKirbyOneText).X / 2, _screen.Height / 2);
            _leftKirbyPartOne.EnableShadow = false;
            _sprites.Add(_leftKirbyPartOne);

            _leftKirbyPartTwo = new WrapSlidingFont(content.Load<SpriteFont>("Fonts/StartScreenSpriteFont3"), _leftKirbyPartOne.TargetPosition, Vector2.Zero, 1.0f, Color.White, _spriteBatch);
            _leftKirbyPartTwo.Text.Append(_sideKirbyOneText);
            _leftKirbyPartTwo.TargetPosition = new Vector2(_leftKirbyPartTwo.Font.MeasureString(_sideKirbyOneText).X / 2 + 10, _leftKirbyPartOne.TargetPosition.Y);
            _leftKirbyPartTwo.Origin = _leftKirbyPartOne.Origin;
            _leftKirbyPartTwo.EnableShadow = false;
            _leftKirbyPartTwo.IsVisible = false;
            _sprites.Add(_leftKirbyPartTwo);
            

            _rightKirbyPartOne = new WrapDropInFont(content.Load<SpriteFont>("Fonts/StartScreenSpriteFont3"), Vector2.Zero, Vector2.Zero, new Vector2(1.5f, 1.5f), Color.White, _spriteBatch);
            _rightKirbyPartOne.Text.Append(_sideKirbyTwoText);
            _rightKirbyPartOne.EnableShadow = false;
            _rightKirbyPartOne.Position = new Vector2(_screen.Width / 2 + _rightKirbyPartOne.Font.MeasureString(_sideKirbyTwoText).X / 2, 0);
            _rightKirbyPartOne.Origin = new Vector2(_rightKirbyPartOne.Font.MeasureString(_sideKirbyTwoText).X / 2, _rightKirbyPartOne.Font.MeasureString(_sideKirbyTwoText).Y / 2);
            _rightKirbyPartOne.TargetPosition = new Vector2(_screen.Width / 2 + _rightKirbyPartOne.Font.MeasureString(_sideKirbyTwoText).X / 2, _screen.Height / 2);
            _rightKirbyPartOne.StateChanged += new EventHandler<FontEffectsLib.CoreTypes.StateEventArgs>(_rightKirbyPartOne_StateChanged);
            _sprites.Add(_rightKirbyPartOne);

            _rightKirbyPartTwo = new WrapSlidingFont(content.Load<SpriteFont>("Fonts/StartScreenSpriteFont3"), _rightKirbyPartOne.TargetPosition, Vector2.Zero, 1.0f, Color.White, _spriteBatch);
            _rightKirbyPartTwo.Text.Append(_sideKirbyTwoText);
            _rightKirbyPartTwo.EnableShadow = false;
            _rightKirbyPartTwo.TargetPosition = new Vector2(_screen.Width - _rightKirbyPartTwo.Font.MeasureString(_sideKirbyTwoText).X / 2 - 10, _rightKirbyPartOne.TargetPosition.Y);
            _rightKirbyPartTwo.Origin = _leftKirbyPartTwo.Origin;
            _rightKirbyPartTwo.IsVisible = false;
            _rightKirbyPartTwo.StateChanged += new EventHandler<FontEffectsLib.CoreTypes.StateEventArgs>(_rightKirbyPartTwo_StateChanged);
            _sprites.Add(_rightKirbyPartTwo);

            
            
            

        }

     
        void _rightKirbyPartTwo_StateChanged(object sender, FontEffectsLib.CoreTypes.StateEventArgs e)
        {
            if (_rightKirbyPartTwo.State == SlidingFont.FontState.Done)
            {
                _rightKirbyPartTwo.IsVisible = false;
                _leftKirbyPartTwo.IsVisible = false;
                _midKirbyFade.IsVisible = false;

                _midKirbyBounce.IsVisible = true;
                _midKirbyBounce.Position = _midKirbyFade.Position;
                _midKirbyBounce.TargetPosition = _midKirbyFade.Position;

                _rightKirbyPartOne.StateChanged -= new EventHandler<FontEffectsLib.CoreTypes.StateEventArgs>(_rightKirbyPartOne_StateChanged);
                
                _leftKirbyPartOne.Position = _leftKirbyPartTwo.TargetPosition;
                _leftKirbyPartOne.IsVisible = true;
                _leftKirbyPartOne.TargetPosition = _leftKirbyPartOne.Position;

                _rightKirbyPartOne.Position = _rightKirbyPartTwo.TargetPosition;
                _rightKirbyPartOne.IsVisible = true;
                _rightKirbyPartOne.TargetPosition = _rightKirbyPartOne.Position;
                
                _compressElapsedGameTime = new TimeSpan();
                _compress = true;

                _expandElapsedGameTime = new TimeSpan();

                _startBounce = true;

                slideTargetY = 100;

                for (int i = 0; i < _creditSlideList.Count; i++ )
                {
                    _creditSlideList[i].Slide();
                }
            }
        }

        void _rightKirbyPartOne_StateChanged(object sender, FontEffectsLib.CoreTypes.StateEventArgs e)
        {
            if (_rightKirbyPartOne.State == DropInFont.FontState.Done)
            {
                _rightKirbyPartOne.IsVisible = false;
                _leftKirbyPartTwo.IsVisible = true;
                _leftKirbyPartTwo.Slide();
                
                _leftKirbyPartOne.IsVisible = false;
                _rightKirbyPartTwo.IsVisible = true;
                _rightKirbyPartTwo.Slide();
                
            }
        }

        public override void Update(GameTime gameTime)
        {

            if (_startBounce == true)
            {
                if (_compress == true && _leftKirbyPartOne.State == DropInFont.FontState.Done)
                {
                    _compressElapsedGameTime += gameTime.ElapsedGameTime;
                    if (_compressElapsedGameTime >= _timeForCompress)
                    {
                        _rightKirbyPartOne.State = DropInFont.FontState.Compress;
                        _leftKirbyPartOne.State = DropInFont.FontState.Compress;
                        _midKirbyBounce.State = DropInFont.FontState.Compress;
                        _compress = false;
                        _compressElapsedGameTime = new TimeSpan();
                    }
                }
                if (_compress == false && _leftKirbyPartOne.State == DropInFont.FontState.Done)
                {
                    _expandElapsedGameTime += gameTime.ElapsedGameTime;
                    if (_expandElapsedGameTime >= _timeforExpand)
                    {
                        _rightKirbyPartOne.State = DropInFont.FontState.Expand;
                        _leftKirbyPartOne.State = DropInFont.FontState.Expand;
                        _midKirbyBounce.State = DropInFont.FontState.Expand;
                        _compress = true;
                        _expandElapsedGameTime = new TimeSpan();
                    }
                }
            }

            if (InputManager.CurrentPlayer1State.IsButtonDown(Microsoft.Xna.Framework.Input.Buttons.B))
            {
                Global.CurrentScreen = ScreenState.startMenu;
            }

            base.Update(gameTime);
        }


    }  
}
