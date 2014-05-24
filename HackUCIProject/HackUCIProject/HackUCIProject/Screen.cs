using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace HackUCIProject
{
    public abstract class Screen : IXNA
    {
        protected List<IXNA> _sprites;

        public List<IXNA> Sprites
        {
            get
            {
                return _sprites;
            }
        }
        protected RenderTarget2D _screen;
        protected SpriteBatch _spriteBatch;
        protected Vector2 _location;
        protected Color _backGroundColor;

        public Color BackGroundColor
        {
            get
            {
                
                return _backGroundColor;
            }
            set
            {
                _backGroundColor = value;
            }
        }
        
        protected bool _isVisible;

        protected SpriteSortMode _sortMode;
        protected BlendState _blendState;
        protected SamplerState _samplerState;
        protected DepthStencilState _depthStencilState;
        protected RasterizerState _rasterizerState;
        protected Camera2DMatrix _camera;

        public Screen(SpriteBatch spriteBatch, Vector2 location, int width, int height)
        {
            _screen = new RenderTarget2D(spriteBatch.GraphicsDevice, width, height);
            _isVisible = true;
            _sprites = new List<IXNA>();
            _spriteBatch = spriteBatch;
            _backGroundColor = Color.White;
            _location = location;

            _sortMode = SpriteSortMode.Deferred;
            _blendState = BlendState.AlphaBlend;
            _samplerState = SamplerState.LinearClamp;
            _rasterizerState = RasterizerState.CullCounterClockwise;
            _camera = new Camera2DMatrix();
            _camera.Pos = location + new Vector2(width / 2, height / 2);
        }

        public abstract void LoadContent(ContentManager content);

        public virtual void Update(GameTime gameTime)
        {
            foreach (IXNA sprite in _sprites)
            {
                sprite.Update(gameTime);
            }
        }

        public virtual void Render()
        {
            _spriteBatch.GraphicsDevice.SetRenderTarget(_screen);
            _spriteBatch.GraphicsDevice.Clear(_backGroundColor);
            _spriteBatch.Begin(_sortMode, _blendState, _samplerState, _depthStencilState, _rasterizerState, null, _camera.GetTransformation(_spriteBatch.GraphicsDevice));
            
            
            foreach (IXNA sprite in _sprites)
            {
                sprite.Draw();
            }

            _spriteBatch.End();
        }

        public virtual void Draw()
        {
            if (_isVisible)
            {
                _spriteBatch.GraphicsDevice.SetRenderTarget(null);
                _spriteBatch.Begin();

                _spriteBatch.Draw(_screen, _location, Color.White);

                _spriteBatch.End();
            }
        }

    }
}
