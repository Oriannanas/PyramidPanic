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
    public class Image
    {

        #region fields
        //fields of ookwel genaamd class variables, staan boven aan een class en zijn over het algemeen alleen beschikbaar binnen die class
        //hier worden de fields aangemaakt

        //dit is de field die de methods uit de game class op kan vragen
        private PyramidPanic game;
        //met een texture 2D kun je een plaatje maken
        private Texture2D texture;
        //met deze rectangle geven we het plaatje een locatie en grootte
        private Rectangle rect;
        #endregion
        

        #region properties

        #endregion

        #region Constructor
        //dit is de constructor van deze class hierin word gevraagd naar welke game gebruikt moet worden,
        //welk plaatje er gebruikt moet worden uit het content mapje (pathNameAsset), en de positie van het aangemaakte plaatje)

        public Image(PyramidPanic game, string pathNameAsset, Vector2 position)
        {
            //we zorgen ervoor dat de field game gelijk is aan de aan de constructor opgegeven game
            this.game = game;
            //hier word het plaatje geladen
            this.texture = game.Content.Load<Texture2D>(pathNameAsset);
            //deze rectangle neemt de in de constructor opgegeven positie aan en neemt de grootte van het plaatje aan
            this.rect = new Rectangle(  (int)position.X,
                                        (int)position.Y,
                                        this.texture.Width,
                                        this.texture.Height);            
        }
        #endregion

        #region Update
        public void Update()
        {
        }
        #endregion

        #region Draw
        // de draw method van deze class
        public void Draw(GameTime gameTime)
        {
            //hier wordt gezorgd dat elk plaatje dat opgevraagd is via deze Image class ook word getekent op het scherm op de plek die aangegeven is
            this.game.SpriteBatch.Draw(texture, rect, Color.White);
        }
        #endregion
    }
}
