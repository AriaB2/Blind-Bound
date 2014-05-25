using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace HackUCIProject
{
    public class Ghost : Player
    {
        public Ghost(PlayerIndex player)
            : base(player)
        {

        }
        private Texture2D _rightImage;

        public Texture2D RightImage
        {
            get { return _rightImage; }
            set { _rightImage = value; }
        }

        private Texture2D _upImage;

        public Texture2D UpImage
        {
            get { return _upImage; }
            set { _upImage = value; }
        }

        private Texture2D _downImage;

        public Texture2D DownImage
        {
            get { return _downImage; }
            set { _downImage = value; }
        }

        public override void LoadContent(Microsoft.Xna.Framework.Content.ContentManager content, string assetName, Vector2 location, Color tint, SpriteBatch batch, string keyMapAssetName)
        {
            DownImage = content.Load<Texture2D>("Ghost");
            UpImage = content.Load<Texture2D>("GhostBack");
            RightImage = content.Load<Texture2D>("GhostTurning");
            base.LoadContent(content, assetName, location, tint, batch, keyMapAssetName);
        }

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            base.Update(gameTime);
            if (_speed.X < 0)
            {
                _spriteEffects = Microsoft.Xna.Framework.Graphics.SpriteEffects.FlipHorizontally;
                _image = _rightImage;

            }
            else if (_speed.X > 0)
            {
                _spriteEffects = Microsoft.Xna.Framework.Graphics.SpriteEffects.None;
                _image = _rightImage;
            }
            if (_speed.Y < 0)
            {
                _image = _upImage;
            }
            else if (_speed.Y > 0)
            {
                _image = _downImage;
            }
        }
    }
}
