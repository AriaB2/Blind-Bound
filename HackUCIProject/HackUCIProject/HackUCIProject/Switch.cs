using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace HackUCIProject
{
    public class Switch : BaseSprite
    {
        private Player _player;

        public Player Player
        {
            get { return _player; }
            set { _player = value; }
        }

        public override void Update(GameTime gameTime)
        {
            
            base.Update(gameTime);
        }
        
    }
}
