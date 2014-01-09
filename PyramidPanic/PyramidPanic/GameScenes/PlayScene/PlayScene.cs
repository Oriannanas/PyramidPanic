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
            this.scorpion = new Scorpion(this.game);
            this.beetle = new Beetle(this.game);
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
        }

        //Draw
        public void Draw(GameTime gameTime)
        {
            this.game.GraphicsDevice.Clear(Color.Blue);
            this.scorpion.Draw(gameTime);
            this.beetle.Draw(gameTime);
        }
       

    }
}