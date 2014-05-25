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
            

            _senders.Add(new BaseSender(TriggerType.hotPlates));
            _senders[_senders.Count - 1].LoadContent(content, "Square", new Vector2(14, 824), Color.White, batch);
            Bridge reciever = new Bridge(BridgeSide.Left);
            reciever.LoadContent(content, "LevelMap\\BridgeRetracted", new Vector2(1116, 113), Color.Red, batch, "LevelMap\\BridgeRetracted", "LevelMap\\BridgeExtended");
            _senders[_senders.Count - 1].ObjectBeingTriggered = reciever;
            _sprites.Add(reciever);

            BaseSender blueSpot1 = new BaseSender(TriggerType.hotPlates);
            blueSpot1.LoadContent(content, "LevelMap\\HotSpot", new Vector2(197, 1), Color.Blue, batch);
            blueSpot1.ObjectBeingTriggered = reciever; // change this to blueDoor1
            _sprites.Add(blueSpot1);


            _senders.Add(new BaseSender(TriggerType.hotPlates));
            _senders[_senders.Count - 1].LoadContent(content, "Square", new Vector2(960,14), Color.White, batch);
            Bridge reciever2 = new Bridge(BridgeSide.Right);
            reciever2.LoadContent(content, "LevelMap\\BridgeRetracted", new Vector2(1520, 113), Color.Yellow, batch, "LevelMap\\BridgeRetracted", "LevelMap\\BridgeExtended");
            _senders[_senders.Count - 1].ObjectBeingTriggered = reciever2;
            _sprites.Add(reciever2);

            Bridge reciever3 = new Bridge(BridgeSide.Right);
            _senders.Add(new BaseSender(TriggerType.hotPlates));
            _senders[_senders.Count - 1].LoadContent(content, "Square", new Vector2(1905, 821), Color.White, batch);
            reciever3.LoadContent(content, "LevelMap\\BridgeRetracted", new Vector2(713, 881), Color.Green, batch, "LevelMap\\BridgeRetracted", "LevelMap\\BridgeExtended");
            _senders[_senders.Count - 1].ObjectBeingTriggered = reciever3;
            _sprites.Add(reciever3);

            _senders.Add(new BaseSender(TriggerType.hotPlates));
            _senders[_senders.Count - 1].LoadContent(content, "Square", new Vector2(14, 540), Color.White, batch);
            Bridge reciever4 = new Bridge(BridgeSide.Left);
            reciever4.LoadContent(content, "LevelMap\\BridgeRetracted", new Vector2(310, 882), Color.Blue, batch, "LevelMap\\BridgeRetracted", "LevelMap\\BridgeExtended");
            _senders[_senders.Count - 1].ObjectBeingTriggered = reciever4;
            _sprites.Add(reciever4);
            
            //after adding and loading all senders to the list of senders
            foreach (BaseSender sender in _senders)
            {
                sender.Triggered += new EventHandler(sender_Triggered);
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
            _players[2].Tint = Color.Red;
            _players[3].Location = new Vector2(Width-_players[3].Width - 10, Height - _players[3].Height - 10);
            _players[3].Tint = Color.Yellow;

            _drawn = new RenderTarget2D(_spriteBatch.GraphicsDevice, Convert.ToInt32(Width), Convert.ToInt32(Height));


        }

        void sender_Triggered(object sender, EventArgs e)
        {
            MapChanged(this, null);
        }

        Texture2D _localKeyMap;
        Color[] _colorData;  

        public Texture2D CreateNewKeyMap()
        {
            Render();
            _localKeyMap = new Texture2D(_spriteBatch.GraphicsDevice, Drawn.Width, Drawn.Height);
            _colorData = new Color[Drawn.Width * Drawn.Height];
            Drawn.GetData<Color>(0, new Rectangle(0, 0, Drawn.Width, Drawn.Height), _colorData, 0, _colorData.Length);
            _localKeyMap.SetData<Color>(_colorData);
            return _localKeyMap;
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

            foreach (BaseSender sender in _senders)
            {
                if (sender.TriggerType == TriggerType.hotPlates)
                {
                    bool on = false;
                    foreach (Player player in _players)
                    {
                        if (player.HitBox.Intersects(sender.HitBox))
                        {
                            on = true;
                            break;
                        }
                    }

                    if (on && !sender.IsTriggered || !on && sender.IsTriggered)
                    {
                        sender.Trigger();
                    }
                }
                else if (sender.TriggerType == TriggerType.switches)
                {
                    for (int i = 0; i < _players.Length; i++)
                    {
                        if (_players[i].HitBox.Intersects(sender.HitBox))
                        {
                            PlayerIndex currentPlayer = (PlayerIndex)i;
                            if (InputManager.GetCurrentPlayerState(currentPlayer).Buttons.A == ButtonState.Pressed && InputManager.GetLastPlayerState(currentPlayer).Buttons.A != ButtonState.Pressed)
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
