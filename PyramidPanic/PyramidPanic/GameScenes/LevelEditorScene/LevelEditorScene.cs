using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace PyramidPanic
{
    public class LevelEditorScene : IGameState 
    {
        //fields
        private PyramidPanic game;
        //constructor
        public LevelEditorScene(PyramidPanic game)
        {
            this.game = game;
            //roep de initalize aan
            this.Initialize();
        }

        //Initialize
        public void Initialize()
        {
            //roep de loadcontent aan
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
            this.game.GraphicsDevice.Clear(Color.Black);
        }
    }
}
