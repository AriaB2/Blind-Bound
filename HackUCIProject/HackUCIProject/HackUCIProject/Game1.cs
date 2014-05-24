using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace HackUCIProject
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;


        InputManagerComponent input;

        Dictionary<ScreenState, Screen> _screens;


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            _screens = new Dictionary<ScreenState, Screen>();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            input = new InputManagerComponent();


            Global.CurrentScreen = ScreenState.none; //TODO: CHANGE TO START MENU
        }

        protected override void UnloadContent()
        {
            
        }

        protected override void Update(GameTime gameTime)
        {
            input.Update();

            //update screen when screens are created.
            //_screens[Global.CurrentScreen].Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            foreach (Screen screen in _screens.Values)
            {
                screen.Render();
            }

            //Draw screen when screens are created
            //_screens[Global.CurrentScreen].Draw();

            
            base.Draw(gameTime);
        }
    }
}
