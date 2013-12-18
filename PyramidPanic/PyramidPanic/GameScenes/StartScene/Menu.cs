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
        // We definieren een nieuw soort variabele, Button. Het is een enum.
        private enum Button { Start, Load, Editor, Help, Scores, Quit };
        //                      0      1    2        3       4     5
        /* We maken nu een variabele aan van het type Button. Deze variabele kan maar 5 waarden
         * aannemen. Namelijk Start, Load, Help, Scores, Quit. We kunnen natuurlijk altijd
         * waarden toevoegen.
         */
        private Button buttonState = Button.Start;

        // Definieer een kleur van de actieve knop
        private Color activeColor = Color.Gold;

        // game bevat de PyramidPanic instantie doorgegeven als argument aan de constructor
        private PyramidPanic game;
        private Image start, load, help, scores, quit, editor;

        // Maak een List<Image> waar we Image objecten in kunnen stoppen, in dit geval de buttons
        private List<Image> buttonList;
        private int top = 430, left = 10, space = 105;
        #endregion

        #region Properties

        #endregion


        #region Constructor
        //dit is de constructor van onze menu class
        public Menu(PyramidPanic game)
        {
            //met deze regel zorgen we dat de classe variabele "game" 
            //gelijk is aan de variabele game die meegegeven is daan de constructor
            this.game = game;
            //hier word de initalize method opgeroepen
            this.Initialize();
        }
        #endregion

        #region Initialize
        //dit is de initalizer
        public void Initialize()
        {
            //hier word de loadcontent method opgeroepen
            this.LoadContent();
        }
        #endregion

        #region LoadContent
        //dit is de load content method
        public void LoadContent()
        {
            // hiermee wordt een nieuw list object gemaakt
            this.buttonList = new List<Image>();
            //we definieren de eerder gemaakte images door hun constructor aan te roepen met new 
            //en deze constructor de gevraagde waarden mee te geven
            //en we stoppen deze gelijk in onze buttonlist
            this.buttonList.Add(this.start = new Image(this.game, @"Menu\Button_start", new Vector2(this.left, this.top)));
            this.buttonList.Add(this.load = new Image(this.game, @"Menu\Button_load", new Vector2(this.left + this.space, this.top)));
            this.buttonList.Add(this.editor = new Image(this.game, @"Menu\Button_leveleditor", new Vector2(this.left + 2 * this.space, this.top)));
            this.buttonList.Add(this.help = new Image(this.game, @"Menu\Button_help", new Vector2(this.left + 3 * this.space, this.top)));
            this.buttonList.Add(this.scores = new Image(this.game, @"Menu\Button_scores", new Vector2(this.left + 4 * this.space, this.top)));
            this.buttonList.Add(this.quit = new Image(this.game, @"Menu\Button_quit", new Vector2(this.left + 5 * this.space, this.top)));

        }
        #endregion

        #region Update
        public void Update(GameTime gameTime)
        {
            // Als de right knop wordt ingedrukt....
            if (Input.EdgeDetectKeyDown(Keys.Right))
            {
                // en de buttonState is kleiner dan Button.quit
                if (this.buttonState < Button.Quit)
                {
                    // Zet alle knopkleuren op wit
                    this.ResetButtonColor();
                    // Verhoog de buttonState met 1
                    this.buttonState++;
                }
                else
                {
                    this.ResetButtonColor();
                    this.buttonState = Button.Start;
                }
            }

            // Als de links knop wordt ingedrukt
            if (Input.EdgeDetectKeyDown(Keys.Left))
            {
                // Als de buttonState groter is dan Button.Start
                if (this.buttonState > Button.Start)
                {
                    // Maak alle knopkleuren wit
                    this.ResetButtonColor();
                    // Verlaag de buttonState met 1
                    this.buttonState--;
                }
                else
                {
                    this.ResetButtonColor();
                    this.buttonState = Button.Quit;
                }
            }
            if (this.start.Rectangle.Intersects(Input.MouseRect()))
            {
                if (Input.EdgeDetectMousePressLeft())
                {
                    this.game.GameState = this.game.PlayScene;
                }
                this.ResetButtonColor();
                this.buttonState = Button.Start;
                this.start.Color = this.activeColor;
            }
            if (this.load.Rectangle.Intersects(Input.MouseRect()))
            {
                if (Input.EdgeDetectMousePressLeft())
                {
                    this.game.GameState = this.game.PlayScene;
                }
                this.ResetButtonColor();
                this.buttonState = Button.Load;
                this.load.Color = this.activeColor;
            }
            if (this.editor.Rectangle.Intersects(Input.MouseRect()))
            {
                if (Input.EdgeDetectMousePressLeft())
                {
                    this.game.GameState = this.game.LevelEditorScene;
                }
                this.ResetButtonColor();
                this.buttonState = Button.Editor;
                this.editor.Color = this.activeColor;
            }
            if (this.help.Rectangle.Intersects(Input.MouseRect()))
            {
                if (Input.EdgeDetectMousePressLeft())
                {
                    this.game.GameState = this.game.HelpScene;
                }
                this.ResetButtonColor();
                this.buttonState = Button.Help;
                this.help.Color = this.activeColor;
            }
            if (this.scores.Rectangle.Intersects(Input.MouseRect()))
            {
                
                this.ResetButtonColor();
                this.buttonState = Button.Scores;
                this.scores.Color = this.activeColor;
            }
            if (this.quit.Rectangle.Intersects(Input.MouseRect()))
            {
                
                this.ResetButtonColor();
                this.buttonState = Button.Quit;
                this.quit.Color = this.activeColor;
            }
            // Maak een switch-case instructie voor het evalueren van de variabele this.buttonState
            switch (this.buttonState)
            {
                case Button.Start:
                    this.start.Color = this.activeColor;
                    if (Input.EdgeDetectKeyDown(Keys.Enter))
                    {
                        this.game.GameState = this.game.PlayScene;
                    }
                    break;
                case Button.Load:
                    this.load.Color = this.activeColor;
                    if (Input.EdgeDetectKeyDown(Keys.Enter))
                    {
                        this.game.GameState = this.game.PlayScene;
                    }
                    break;
                case Button.Editor:
                    this.editor.Color = this.activeColor;
                    if (Input.EdgeDetectKeyDown(Keys.Enter))
                    {
                        this.game.GameState = this.game.LevelEditorScene;
                    }
                    break;
                case Button.Help:
                    this.help.Color = this.activeColor;
                    if (Input.EdgeDetectKeyDown(Keys.Enter))
                    {
                        this.game.GameState = this.game.HelpScene;
                    }
                    break;
                case Button.Scores:
                    this.scores.Color = this.activeColor;
                    if (Input.EdgeDetectKeyDown(Keys.Enter))
                    {
                        this.game.GameState = this.game.PlayScene;
                    }
                    break;
                case Button.Quit:
                    this.quit.Color = this.activeColor;
                    if (Input.EdgeDetectKeyDown(Keys.Enter))
                    {
                        this.game.GameState = this.game.PlayScene;
                    }
                    break;
            }
        }
        #endregion


        #region Draw
        public void Draw(GameTime gameTime)
        {
            foreach (Image button in this.buttonList)
            {
                button.Draw(gameTime);
            }
        }
        #endregion

        #region Helper methods
        private void ResetButtonColor()
        {
            foreach (Image image in this.buttonList)
            {
                image.Color = Color.White;
            }

        }
        #endregion
    }
}