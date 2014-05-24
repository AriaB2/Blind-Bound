using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using FontEffectsLib.FontTypes;

namespace HackUCIProject.WrappedFonts
{
    public class WrapAccelDropInFont : AccelDropInFont, IXNA
    {
        private SpriteBatch _spriteBatch;
        
        public WrapAccelDropInFont(SpriteFont font, Vector2 startPosition, Vector2 endPosition, Vector2 dropSpeed, Color tintColor, Vector2 accel, SpriteBatch spriteBatch)
            :base(font, startPosition, endPosition, dropSpeed, tintColor, accel)
        {
            _spriteBatch = spriteBatch;
        }
        
        public void Draw()
        {
            base.Draw(_spriteBatch);
        }
    }
}
