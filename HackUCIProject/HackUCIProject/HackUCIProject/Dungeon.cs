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

        public event EventHandler MapChanged;

        private RenderTarget2D _drawn;

        public RenderTarget2D Drawn
        {
            get
            {
                return _drawn;
            }
        }

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
            

            _senders.Add(new BaseSender());
            _senders[_senders.Count - 1].LoadContent(content, "Square", new Vector2(100, 100), Color.White, batch);

            


            Bridge reciever = new Bridge(BridgeSide.Left);
            reciever.LoadContent(content, "LevelMap\\BridgeRetracted", new Vector2(1116, 113), Color.Red, batch, "LevelMap\\BridgeRetracted", "LevelMap\\BridgeExtended");
            _senders[_senders.Count - 1].ObjectBeingTriggered = reciever;
            _sprites.Add(reciever);
            _senders.Add(new BaseSender());
            _senders[_senders.Count - 1].LoadContent(content, "Square", new Vector2(1000, 100), Color.White, batch);
            Bridge reciever2 = new Bridge(BridgeSide.Right);
            reciever2.LoadContent(content, "LevelMap\\BridgeRetracted", new Vector2(1520, 113), Color.Red, batch, "LevelMap\\BridgeRetracted", "LevelMap\\BridgeExtended");
            _senders[_senders.Count - 1].ObjectBeingTriggered = reciever2;
            _sprites.Add(reciever2);
            //after adding and loading all senders to the list of senders
            foreach (BaseSender sender in _senders)
            {
                _sprites.Add(sender);
            }
            base.LoadContent(content, assetName, location, tint, batch);

            for (int i = 0; i < _players.Length; i++)
            {
                _players[i] = new Player((PlayerIndex)i);
                _players[i].LoadContent(content, "Square", new Vector2(300, 140), Global.MainColors[i], batch, "LevelMap/SacredDonutLevelWhite-05");
                _players[i].Speed = Vector2.One;
                _players[i].SetOriginCenter();
                _sprites.Add(_players[i]);
            }

            _players[0].Location = new Vector2(100, 100);
            _players[0].Tint = Color.White;
            _players[1].Location = new Vector2(Width - _players[1].Width - 10, 10);
            _players[1].Tint = Color.Purple;
            _players[2].Location = new Vector2(10, Height - _players[2].Height);
            _players[3].Location = new Vector2(Width - _players[3].Width - 10, Height - _players[3].Height - 10);
            _drawn = new RenderTarget2D(_spriteBatch.GraphicsDevice, Convert.ToInt32(Width), Convert.ToInt32(Height));


        }

       


        public override void Update(GameTime gameTime)
        {
            foreach (IXNA sprite in _sprites)
            {
                sprite.Update(gameTime);
            }

            foreach (Player player in _players)
            {
                player.Update(gameTime);
            }

            for (int i = 0; i < _players.Length; i++)
            {
                foreach (BaseSender sender in _senders)
                {
                    if (_players[i].HitBox.Intersects(sender.HitBox))
                    {
                        PlayerIndex currentPlayer = (PlayerIndex)i;
                        if (InputManager.GetCurrentPlayerState(currentPlayer).Buttons.A == ButtonState.Pressed && InputManager.GetLastPlayerState(currentPlayer).Buttons.A != ButtonState.Pressed)
                        {
                            if (_players[i].Tint == sender.Tint)
                            {
                                sender.Trigger();
                                MapChanged(this, null);
                            }
                        }
                        break;
                    }
                }
            }


            base.Update(gameTime);
        }

        public void Render()
        {
            _spriteBatch.GraphicsDevice.SetRenderTarget(_drawn);
            _spriteBatch.Begin();


            base.Draw();


            foreach (IXNA sprite in _sprites)
            {
                sprite.Draw();
            }
            _spriteBatch.End();

            _spriteBatch.GraphicsDevice.SetRenderTarget(null);
        }

        public override void Draw()
        {

            base.Draw();
            foreach (IXNA sprite in _sprites)
            {
                sprite.Draw();
            }

        }
    }
}
