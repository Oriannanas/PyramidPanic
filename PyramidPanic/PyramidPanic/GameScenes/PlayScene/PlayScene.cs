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
    public class PlayScene : IGameState
    {
        //Fields
        private PyramidPanic game;
        private Scorpion scorpion;
        private Beetle beetle;
        private Menneke menneke;
        private Image background;

        //Constructor
        public PlayScene(PyramidPanic game)
        {
            this.game = game;
            this.Initialize();
        }

        //Initialize
        public void Initialize()
        {
            this.LoadContent();
        }


        //LoadContent
        public void LoadContent()
        {
            this.beetle = new Beetle(this.game, new Vector2(200f, 300f), 2);
            this.scorpion = new Scorpion(this.game, new Vector2(100f, 300f), 2);
            this.menneke = new Menneke(this.game, new Vector2(304f, 224f), 2);
            this.background = new Image(this.game, @"Background\Background2", Vector2.Zero);
            
        }


        //Update
        public void Update(GameTime gameTime)
        {
            if (Input.EdgeDetectKeyDown(Keys.B))
            {
                this.game.GameState = this.game.StartScene;
            }
            this.scorpion.Update(gameTime);
            this.beetle.Update(gameTime);
            this.menneke.Update(gameTime);
        }

        //Draw
        public void Draw(GameTime gameTime)
        {
            this.game.GraphicsDevice.Clear(Color.Blue);
            this.background.Draw(gameTime);
            this.scorpion.Draw(gameTime);
            this.beetle.Draw(gameTime);
            this.menneke.Draw(gameTime);
           
            
        }
       

    }
}