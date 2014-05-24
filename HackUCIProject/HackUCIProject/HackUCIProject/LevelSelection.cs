using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace HackUCIProject
{
    public class LevelSelection : Screen
    {
        protected BaseSprite _map;

        public LevelSelection( SpriteBatch spriteBatch, Vector2 location, int width, int height):
            base( spriteBatch, location, width, height)
        {

        }
        public override void LoadContent(Microsoft.Xna.Framework.Content.ContentManager content)
        {
            _map = new BaseSprite();
            _map.LoadContent(content, "LevelMap/SacredDonutLevel", new Vector2(_spriteBatch.GraphicsDevice.Viewport.Width / 2, _spriteBatch.GraphicsDevice.Viewport.Height / 2), Color.White, 0f, Vector2.Zero, new Vector2(.25f, .25f), SpriteEffects.None,_spriteBatch, 0f);
            _map.Origin = new Vector2(_map.Image.Width / 2, _map.Image.Height / 2);
            _sprites.Add(_map);
        }

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            base.Update(gameTime);
        }
    }
}
