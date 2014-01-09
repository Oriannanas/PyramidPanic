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
    public class Beetle : AnimatedSprite
    {
        //fields van de Beetle class
        private PyramidPanic game;
        private Texture2D texture;

        public PyramidPanic Game
        {
            get{return this.game;}
        }

        public Beetle(PyramidPanic game) : base(game)
        {
            this.game = game;
            this.texture = game.Content.Load<Texture2D>(@"Monsters\Beetle");
        }
        public void Update(GameTime gameTime)
        {
            base.Update(gameTime);

        }
        public void Draw(GameTime gameTime)
        {
            base.Draw(gameTime, this.texture);
        }
    }
}
