using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace HackUCIProject
{
    public class TrapDoor : BaseReciever
    {
        private Texture2D _trapDoorUp;

        public Texture2D TrapDoorUp
        {
            get { return _trapDoorUp; }
            set { _trapDoorUp = value; }
        }

        private Texture2D _trapDoorDown;

        public Texture2D TrapDoorDown
        {
            get { return _trapDoorDown; }
            set { _trapDoorDown = value; }
        }

        public override void LoadContent(Microsoft.Xna.Framework.Content.ContentManager content, string assetName, Microsoft.Xna.Framework.Vector2 location, Microsoft.Xna.Framework.Color tint, SpriteBatch batch)
        {
            _trapDoorDown = content.Load<Texture2D>("LevelMap\\TrapdoorOpen");
            _trapDoorUp = content.Load<Texture2D>("LevelMap\\TrapdoorFull");
            base.LoadContent(content, assetName, location, tint, batch);
        }

        public override void Trigger()
        {
            if (_triggered)
            {
                _image = _trapDoorDown;
            }
            else
            {
                _image = _trapDoorUp;
            }
            base.Trigger();
        }
    }
}
