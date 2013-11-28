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
    class MenuScene
    {
        //fields
        private PyramidPanic game;
        //constructors
        public MenuScene(PyramidPanic game)
        {
            this.game = game;
            this.Initialize();
        }
        //initialize
        public void Initialize()
        {
            this.LoadContent();
        }
        //LoadContent
        public void LoadContent()
        {
            
        }
        //update
        public void Update(GameTime gameTime)
        {

        }
        //draw methode
        public void Draw(GameTime gameTime)
        {
            spriteBatch.Draw(Content.Load<Texture2D>("./Background/background"), new Rectangle(0, 0, 640, 480), Color.White);
        }
    }
}
