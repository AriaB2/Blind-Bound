using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using FontEffectsLib.FontTypes;

namespace HackUCIProject.WrappedFonts
{
    class WrapAccelDropInFont : DropInFont, IXNA
    {
        private SpriteBatch _spriteBatch;
        
        public WrapAccelDropInFont(SpriteFont font, Vector2 startPosition, Vector2 endPosition, Vector2 dropSpeed, Color tintColor, SpriteBatch spriteBatch)
            : base(font, startPosition, endPosition, dropSpeed, tintColor)
        {
            _spriteBatch = spriteBatch;
        }
        
        public void Draw()
        {
            base.Draw(_spriteBatch);
        }
    }
}
