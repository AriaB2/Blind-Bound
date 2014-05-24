using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;

namespace HackUCIProject
{
    public class Bridge : BaseReciever
    {
        public Bridge(BridgeSide side)
        {
            _side = side;
        }
        private BridgeSide _side;

        public BridgeSide Side
        {
            get { return _side; }
            set { _side = value; }
        }

        private Texture2D _retractedTexture;

        public Texture2D RetractedTexture
        {
            get { return _retractedTexture; }
            set { _retractedTexture = value; }
        }

        private Texture2D _extendedTexture;

        public Texture2D ExtendedTexture
        {
            get { return _extendedTexture; }
            set { _extendedTexture = value; }
        }

        public void LoadContent(ContentManager content, string assetName, Vector2 location, Color tint, SpriteBatch batch, string retractedAsset, string extendedAsset)
        {
            _retractedTexture = content.Load<Texture2D>(retractedAsset);
            _extendedTexture = content.Load<Texture2D>(extendedAsset);
            base.LoadContent(content, assetName, location, tint, batch);
        }
        public override void Trigger()
        {
            if (_triggered)
            {
                if (_side == BridgeSide.Right)
                {
                    _location.X += Width;
                }
                _image = _retractedTexture;
            }
            else
            {
                _image = _extendedTexture;
                if (_side == BridgeSide.Right)
                {
                    _location.X -= Width;
                }
            }


            base.Trigger();
        }
    }
}
