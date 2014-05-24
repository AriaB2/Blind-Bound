using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
public class MovingSprite : AnimatedSprite
{
    //Variables
    #region

    protected Vector2 _speed;

    public Vector2 Speed
    {
        get { return _speed; }
        set { _speed = value; }
    }

    public virtual void LoadContent(ContentManager content, string assetName, Texture2D image, Vector2 location, Color tint, float rotation, Vector2 origin, Vector2 scale, SpriteEffects spriteEffects, Vector2 speed, float layerDepth, SpriteBatch spriteBatch)
    {
        _speed = speed;
        base.LoadContent(content, assetName, location, tint, rotation, origin, scale, spriteEffects, spriteBatch, layerDepth);
    }

    public override void Update(GameTime gameTime)
    {
        _location += _speed;
        base.Update(gameTime);
    }

    #endregion

}

