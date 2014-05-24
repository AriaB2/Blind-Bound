using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace HackUCIProject
{
    public class PixelDetectionSprite : MovingSprite
    {
        private Texture2D _keyMap;

        public Texture2D KeyMap
        {
            get { return _keyMap; }
            set { _keyMap = value; }
        }

        private bool canMoveHorizontally;
        private bool canMoveVertically;

        public virtual void Update(GameTime gameTime, Vector2 boundaries)
        {
            Rectangle areaToCheck = new Rectangle((int)Left, (int)Top, 0, 0);
            Color[] pixels;
            canMoveVertically = true;
            canMoveHorizontally = true;
            if (_speed.X < 0)
            {
                areaToCheck.X -= 1;
                if (areaToCheck.X <= 0)
                {
                    canMoveHorizontally = false;
                    areaToCheck.X = 0;
                }
                areaToCheck.Height = (int)Height;
                areaToCheck.Width = 1;
                
                if (canMoveHorizontally)
                {
                    pixels = new Color[areaToCheck.Width * areaToCheck.Height];
                    _keyMap.GetData<Color>(0, areaToCheck, pixels, 0, pixels.Length);
                    foreach (Color c in pixels)
                    {
                        if (c == Color.Black)
                        {
                            canMoveHorizontally = false;
                            break;
                        }
                    }
                }
            }
            else if (_speed.X > 0)
            {
                areaToCheck.X = (int)Right;
                areaToCheck.Height =  (int)Height;
                areaToCheck.Width = 1;
                if (areaToCheck.Right + areaToCheck.Width >= boundaries.X)
                {
                    canMoveHorizontally = false;
                }

                if (canMoveHorizontally)
                {
                    pixels = new Color[areaToCheck.Width * areaToCheck.Height];
                    _keyMap.GetData<Color>(0, areaToCheck, pixels, 0, pixels.Length);
                    foreach (Color c in pixels)
                    {
                        if (c == Color.Black)
                        {
                            canMoveHorizontally = false;
                            break;
                        }
                    }
                }
            }
            if (_speed.Y < 0)
            {
                areaToCheck.X = (int)Left;
                areaToCheck.Y -= 1;
                if (areaToCheck.Y <= 0)
                {
                    areaToCheck.Y = 0;
                    canMoveVertically = false;
                }
                areaToCheck.Width = (int)Width;
                areaToCheck.Height = 1;

                if (canMoveVertically)
                {
                    pixels = new Color[areaToCheck.Width * areaToCheck.Height];
                    _keyMap.GetData<Color>(0, areaToCheck, pixels, 0, pixels.Length);
                    foreach (Color c in pixels)
                    {
                        if (c == Color.Black)
                        {
                            canMoveVertically = false;
                            break;
                        }
                    }
                }
            }
            else if (_speed.Y > 0)
            {
                areaToCheck.X = (int)Left;
                areaToCheck.Y = (int)Bottom;
                areaToCheck.Width = (int)Width;
                areaToCheck.Height = 1;
                if (areaToCheck.Bottom >= boundaries.Y)
                {
                    canMoveVertically = false;
                }

                if (canMoveVertically)
                {
                    pixels = new Color[areaToCheck.Width * areaToCheck.Height];
                    _keyMap.GetData<Color>(0, areaToCheck, pixels, 0, pixels.Length);
                    foreach (Color c in pixels)
                    {
                        if (c == Color.Black)
                        {
                            canMoveVertically = false;
                            break;
                        }
                    }
                }
            }
            if (!canMoveHorizontally)
            {
                _speed.X = 0;
            }
            else
            {

            }
            if (!canMoveVertically)
            {
                _speed.Y = 0;
            }
            else
            {

            }

            base.Update(gameTime);
        }

        public void LoadContent(ContentManager content, string assetName, Vector2 location, Color tint, SpriteBatch batch, string keyMapAssetName)
        {
            _keyMap = content.Load<Texture2D>(keyMapAssetName);
            base.LoadContent(content, assetName, location, tint, batch);
        }
    }
}
