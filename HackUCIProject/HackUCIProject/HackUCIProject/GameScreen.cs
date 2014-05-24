using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace HackUCIProject
{
    public class GameScreen : Screen
    {
        

        public GameScreen(SpriteBatch spriteBatch, Vector2 location, int width, int height):
            base(spriteBatch, location, width, height)
        {
            _backGroundColor = Color.White;
        }

        public override void LoadContent(Microsoft.Xna.Framework.Content.ContentManager content)
        {
            
        }

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {



            base.Update(gameTime);
        }

    }
}
