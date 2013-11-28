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
    class PlayScene
    {
        //fields
        private Texture2D textureMenneke;
        private Menneke menneke;
        //constructors
        public PlayScene()
        {

        }
        //initialize
        public void Initialize()
        {

        }
        //LoadContent
        public void LoadContent()
        {
            textureMenneke = Content.Load<Texture2D>("./MENNEKE/explorer");
            menneke = new Menneke(textureMenneke, 100, 100, Keys.S, Keys.W, Keys.A, Keys.D);
        }
        //update
        public void Update()
        {
           
        }
        //draw methode
        public void Draw()
        {
            spriteBatch.Draw(Content.Load<Texture2D>("./Background/background2"), new Rectangle(0, 0, 640, 480), Color.White);
            menneke.Draw(spriteBatch);
        }
    }
}
