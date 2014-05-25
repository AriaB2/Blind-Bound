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

        private Camera2DMatrix _camera;

        public Camera2DMatrix Camera
        {
            get { return _camera; }
            set { _camera = value; }
        }

        private Vector2 _screenSize;

        public Vector2 ScreenSize
        {
            get { return _screenSize; }
            set { _screenSize = value; }
        }

        private Vector2 _boundaries;

        public Vector2 Boundaries
        {
            get { return _boundaries; }
            set { _boundaries = value; }
        }


        private bool canMoveHorizontally;
        private bool canMoveVertically;

        public override void Update(GameTime gameTime)
        {
            //Rectangle areaToCheck = new Rectangle((int)Left - ((int)_camera.Pos.X - (int)_screenSize.X / 2), (int)Top - ((int)_camera.Pos.Y - (int)_screenSize.Y / 2), 0, 0);
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
                        else
                        {
                            break;
                        }
                    }
                }
            }
            else if (_speed.X > 0)
            {
                areaToCheck.X = (int)Right; //- ((int)_camera.Pos.X - (int)_screenSize.X / 2);
                areaToCheck.Height = (int)Height ;
                areaToCheck.Width = 1;
                if (areaToCheck.Right + areaToCheck.Width >= _boundaries.X)
                {
                    canMoveHorizontally = false;
                    areaToCheck.X = (int)_screenSize.X - areaToCheck.Width-5;
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
                        else
                        {
                            break;
                        }
                    }
                }
            }
            if (_speed.Y < 0)
            {
                areaToCheck.X = (int)Left;//-((int)_camera.Pos.X - (int)_screenSize.X/2);
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
                        else
                        {
                            break;
                        }
                    }
                }
            }
            else if (_speed.Y > 0)
            {
                areaToCheck.X = (int)Left; //- ((int)_camera.Pos.X - (int)_screenSize.X / 2);
                areaToCheck.Y = (int)Bottom;// - ((int)_camera.Pos.Y - (int)_screenSize.Y / 2);
                areaToCheck.Width = (int)Width;
                areaToCheck.Height = 1;
                if (areaToCheck.Bottom >= _boundaries.Y)
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
                        else
                        {
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
            _boundaries = new Vector2(_keyMap.Width, _keyMap.Height);
            base.LoadContent(content, assetName, location, tint, batch);
            
        }
    }
}
