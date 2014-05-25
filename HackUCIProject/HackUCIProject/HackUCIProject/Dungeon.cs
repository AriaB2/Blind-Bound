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
            _gameState = GameState.playing;
            MapChanged(this, EventArgs.Empty);
        }

        private GameState _gameState;

        public GameState GameState
        {
            get
            {
                return _gameState;
            }
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

        private BaseSprite _goal;

        public override void LoadContent(ContentManager content, string assetName, Vector2 location, Color tint, SpriteBatch batch)
        {
            //temporary hardcoded level to have some sort of product. In the future will implement an xml format or something



            _players = new Ghost[4];
            _senders = new List<BaseSender>();
            _sprites = new List<IXNA>();

            //player load logic goes here;


            BaseSender blueSwitch2 = new BaseSender(TriggerType.switches);
            blueSwitch2.LoadContent(content, "LevelMap\\Lever", new Vector2(1, 540), Color.Blue, batch);
            blueSwitch2.Scale *= .35f;
            _senders.Add(blueSwitch2);

            Bridge blueBridge2 = new Bridge(BridgeSide.Left);
            blueBridge2.LoadContent(content, "LevelMap\\BridgeRetracted", new Vector2(310, 883), Color.Blue, batch, "LevelMap\\BridgeRetracted", "LevelMap\\BridgeExtended");
            blueBridge2.SoundEffect = content.Load<SoundEffect>("SoundEffects/Clunk");

            blueSwitch2.ObjectsBeingTriggered.Add(blueBridge2);
            _sprites.Add(blueBridge2);


            BaseSender blueSpot1 = new BaseSender(TriggerType.hotPlates);
            blueSpot1.LoadContent(content, "LevelMap\\HotSpot", new Vector2(197, 1), Color.Blue, batch);
            _senders.Add(blueSpot1);

            Door blueDoor1 = new Door();
            blueDoor1.LoadContent(content, "LevelMap\\Door-07", new Vector2(203, 945), Color.Blue, batch);
            blueDoor1.SoundEffect = content.Load<SoundEffect>("SoundEffects/Door Open");
            blueDoor1.Rotation = (float)(Math.PI / 2);
            blueDoor1.Scale *= .75f;

            blueSpot1.ObjectsBeingTriggered.Add(blueDoor1);
            _sprites.Add(blueDoor1);

            BaseSender yellowSpot2 = new BaseSender(TriggerType.hotPlates);
            yellowSpot2.LoadContent(content, "LevelMap\\HotSpot", new Vector2(1377, 901), Color.Yellow, batch);
            _senders.Add(yellowSpot2);

            TrapDoor yellowTrapDoor2 = new TrapDoor();
            yellowTrapDoor2.LoadContent(content, "LevelMap\\TrapdoorOpen", new Vector2(150, 345), Color.Yellow, batch);
            yellowTrapDoor2.Scale *= .20f;
            _sprites.Add(yellowTrapDoor2);


            yellowSpot2.ObjectsBeingTriggered.Add(yellowTrapDoor2);


            BaseSender redSwitch1 = new BaseSender(TriggerType.switches);
            redSwitch1.LoadContent(content, "LevelMap\\Lever", new Vector2(0, 806), Color.Red, batch);
            _senders.Add(redSwitch1);
            redSwitch1.Scale *= .35f;

            Bridge redBridge1 = new Bridge(BridgeSide.Left);
            redBridge1.LoadContent(content, "LevelMap\\BridgeRetracted", new Vector2(1116, 113), Color.Red, batch, "LevelMap\\BridgeRetracted", "LevelMap\\BridgeExtended");
            _sprites.Add(redBridge1);
            
            redSwitch1.ObjectsBeingTriggered.Add(redBridge1);


            BaseSender yellowSwitch1 = new BaseSender(TriggerType.switches);
            yellowSwitch1.LoadContent(content, "LevelMap\\Lever", new Vector2(1897, 820), Color.Yellow, batch);
            yellowSwitch1.Scale *= .35f;
            yellowSwitch1.SetOriginCenter();
            yellowSwitch1.Rotation = (float)Math.PI;
            yellowSwitch1.UpdateHitBox();
            _senders.Add(yellowSwitch1);

            Bridge yellowBridge1 = new Bridge(BridgeSide.Right);
            yellowBridge1.LoadContent(content, "LevelMap\\BridgeRetracted", new Vector2(1518, 113), Color.Yellow, batch, "LevelMap\\BridgeRetracted", "LevelMap\\BridgeExtended");
            yellowSwitch1.ObjectsBeingTriggered.Add(yellowBridge1);
            _sprites.Add(yellowBridge1);

            BaseSender yellowSpot3 = new BaseSender(TriggerType.hotPlates);
            yellowSpot3.LoadContent(content, "LevelMap\\HotSpot", new Vector2(1872, 507), Color.Yellow, batch); //Change the location
            _senders.Add(yellowSpot3);

            TrapDoor yellowTrapDoor3 = new TrapDoor();
            yellowTrapDoor3.LoadContent(content, "LevelMap\\TrapdoorOpen", new Vector2(388, 515), Color.Yellow, batch);
            yellowTrapDoor3.Scale *= .22f;
            _sprites.Add(yellowTrapDoor3);

            yellowSpot3.ObjectsBeingTriggered.Add(yellowTrapDoor3);

            BaseSender greenSpot1 = new BaseSender(TriggerType.hotPlates);
            greenSpot1.LoadContent(content, "LevelMap\\HotSpot", new Vector2(1799, 264), Color.Green, batch);
            _senders.Add(greenSpot1);

            Door greenDoor1 = new Door();
            greenDoor1.LoadContent(content, "LevelMap\\Door-07", new Vector2(68, 192), Color.Green, batch);
            greenDoor1.Scale *= .75f;
            _sprites.Add(greenDoor1);

            greenSpot1.ObjectsBeingTriggered.Add(greenDoor1);

            BaseSender greenSpot3 = new BaseSender(TriggerType.hotPlates);
            greenSpot3.LoadContent(content, "LevelMap\\HotSpot", new Vector2(1075, 506), Color.Green, batch);
            _senders.Add(greenSpot3);

            Door greenDoor3 = new Door();
            greenDoor3.LoadContent(content, "LevelMap\\Door-07", new Vector2(930, 765), Color.Green, batch);
            greenDoor3.Scale *= .75f;
            _sprites.Add(greenDoor3);

            greenSpot3.ObjectsBeingTriggered.Add(greenDoor3);

            BaseSender redSpot2 = new BaseSender(TriggerType.hotPlates);
            redSpot2.LoadContent(content, "LevelMap\\HotSpot", new Vector2(939, 901), Color.Red, batch);
            _senders.Add(redSpot2);

            TrapDoor redTrapDoor2 = new TrapDoor();
            redTrapDoor2.LoadContent(content, "LevelMap\\TrapdoorOpen", new Vector2(1722, 723), Color.Red, batch);
            redTrapDoor2.Scale *= .20f;
            _sprites.Add(redTrapDoor2);

            redSpot2.ObjectsBeingTriggered.Add(redTrapDoor2);


            //_senders.Add(new BaseSender(TriggerType.switches));
            _senders[_senders.Count - 1].LoadContent(content, "Square", new Vector2(960, 14), Color.Green, batch);
            Bridge reciever3 = new Bridge(BridgeSide.Right);
            reciever3.LoadContent(content, "LevelMap\\BridgeRetracted", new Vector2(713, 883), Color.Green, batch, "LevelMap\\BridgeRetracted", "LevelMap\\BridgeExtended");
            _senders[_senders.Count - 1].ObjectsBeingTriggered.Add(reciever3);
            //_sprites.Add(reciever3);





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










            BaseSender redSpot3 = new BaseSender(TriggerType.hotPlates);
            redSpot3.LoadContent(content, "LevelMap\\HotSpot", new Vector2(937, 656), Color.Red, batch);
            Door doorReciever3 = new Door();
            _senders.Add(redSpot3);
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
            _players[0].Tint = Color.Blue;
            _players[1].Location = new Vector2(Width - _players[1].Width - 10, 50);
            _players[1].Tint = Color.Purple;

            _players[2].Location = new Vector2(50, Height - _players[2].Height);
            _players[2].Tint = Color.Red;
            _players[3].Location = new Vector2(Width-_players[3].Width - 10, Height - _players[3].Height - 10);
            _players[3].Tint = Color.Yellow;

            _drawn = new RenderTarget2D(_spriteBatch.GraphicsDevice, Convert.ToInt32(Width), Convert.ToInt32(Height));

            _goal = new BaseSprite();
            _goal.LoadContent(content, "LevelMap/Goal", new Vector2(868, 585), Color.Pink, batch);
            //_sprites.Add(_goal);

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
            if (_gameState == GameState.playing)
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

                //checking for win
                bool win = true;
                foreach (Player player in _players)
                {
                    if (!player.HitBox.Intersects(_goal.HitBox))
                    {
                        win = false;
                        break;
                    }
                }

                if (win)
                {
                    _gameState = GameState.levelComplete;
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
