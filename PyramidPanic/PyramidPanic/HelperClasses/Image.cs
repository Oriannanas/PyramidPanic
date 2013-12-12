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

        #endregion
        //fields of ookwel genaamd class variables, staan boven aan een class en zijn over het algemeen alleen beschikbaar binnen die class
        private PyramidPanic game;
        private Texture2D texture;

        #region properties

        #endregion

        #region Constructor
        //dit is de constructor van deze class
        public Image(PyramidPanic game, string pathNameAsset)
        {
            this.texture = game.Content.Load<Texture2D>(pathNameAsset);
            
        }
        #endregion

        #region Update
        public void Update()
        {
        }
        #endregion

        #region Draw
        public void Draw()
        {
        }
        #endregion
    }
}
