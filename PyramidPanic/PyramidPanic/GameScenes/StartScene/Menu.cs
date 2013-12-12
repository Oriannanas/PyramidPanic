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
    public class Menu
    {
        #region Fields
        private PyramidPanic game;
        private Image startButton, helpButton, levelEditorButton, loadButton, quitButton/*, scoresButton*/;
        private List<Image> buttons = new List<Image>;
        private int left = 10, space = 130, top = 440;
        #endregion

        #region Properties

        #endregion


        #region Constructor
        public Menu(PyramidPanic game)
        {
            this.game = game;
            this.Initialize();
            
        }
        #endregion

        #region Initialize
        public void Initialize()
        {
            this.LoadContent();
        }
        #endregion

        #region LoadContent
        public void LoadContent()
        {
            this.startButton = new Image(this.game, @"Menu\Button_start", new Vector2(this.left, this.top));
            this.helpButton = new Image(this.game, @"Menu\Button_help", new Vector2(this.left + this.space,this.top));
            this.levelEditorButton = new Image(this.game, @"Menu\Button_leveleditor", new Vector2(this.left + 2*this.space, this.top));
            this.loadButton = new Image(this.game, @"Menu\Button_load", new Vector2(this.left + 3*this.space, this.top));
            this.quitButton = new Image(this.game, @"Menu\Button_quit", new Vector2(this.left + 4*this.space, this.top));
            //this.scoresButton = new Image(this.game, @"Menu\Button_scores", new Vector2(this.left + 5*this.space, this.top));
        }
        #endregion

        #region Update

        #endregion


        #region Draw
        public void Draw(GameTime gameTime)
        {
            this.startButton.Draw(gameTime);
            this.helpButton.Draw(gameTime);
            this.levelEditorButton.Draw(gameTime);
            this.loadButton.Draw(gameTime);
            this.quitButton.Draw(gameTime);
            //this.scoresButton.Draw(gameTime);
        }
        #endregion
    }
}