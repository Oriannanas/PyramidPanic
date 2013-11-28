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

namespace PyramidPanic
{
    public class PyramidPanic : Microsoft.Xna.Framework.Game
    {
        //fields
        private GraphicsDeviceManager graphics;
        private KeyboardState ks, oks;
        private MouseState ms, oms;
        private SpriteBatch spriteBatch;
        private Texture2D textureMenneke;
        private Menneke menneke;
        private enum Gamestate
        {
            Menu,
            Game
        }
        Gamestate CurrentGameState = Gamestate.Menu;

        public PyramidPanic()
        {
            this.graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            //past de breedte van het scherm aan
            this.graphics.PreferredBackBufferWidth = 640;
            //past de hoogte van het scherm aan
            this.graphics.PreferredBackBufferHeight = 480;
            //past de graphics veranderingen toe
            this.graphics.ApplyChanges();
            this.IsMouseVisible = true;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            this.spriteBatch = new SpriteBatch(GraphicsDevice);
            textureMenneke = Content.Load<Texture2D>("./MENNEKE/explorer");
            menneke = new Menneke(textureMenneke, 100, 100, Keys.S, Keys.W, Keys.A, Keys.D);
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            this.ms = Mouse.GetState();
            this.ks = Keyboard.GetState();
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
            switch (CurrentGameState)
            {
                // als de gamestate op Menu staat
                case Gamestate.Menu:
                    //wanneer de spatiebalk word ingedruk en hij eerst niet werd ingedrukt, veranderd de gamestate naar Game
                    if (this.ks.IsKeyDown(Keys.Space) && this.oks.IsKeyUp(Keys.Space))
                    {
                        //de gamestate word game
                        CurrentGameState = Gamestate.Game;

                    }
                    break;
                // als de gamestate op Game staat
                case Gamestate.Game:
                    //wanneer de spatiebalk word ingedruk en hij eerst niet werd ingedrukt, veranderd de gamestate naar Menu
                    if (this.ks.IsKeyDown(Keys.Space) && this.oks.IsKeyUp(Keys.Space))
                    {
                        //de gamestate word menu
                        CurrentGameState = Gamestate.Menu;

                    }
                    break;

            }

            oks = ks;
            oms = ms;
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            switch (CurrentGameState)
            {

                case Gamestate.Menu:
                    spriteBatch.Draw(Content.Load<Texture2D>("./Background/background"), new Rectangle(0, 0, 640, 480), Color.White);
                    break;
                case Gamestate.Game:
                    spriteBatch.Draw(Content.Load<Texture2D>("./Background/background2"), new Rectangle(0, 0, 640, 480), Color.White);
                    menneke.Draw(spriteBatch);
                    break;
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
