using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace HackUCIProject
{
    public class Dungeon : BaseSprite
    {
        private List<IXNA> _sprites;

        public List<IXNA> Sprites
        {
            get { return _sprites; }
            set { _sprites = value; }
        }

        private Player[] _players;

        public Player[] Players
        {
            get { return _players; }
            set { _players = value; }
        }

        private List<BaseSender> _senders;

        public List<BaseSender> Senders
        {
            get { return _senders; }
            set { _senders = value; }
        }



        public override void LoadContent(ContentManager content, string assetName, Vector2 location, Color tint, SpriteBatch batch)
        {
            //temporary hardcoded level to have some sort of product. In the future will implement an xml format or something


            _players = new Player[4];
            _senders = new List<BaseSender>();
            _sprites = new List<IXNA>();

            //player load logic goes here;
            for (int i = 0; i < _players.Length; i++)
            {
                _players[i] = new Player((PlayerIndex)i);
                _players[i].LoadContent(content, "Square", new Vector2(100, 100), Color.White, batch);
                _players[i].Speed = Vector2.One;
                _players[i].SetOriginCenter();
                _sprites.Add(_players[i]);
                
            }


            //after adding and loading all senders to the list of senders
            foreach (BaseSender sender in _senders)
            {
                _sprites.Add(sender);
            }
            base.LoadContent(content, assetName, location, tint, batch);


            _players[1].Location = new Vector2(Width - _players[1].Width, 0);
            _players[2].Location = new Vector2(0, Height - _players[2].Height);
            _players[3].Location = new Vector2(Width - _players[3].Width, Height - _players[3].Height);
        }


        public override void Update(GameTime gameTime)
        {
            foreach (IXNA sprite in _sprites)
            {
                sprite.Update(gameTime);
            }

            for (int i = 0; i < _players.Length; i++)
            {
                foreach (BaseSender sender in _senders)
                {
                    if (_players[i].HitBox.Intersects(sender.HitBox))
                    {
                        PlayerIndex currentPlayer = (PlayerIndex)i;
                        if (InputManager.GetCurrentPlayerState(currentPlayer).Buttons.A == ButtonState.Pressed && InputManager.GetLastPlayerState(currentPlayer).Buttons.A == ButtonState.Released)
                        {
                            if (_players[i].Tint == sender.Tint)
                            {
                                sender.Trigger();
                            }
                        }
                        break;
                    }
                }
            }

            
            base.Update(gameTime);
        }

        public override void Draw()
        {
            foreach (IXNA sprite in _sprites)
            {
                sprite.Draw();
            }
            base.Draw();
        }
    }
}
