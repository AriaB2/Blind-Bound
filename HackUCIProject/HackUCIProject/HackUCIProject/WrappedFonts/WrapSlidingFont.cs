using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FontEffectsLib.FontTypes;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace HackUCIProject.WrappedFonts
{
    public class WrapSlidingFont : SlidingFont, IXNA
    {
        private SpriteBatch _spriteBatch;

        public WrapSlidingFont(SpriteFont font, Vector2 startPosition, Vector2 endPosition, float slideSpeed, Color tintColor, SpriteBatch spriteBatch)
            : base(font, startPosition, endPosition, slideSpeed, tintColor)
        {
            _spriteBatch = spriteBatch;
        }

        public void Draw()
        {
            base.Draw(_spriteBatch);
        }
    }
}
