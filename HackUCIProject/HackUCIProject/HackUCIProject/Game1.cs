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


        Dungeon d1 = new Dungeon();


        InputManagerComponent input;

        Dictionary<ScreenState, Screen> _screens;
        StartScreen startScreen;

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
            startScreen = new StartScreen(spriteBatch, new Vector2(10, 10), GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height, Content.Load<SpriteFont>("StartScreenSpriteFont"));

            d1.LoadContent(Content, "Square", Vector2.Zero, Color.White, spriteBatch);
            Global.CurrentScreen = ScreenState.none; //TODO: CHANGE TO START MENU

            _screens.Add(ScreenState.game, new GameScreen(spriteBatch, Vector2.Zero, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height));
            _screens.Add(ScreenState.levelSelection, new LevelSelection(spriteBatch, Vector2.Zero, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height));
            _screens.Add(ScreenState.startMenu, startScreen);


            _screens.Add(ScreenState.game, new GameScreen(spriteBatch, Vector2.Zero, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height));
            _screens.Add(ScreenState.startMenu, startScreen);

            foreach (Screen screen in _screens.Values)
            {
                screen.LoadContent(Content);
            }


            Global.CurrentScreen = ScreenState.startMenu; //TODO: CHANGE TO START MENU



            Global.CurrentScreen = ScreenState.startMenu; //TODO: CHANGE TO START MENU

        }
        protected override void UnloadContent()
        {
            
        }

        protected override void Update(GameTime gameTime)
        {
            input.Update();



            //update screen when screens are created.
            _screens[Global.CurrentScreen].Update(gameTime);


            d1.Update(gameTime);

            //update screen when screens are created.
            _screens[Global.CurrentScreen].Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);



            foreach (Screen screen in _screens.Values)
            {
                screen.Render();
            }
            spriteBatch.Begin();
            d1.Draw();
            spriteBatch.End();
            //Draw screen when screens are created
            _screens[Global.CurrentScreen].Draw();

            
            base.Draw(gameTime);
        }
    }
}
