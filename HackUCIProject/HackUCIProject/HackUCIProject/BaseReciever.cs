using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace HackUCIProject
{
    public class BaseReciever : BaseSprite, ITriggerable
    {
        protected bool _triggered;
        public bool Triggered
        {
            get { return _triggered; }
        }

        public override void LoadContent(ContentManager content, string assetName, Vector2 location, Color tint, SpriteBatch batch)
        {
            _triggered = false;
            base.LoadContent(content, assetName, location, tint, batch);
        }
        public virtual void Trigger()
        {
            _triggered = !_triggered;
        }
    }
}
