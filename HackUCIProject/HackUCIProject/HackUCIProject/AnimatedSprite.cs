using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
public class AnimatedSprite : BaseSprite
    {

        protected List<Rectangle> _frames;

        public List<Rectangle> FramesArray
        {
            get { return _frames; }
            set { _frames = value; }
        }


        public virtual void LoadContent(ContentManager content, string assetName, Vector2 location, Rectangle? sourceRectangle, Color tint, float rotation, Vector2 origin, Vector2 scale, SpriteEffects spriteEffects, SpriteBatch spriteBatch, float layerDepth)
        {
            _frame = sourceRectangle;
            base.LoadContent(content, assetName,  location, tint, rotation, origin, scale, spriteEffects, spriteBatch, layerDepth);
        }
    }

