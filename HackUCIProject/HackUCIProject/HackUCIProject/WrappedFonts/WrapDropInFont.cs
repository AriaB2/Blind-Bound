using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FontEffectsLib.FontTypes;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace HackUCIProject
{
    class WrapDropInFont : DropInFont, IXNA
    {
        private SpriteBatch _spriteBatch;

        public WrapDropInFont(SpriteFont font, Vector2 startPosition, Vector2 endPosition, Vector2 dropSpeed, Color tintColor, SpriteBatch spriteBatch)
            :base(font, startPosition, endPosition, dropSpeed, tintColor)
        {
            _spriteBatch = spriteBatch;
        }

        public void Draw()
        {
            base.Draw(_spriteBatch);
        }
    }
}
