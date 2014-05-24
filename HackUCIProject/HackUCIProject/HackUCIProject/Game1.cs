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

        StartScreen startScreen;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            input = new InputManagerComponent();
            startScreen = new StartScreen(spriteBatch, new Vector2(10, 10), GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height, Content.Load<SpriteFont>("StartScreenSpriteFont"));

<<<<<<< HEAD
=======
            _screens.Add(ScreenState.game, new GameScreen(spriteBatch, Vector2.Zero, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height));


            foreach (Screen screen in _screens.Values)
            {
                screen.LoadContent(Content);
            }

            Global.CurrentScreen = ScreenState.game; //TODO: CHANGE TO START MENU
>>>>>>> c2479981046a652219bdec7f6afd8cb4b60d093c
        }
        protected override void UnloadContent()
        {
            
        }

        protected override void Update(GameTime gameTime)
        {
            input.Update();

<<<<<<< HEAD
=======
            //update screen when screens are created.
            _screens[Global.CurrentScreen].Update(gameTime);

>>>>>>> c2479981046a652219bdec7f6afd8cb4b60d093c
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
<<<<<<< HEAD
=======

            foreach (Screen screen in _screens.Values)
            {
                screen.Render();
            }

            //Draw screen when screens are created
            _screens[Global.CurrentScreen].Draw();

>>>>>>> c2479981046a652219bdec7f6afd8cb4b60d093c
            
            base.Draw(gameTime);
        }
    }
}
