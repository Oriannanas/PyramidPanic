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
        // Fields, de velden van deze class 
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        // Maak een variabele aan van het type StartScene
        private StartScene startScene; // Camelcase notatie

        // Maak een variabele aan van het type PlayScene
        private PlayScene playScene; // Camelcase notatie

        // Maak een variabele aan van het type GameOverScene
        private GameOverScene gameOverScene; // Camelcase notatie


        // Maak een variabele aan van het type HelpScene
        private HelpScene helpScene; // Camelcase notatie

        // Maak een variabele aan van het type GameEndScene
        private GameEndScene gameEndScene; // Camelcase notatie

        //maak een variabele aan van het type LevelEditorScene
        private LevelEditorScene levelEditorScene;

        //maak een variabele aan van het type QuitScene
        private QuitScene quitScene;

        private ToetsScene toetsScene;
        /* De variabele die alle verschillende Scene-objecten kan bevatten is van het type 
         * IGameState. Dit is geen class, maar een nieuw objecttype Interface
         */
        private IGameState gameState;

        //Properties
        #region Properties
        public IGameState GameState
        {
            get { return this.gameState; }
            set { this.gameState = value; }
        }

        public StartScene StartScene
        {
            get { return this.startScene; }
        }

        public PlayScene PlayScene
        {
            get { return this.playScene; }
        }

        public GameOverScene GameOverScene
        {
            get { return this.gameOverScene; }
        }

        public HelpScene HelpScene
        {
            get { return this.helpScene; }
        }

        public GameEndScene GameEndScene
        {
            get { return this.gameEndScene; }
        }
        public LevelEditorScene LevelEditorScene
        {
            get { return this.levelEditorScene; }
        }
        public SpriteBatch SpriteBatch
        {
            get { return this.spriteBatch; }
        }
        public QuitScene QuitScene
        {
            get { return this.quitScene; }
        }
        public ToetsScene ToetsScene
        {
            get { return this.toetsScene; }
        }
        #endregion


        public PyramidPanic()
        {
            this.graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }


        protected override void Initialize()
        {
            // Maakt de muiscursor zichtbaar in het canvas
            IsMouseVisible = true;

            // Veranderd de titel van het canvas
            this.Window.Title = "Pyramid Panic";

            // Veranderd de breedte van het canvas
            this.graphics.PreferredBackBufferWidth = 640;

            //Veranderd de hoogte van het canvas
            this.graphics.PreferredBackBufferHeight = 480;

            // Past de graphische veranderingen aan
            this.graphics.ApplyChanges();
            base.Initialize();
        }


        protected override void LoadContent()
        {
            this.spriteBatch = new SpriteBatch(GraphicsDevice);

            //we maken een instantie aan van de class StartScene
            this.startScene = new StartScene(this);

            //we maken een instantie aan van de class StartScene
            this.playScene = new PlayScene(this);

            //we maken een instantie aan van de class GameOverScene
            this.gameOverScene = new GameOverScene(this);

            //we maken een instantie aan van de class HelpScene
            this.helpScene = new HelpScene(this);

            //we maken een instantie aan van de class GameEndScene
            this.gameEndScene = new GameEndScene(this);

            //we maken een instantie aan van de class LevelEditorScene
            this.levelEditorScene = new LevelEditorScene(this);

            //we maken een instantie aan van de class QuitScene
            this.quitScene = new QuitScene(this);

            //we maken een instantie aan van de class ToetsScene
            this.toetsScene = new ToetsScene(this);

            this.gameState = this.startScene;
        }


        protected override void UnloadContent()
        {

        }


        protected override void Update(GameTime gameTime)
        {
            // Wanneer de gamepad Back toets of de toetsenbord Escape toets wordt ingedrukt dan
            // Stopt het spel 
            if ((GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed) ||
                 (Keyboard.GetState().IsKeyDown(Keys.Escape)))
                this.Exit();

            // Roep de Update method aan van de Input class
            Input.Update();

            // Roep de Update(gameTime) method aan van het startScene-object
            this.gameState.Update(gameTime);



            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Purple);

            // Roep de Begin() method aan van het spriteBatch-object
            this.spriteBatch.Begin();

            // Roep de Draw(gameTime) method aan van het startScene-object
            this.gameState.Draw(gameTime);

            // Roep de End() method aan van het spriteBatch-object
            this.spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}