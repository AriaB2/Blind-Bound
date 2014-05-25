using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;

namespace HackUCIProject
{
    public class Dungeon : BaseSprite
    {
        private List<IXNA> _sprites;

        public event EventHandler MapChanged;

        private RenderTarget2D _drawn;

        public void MapStart()
        {
            MapChanged(this, EventArgs.Empty);
        }

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

        private Ghost[] _players;

        public Ghost[] Players
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



            _players = new Ghost[4];
            _senders = new List<BaseSender>();
            _sprites = new List<IXNA>();

            //player load logic goes here;
            

            _senders.Add(new BaseSender(TriggerType.hotPlates));
            _senders[_senders.Count - 1].LoadContent(content, "Square", new Vector2(14, 824), Color.Red, batch);
            Bridge reciever = new Bridge(BridgeSide.Left);
            reciever.LoadContent(content, "LevelMap\\BridgeRetracted", new Vector2(1116, 113), Color.Red, batch, "LevelMap\\BridgeRetracted", "LevelMap\\BridgeExtended");
            
            _sprites.Add(reciever);

            _senders.Add(new BaseSender(TriggerType.hotPlates));
            _senders[_senders.Count - 1].ObjectsBeingTriggered.Add(reciever);
            _senders[_senders.Count - 1].LoadContent(content, "Square", new Vector2(1905, 821), Color.Yellow, batch);
            Bridge reciever2 = new Bridge(BridgeSide.Right);
            reciever2.LoadContent(content, "LevelMap\\BridgeRetracted", new Vector2(1518, 113), Color.Yellow, batch, "LevelMap\\BridgeRetracted", "LevelMap\\BridgeExtended");
            _senders[_senders.Count - 1].ObjectsBeingTriggered.Add(reciever2);
            _sprites.Add(reciever2);

            
            _senders.Add(new BaseSender(TriggerType.hotPlates));
            _senders[_senders.Count - 1].LoadContent(content, "Square", new Vector2(960, 14), Color.Green, batch);
            Bridge reciever3 = new Bridge(BridgeSide.Right);
            reciever3.LoadContent(content, "LevelMap\\BridgeRetracted", new Vector2(713, 883), Color.Green, batch, "LevelMap\\BridgeRetracted", "LevelMap\\BridgeExtended");
            _senders[_senders.Count - 1].ObjectsBeingTriggered.Add(reciever3);
            _sprites.Add(reciever3);

            _senders.Add(new BaseSender(TriggerType.hotPlates));
            _senders[_senders.Count - 1].LoadContent(content, "Square", new Vector2(14, 540), Color.Blue, batch);
            Bridge reciever4 = new Bridge(BridgeSide.Left);
            reciever4.LoadContent(content, "LevelMap\\BridgeRetracted", new Vector2(310, 882), Color.Blue, batch, "LevelMap\\BridgeRetracted", "LevelMap\\BridgeExtended");
            reciever4.SoundEffect = content.Load<SoundEffect>("SoundEffects/Clunk");
            _senders[_senders.Count - 1].ObjectsBeingTriggered.Add(reciever4);

            _sprites.Add(reciever4);

            BaseSender blueSpot1 = new BaseSender(TriggerType.hotPlates);
            blueSpot1.LoadContent(content, "LevelMap\\HotSpot", new Vector2(197, 1), Color.Blue, batch);
            Door doorReciever = new Door();
            _sprites.Add(blueSpot1);
            _senders.Add(blueSpot1);
            doorReciever.LoadContent(content, "LevelMap\\Door-07", new Vector2(203, 945), Color.Blue, batch);
            _senders[_senders.Count - 1].ObjectsBeingTriggered.Add(doorReciever);
            doorReciever.SoundEffect = content.Load<SoundEffect>("SoundEffects/Door Open");
            doorReciever.Rotation = (float)(Math.PI / 2);
            doorReciever.Scale *= .75f;
            _sprites.Add(doorReciever);

            BaseSender blueSpot2 = new BaseSender(TriggerType.hotPlates);
            blueSpot2.LoadContent(content, "LevelMap\\HotSpot", new Vector2(604, 517), Color.Blue, batch);
            _sprites.Add(blueSpot2);
            _senders.Add(blueSpot2);
            List<Door> blueDoors = new List<Door>(2);
            for (int i = 0; i < 2; i++)
            {
                blueDoors.Add(new Door());
            }
            blueDoors[0].LoadContent(content, "LevelMap\\Door-07", new Vector2(1685, 498), Color.Blue, batch);
            blueDoors[1].LoadContent(content, "LevelMap\\Door-07", new Vector2(1115, 501), Color.Blue, batch);
            foreach (Door door in blueDoors)
            {
                blueSpot2.ObjectsBeingTriggered.Add(door);
            }
            blueDoors[0].Rotation = (float)(Math.PI / 2);
            blueDoors[0].Scale *= .75f;
            blueDoors[1].Scale *= .75f;
            _sprites.Add(blueDoors[0]);
            _sprites.Add(blueDoors[1]);

            BaseSender greenSpot1 = new BaseSender(TriggerType.hotPlates);
            greenSpot1.LoadContent(content, "LevelMap\\HotSpot", new Vector2(1799, 264), Color.Green, batch);
            Door doorReciever2 = new Door();
            _sprites.Add(greenSpot1);
            _senders.Add(greenSpot1);
            doorReciever2.LoadContent(content, "LevelMap\\Door-07", new Vector2(68 , 192), Color.Green, batch);
            _senders[_senders.Count - 1].ObjectsBeingTriggered.Add(doorReciever2);
            doorReciever2.Scale *= .75f;
            _sprites.Add(doorReciever2);

            BaseSender greenSpot2 = new BaseSender(TriggerType.hotPlates);
            greenSpot2.LoadContent(content, "LevelMap\\HotSpot", new Vector2(1075, 506), Color.Green, batch);
            Door doorReciever4 = new Door();
            _sprites.Add(greenSpot2);
            _senders.Add(greenSpot2);
            doorReciever4.LoadContent(content, "LevelMap\\Door-07", new Vector2(930, 765), Color.Green, batch);
            _senders[_senders.Count - 1].ObjectsBeingTriggered.Add(doorReciever4);
            doorReciever4.Scale *= .75f;
            _sprites.Add(doorReciever4);

            BaseSender yellowSpot1 = new BaseSender(TriggerType.hotPlates);
            yellowSpot1.LoadContent(content, "LevelMap\\HotSpot", new Vector2(1377, 901), Color.Yellow, batch);
            TrapDoor trapDoorReciever = new TrapDoor();
            _sprites.Add(yellowSpot1);
            _senders.Add(yellowSpot1);
            trapDoorReciever.LoadContent(content, "LevelMap\\TrapdoorOpen", new Vector2(150, 345), Color.Yellow, batch);
            _senders[_senders.Count - 1].ObjectsBeingTriggered.Add(trapDoorReciever);
            trapDoorReciever.Scale *= .20f;
            _sprites.Add(trapDoorReciever);

            BaseSender yellowSpot2 = new BaseSender(TriggerType.hotPlates);
            yellowSpot2.LoadContent(content, "LevelMap\\HotSpot", new Vector2(1871, 506), Color.Yellow, batch);
            TrapDoor trapDoorReciever3 = new TrapDoor();
            _sprites.Add(yellowSpot2);
            _senders.Add(yellowSpot2);
            trapDoorReciever3.LoadContent(content, "LevelMap\\TrapdoorOpen", new Vector2(388, 515), Color.Yellow, batch);
            _senders[_senders.Count - 1].ObjectsBeingTriggered.Add(trapDoorReciever3);
            trapDoorReciever3.Scale *= .22f;
            _sprites.Add(trapDoorReciever3);

            BaseSender redSpot1 = new BaseSender(TriggerType.hotPlates);
            redSpot1.LoadContent(content, "LevelMap\\HotSpot", new Vector2(939, 901), Color.Red, batch);
            TrapDoor trapDoorReciever2 = new TrapDoor();
            _sprites.Add(redSpot1);
            _senders.Add(redSpot1);
            trapDoorReciever2.LoadContent(content, "LevelMap\\TrapdoorOpen", new Vector2(1722, 723), Color.Red, batch);
            _senders[_senders.Count - 1].ObjectsBeingTriggered.Add(trapDoorReciever2);
            trapDoorReciever2.Scale *= .20f;
            _sprites.Add(trapDoorReciever2);

            BaseSender redSpot2 = new BaseSender(TriggerType.hotPlates);
            redSpot2.LoadContent(content, "LevelMap\\HotSpot", new Vector2(937, 656), Color.Red, batch);
            Door doorReciever3 = new Door();
            _sprites.Add(redSpot2);
            _senders.Add(redSpot2);
            doorReciever3.LoadContent(content, "LevelMap\\Door-07", new Vector2(1218, 498), Color.Red, batch);
            _senders[_senders.Count - 1].ObjectsBeingTriggered.Add(doorReciever3);
            doorReciever3.Scale *= .75f;
            doorReciever3.Rotation = (float)(Math.PI / 2);
            _sprites.Add(doorReciever3);
            //after adding and loading all senders to the list of senders

            foreach (BaseSender sender in _senders)
            {
                sender.Triggered += new EventHandler(sender_Triggered);
                _sprites.Add(sender);
            }
            base.LoadContent(content, assetName, location, tint, batch);

            for (int i = 0; i < _players.Length; i++)
            {
                _players[i] = new Ghost((PlayerIndex)i);
                _players[i].LoadContent(content, "Ghost", new Vector2(300, 140), Global.MainColors[i], batch, "LevelMap/SacredDonutLevelWhite-05");
                _players[i].Speed = Vector2.One;
                _players[i].SetOriginCenter();
                _players[i].Scale = new Vector2(.1f, .1f);
                _sprites.Add(_players[i]);
            }

            _players[0].Location = new Vector2(100, 100);
            _players[0].Tint = Color.White;
            _players[1].Location = new Vector2(Width - _players[1].Width - 10, 50);
            _players[1].Tint = Color.Purple;

            _players[2].Location = new Vector2(50, Height - _players[2].Height);
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
