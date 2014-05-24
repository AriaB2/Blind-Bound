using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FontEffectsLib.FontTypes;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;


namespace HackUCIProject.WrappedFonts
{
    class WrapArcadeFont : ArcadeFont, IXNA
    {
        private SpriteBatch _spriteBatch;

        public WrapArcadeFont(SpriteFont font, Vector2 position, Color[] colors, SpriteBatch spriteBatch)
            :base(font, position, colors)
        {
            _spriteBatch = spriteBatch;
        }
        
        public void Draw()
        {
            base.Draw(_spriteBatch);
        }
    }
}
