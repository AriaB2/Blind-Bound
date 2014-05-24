using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FontEffectsLib.FontTypes;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;


namespace HackUCIProject.WrappedFonts
{
    public class WrapFadingFont : FadingFont, IXNA
    {
        private SpriteBatch _spriteBatch;

        public WrapFadingFont(SpriteFont font, Vector2 position, Color tintColor, SpriteBatch spriteBatch)
        :base(font, position, tintColor)
        {
            _spriteBatch = spriteBatch;
        }

        public void Draw()
        {
            base.Draw(_spriteBatch);
        }
    }
}
