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
    class StartScreen : Screen
    {
        private DropInFont _firstText;
        

        public StartScreen(SpriteBatch spriteBatch, Vector2 location, int width, int height)
            :base(spriteBatch, location, width, height)
        {
            
        }

        public override void LoadContent(Microsoft.Xna.Framework.Content.ContentManager content)
        {
            _firstText = new DropInFont(content.Load<SpriteFont>("SpriteScreenSpriteFont"), new Vector2(0, 0), new Vector2(300, 300), new Vector2(5, 5), Color.White);
        }
    }
}
