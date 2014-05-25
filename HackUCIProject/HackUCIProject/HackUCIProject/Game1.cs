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
        SpriteFont font;
        TimeSpan fpsCounter = new TimeSpan();

        InputManagerComponent input;

        Dictionary<ScreenState, Screen> _screens;
        StartScreen startScreen;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }
        List<SpriteFont> spriteFontList = new List<SpriteFont>();
        protected override void Initialize()
        {
            _screens = new Dictionary<ScreenState, Screen>();
            graphics.ToggleFullScreen();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            input = new InputManagerComponent();

            

            
            for (int i = 0; i < 7; i++)
            {
                spriteFontList.Add(Content.Load<SpriteFont>("Fonts/StartScreenSpriteFont" + i.ToString()));
            }

            startScreen = new StartScreen(spriteBatch, new Vector2(0, 0), GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height, spriteFontList);



            Global.CurrentScreen = ScreenState.none; //TODO: CHANGE TO START MENU
            

             
            _screens.Add(ScreenState.game, new GameScreen(spriteBatch, Vector2.Zero, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height));
            _screens.Add(ScreenState.levelSelection, new LevelSelection(spriteBatch, Vector2.Zero, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height));
            _screens.Add(ScreenState.startMenu, startScreen);

            foreach (Screen screen in _screens.Values)
            {
                screen.LoadContent(Content);
            }

            Global.CurrentScreen = ScreenState.game; //TODO: CHANGE TO START MENU
            //Global.CurrentScreen = ScreenState.game; //TODO: CHANGE TO START MENU
            //Global.CurrentScreen = ScreenState.startMenu;
    
        }
        protected override void UnloadContent()
        {
            
        }
        int fps;
        protected override void Update(GameTime gameTime)
        {
            input.Update();
            if (Global.CurrentScreen == ScreenState.startMenu && startScreen.EndGame)
            {
                Exit();
            }
            fpsCounter += gameTime.ElapsedGameTime;
            if (fpsCounter >= TimeSpan.FromSeconds(1))
            {
                fps = framesDrawn;
                fpsCounter = TimeSpan.Zero;
                framesDrawn = 0;
            }
            //update screen when screens are created.
            _screens[Global.CurrentScreen].Update(gameTime);

            base.Update(gameTime);
        }
        int framesDrawn;
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            
            //Draw screen when screens are created`890.
            _screens[Global.CurrentScreen].Render();
            _screens[Global.CurrentScreen].Draw();

            
            spriteBatch.Begin();
            spriteBatch.DrawString(spriteFontList[0], string.Format("{0}", fps), Vector2.Zero, Color.White);
            spriteBatch.End();

            framesDrawn++;
            base.Draw(gameTime);
        }
    }
}
