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
        private WrapDropInFont _dropInFont;
        private WrapAccelDropInFont _accelDropInFont;
        private WrapArcadeFont _arcadeFont;
        private WrapFadingFont _fadingFont;
        private WrapGameFont _gameFont;
        private WrapShadowFont _shadowFont;
        private WrapSlidingFont _slidingFont;
        

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
            _dropInFont = new WrapDropInFont(_spriteFontList[0], Vector2.Zero, new Vector2(0, 400), new Vector2(1, 1), Color.Black, _spriteBatch);
            _dropInFont.Text.Append("NameOfGame");
            _dropInFont.EnableShadow = false;
            _sprites.Add(_dropInFont);

            _accelDropInFont = new WrapAccelDropInFont(_spriteFontList[0], new Vector2(150,0), new Vector2(150, 400), new Vector2(0, 1), Color.BlueViolet, new Vector2(0, 2), _spriteBatch);
            _accelDropInFont.Text.Append("SwagOfGame");
            _sprites.Add(_accelDropInFont);

        }
    }
}
