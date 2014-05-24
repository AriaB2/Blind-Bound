using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace HackUCIProject
{
    public abstract class Screen
    {
        protected List<BaseSprite> _sprites;
        private RenderTarget2D _screen;
        protected SpriteBatch _spriteBatch;
        protected Vector2 _location;

        protected bool _isVisible;

        public Screen(SpriteBatch spriteBatch, Vector2 location, int width, int height)
        {
            _screen = new RenderTarget2D(spriteBatch.GraphicsDevice, width, height);
            _isVisible = true;
            _sprites = new List<BaseSprite>();
            _spriteBatch = spriteBatch;
        }

        public abstract void LoadContent(ContentManager content);

        public virtual void Update(GameTime gameTime)
        {
            foreach (BaseSprite sprite in _sprites)
            {
                sprite.Update(gameTime);
                sprite.UpdateHitBox();
            }
        }

        public void Render()
        {
            _spriteBatch.GraphicsDevice.SetRenderTarget(_screen);
            _spriteBatch.Begin();

            foreach (BaseSprite sprite in _sprites)
            {
                sprite.Draw();
            }

            _spriteBatch.End();
        }

        public void Draw()
        {
            if (_isVisible)
            {
                _spriteBatch.GraphicsDevice.SetRenderTarget(null);
                _spriteBatch.Begin();

                foreach (BaseSprite sprite in _sprites)
                {
                    sprite.Draw();
                }

                _spriteBatch.End();
            }
        }

    }
}
