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
    public class GameOverScene : IGameState
    {
        //Fields
        private PyramidPanic game;

        //Constructor
        public GameOverScene(PyramidPanic game)
        {
            this.game = game;
            //roep de initialize aan
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

        }


        //Update
        public void Update(GameTime gameTime)
        {
            //als de B toets word in gedruk
            if (Input.EdgeDetectKeyDown(Keys.B))
            {
                //veranderd de GameState naar StartScene
                this.game.GameState = this.game.StartScene;
            }
        }

        //Draw
        public void Draw(GameTime gameTime)
        {
            //achtergrond kleur
            this.game.GraphicsDevice.Clear(Color.Yellow);
        }
    }
}