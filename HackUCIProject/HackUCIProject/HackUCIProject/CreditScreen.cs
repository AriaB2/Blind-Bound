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
        List<string> _names;
        string _sideKirbyOneText;
        string _sideKirbyTwoText;
        string _midKirbyText;

        WrapFadingFont _midKirbyFade;

        public CreditScreen(SpriteBatch spriteBatch, Vector2 location, int width, int height)
            : base(spriteBatch, location, width, height)
        {

        }


        public override void LoadContent(Microsoft.Xna.Framework.Content.ContentManager content)
        {
            _backGroundColor = Color.Black;

            _names = new List<string>();
            _names.Add("Abdurrahman Alatas");
            _names.Add("Aria Bidgoli");
            _names.Add("Rene Elias");
            _names.Add("Ben Villalobos");
            _names.Add("Font Effects Library - https://github.com/GreatMindsRobotics/FontEffectsLib");

            _sideKirbyOneText = "(>^_^)>";
            _sideKirbyTwoText = "<(^_^<)";
            _midKirbyText = "<(^_^)>";

            _midKirbyFade = new WrapFadingFont(content.Load<SpriteFont>("StartScreenSpriteFont3"), Vector2.Zero, Color.White, _spriteBatch);
            _midKirbyFade.Text.Append(_midKirbyText);
            _midKirbyFade.Origin = new Vector2(_midKirbyFade.Font.MeasureString(_midKirbyText).X / 2, _midKirbyFade.Font.MeasureString(_midKirbyText).Y / 2);
            _midKirbyFade.Position = new Vector2(_spriteBatch.GraphicsDevice.Viewport.Width / 2, _spriteBatch.GraphicsDevice.Viewport.Height / 2);
            _midKirbyFade.EnableShadow = false;
            _sprites.Add(_midKirbyFade);
        }


    }  
}
