using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;

namespace HackUCIProject
{
    public class BaseReciever : BaseSprite, ITriggerable
    {
        protected bool _triggered;
        public bool IsTriggered
        {
            get { return _triggered; }
        }

        private SoundEffect _sEffect;

        public SoundEffect SoundEffect
        {
            get { return _sEffect; }
            set { _sEffect = value; }
        }


        public override void LoadContent(ContentManager content, string assetName, Vector2 location, Color tint, SpriteBatch batch)
        {
            _triggered = false;
            base.LoadContent(content, assetName, location, tint, batch);
        }
        public virtual void Trigger()
        {
            if (_sEffect != null)
            {
                _sEffect.Play();
            }
            _triggered = !_triggered;
        }
    }
}
