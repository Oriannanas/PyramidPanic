﻿using System;
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

        //constructors
        public MenuScene()
        {

        }
        //initialize
        public void Initialize()
        {

        }
        //LoadContent
        public void LoadContent()
        {

        }
        //update
        public void Update()
        {

        }
        //draw methode
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Content.Load<Texture2D>("./Background/background"), new Rectangle(0, 0, 640, 480), Color.White);
        }
    }
}
