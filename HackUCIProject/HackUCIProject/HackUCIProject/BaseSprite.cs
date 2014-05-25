
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace HackUCIProject
{
    public class BaseSprite : IXNA
    {
        //variables
        #region

        public float Left
        {
            get
            {
                return _location.X - Origin.X * Scale.X;
            }
        }

        public float Right
        {
            get
            {
                if (_frame != null)
                {
                    return _location.X + (_frame.Value.Width * _scale.X) - _origin.X * Scale.X ;
                }
                return _location.X + (_image.Width * _scale.X) - _origin.X * _scale.X;
            }
        }

        public float Top
        {
            get
            {
                return _location.Y - _origin.Y * Scale.Y;
            }
        }

        public float Bottom
        {
            get
            {
                if (_frame != null)
                {
                    return _location.Y - _origin.Y * _scale.Y + (_frame.Value.Height*_scale.Y);
                }
                return _location.Y - _origin.Y * _scale.Y + (_image.Height * _scale.Y);
            }
        }

        protected Texture2D _image;

        public Texture2D Image
        {
            get { return _image; }
            set { _image = value; }
        }

        protected Vector2 _location;

        public Vector2 Location
        {
            get { return _location; }
            set { _location = value; }
        }

        protected Color _tint;

        public Color Tint
        {
            get { return _tint; }
            set { _tint = value; }
        }

        protected SpriteBatch _spriteBatch;

        protected Rectangle _hitBox;

        public Rectangle HitBox
        {
            get { return _hitBox; }
            set { _hitBox = value; }
        }

        protected Vector2 _origin;

        public Vector2 Origin
        {
            get { return _origin; }
            set { _origin = value; }
        }

        protected Vector2 _scale;

        public Vector2 Scale
        {
            get { return _scale; }
            set 
            {
                _scale = value;
                _hitBox.Width = (int)((float)_image.Width * _scale.X);
                _hitBox.Height = (int)((float)_image.Height * _scale.Y);
            }
        }

        protected Rectangle? _frame;

        public Rectangle? Frame
        {
            get { return _frame; }
            set
            {
                _frame = value;
                _hitBox.Width = _frame.Value.Width;
                _hitBox.Height = _frame.Value.Height;
            }
        }

        protected float _rotation;

        public float Rotation
        {
            get { return _rotation; }
            set { _rotation = value; }
        }

        protected SpriteEffects _spriteEffects;

        public SpriteEffects SpriteEffects
        {
            get { return _spriteEffects; }
            set { _spriteEffects = value; }
        }

        protected float _layerDepth;

        public float LayerDepth
        {
            get { return _layerDepth; }
            set { _layerDepth = value; }
        }

        public float Width
        {
            get
            {
                if (_frame != null)
                {
                    return _frame.Value.Width * _scale.X;
                }
                return _image.Width * _scale.X;
            }
        }

        public float Height
        {
            get
            {
                if (_frame != null)
                {
                    return _frame.Value.Height * _scale.Y;
                }
                return _image.Height * _scale.Y;
            }
        }


        #endregion

        //functions
        #region

        public void SetOriginCenter()
        {
            if (_frame != null)
            {
                _origin = new Vector2(_frame.Value.Width / 2, _frame.Value.Height / 2);
                return;
            }
            _origin = new Vector2(_image.Width / 2, _image.Height / 2);
        }

        public virtual void Update(GameTime gameTime)
        {
            UpdateHitBox(); 
        }



        public void UpdateHitBox()
        {
            _hitBox.X = (int)Left;
            _hitBox.Y = (int)Top;
        }

        public virtual void LoadContent(ContentManager content, string assetName, Vector2 location, Color tint, float rotation, Vector2 origin, Vector2 scale, SpriteEffects spriteEffects, SpriteBatch spriteBatch, float layerDepth)
        {
            _image = content.Load<Texture2D>(assetName);
            _location = location;
            _tint = tint;
            _origin = origin;
            _rotation = rotation;
            _scale = scale;
            _spriteEffects = spriteEffects;
            _spriteBatch = spriteBatch;
            _layerDepth = layerDepth;
            _frame = null;
            _hitBox = new Rectangle((int)_location.X, (int)_location.Y, (int)Width, (int)Height);
        }

        public virtual void LoadContent(ContentManager content, string assetName, Vector2 location, Color tint, SpriteBatch batch)
        {
            _image = content.Load<Texture2D>(assetName);
            _tint = tint;
            _location = location;
            _spriteBatch = batch;
            _origin = Vector2.Zero;
            _rotation = 0f;
            _scale = Vector2.One;
            _frame = null;
            _spriteEffects = SpriteEffects.None;
            _layerDepth = 0;
            _hitBox = new Rectangle((int)Left, (int)Top, (int)Width, (int)Height);
        }

        public virtual void Draw()
        {
            _spriteBatch.Draw(_image, _location, _frame, _tint, _rotation, _origin, _scale, _spriteEffects, _layerDepth);
        }

        #endregion
    }

}
