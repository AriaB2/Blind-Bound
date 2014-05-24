using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using FontEffectsLib.SpriteTypes;
using FontEffectsLib.FontTypes;

namespace HackUCIProject
{

    public class StartScreen : Screen 
    {
        private WrapDropInFont _dropInFont;

        private SpriteFont _spriteFont;

        public StartScreen(SpriteBatch spriteBatch, Vector2 location, int width, int height, SpriteFont spriteFont)
            :base(spriteBatch, location, width, height)
        {
            _spriteFont = spriteFont;
        }

        public override void LoadContent(Microsoft.Xna.Framework.Content.ContentManager content)
        {
            _dropInFont = new WrapDropInFont(_spriteFont, _location, new Vector2(300, 300), new Vector2(5, 5), Color.Black, _spriteBatch);
            _dropInFont.Text.Append("NameOfGame");
            
            _dropInFont.EnableShadow = false;
            _sprites.Add(_dropInFont);
        }
    }
}
