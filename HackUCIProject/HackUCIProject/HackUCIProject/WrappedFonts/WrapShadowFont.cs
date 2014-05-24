using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FontEffectsLib.FontTypes;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;


namespace HackUCIProject.WrappedFonts
{
    public class WrapShadowFont : ShadowFont, IXNA
    {
        private SpriteBatch _spriteBatch;

        public WrapShadowFont(SpriteFont font, Vector2 position, Color tintColor, SpriteBatch spriteBatch)
            : base(font, position, tintColor)
        {
            _spriteBatch = spriteBatch;
        }

        public void Draw()
        {
            base.Draw(_spriteBatch);
        }
    }
}
