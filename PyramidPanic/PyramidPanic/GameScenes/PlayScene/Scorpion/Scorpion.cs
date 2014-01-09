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
    public class Scorpion : AnimatedSprite
    {
        //fields van de Scorpion class
        private PyramidPanic game;
        private Texture2D texture;
        private int speed = 2;


        
        public Scorpion(PyramidPanic game) : base(game)
        {
            this.texture = game.Content.Load<Texture2D>(@"Monsters\Scorpion");
        }
        public new void Update(GameTime gameTime)
        {
            if (this.spriteRect.X > (640 - 32) || this.spriteRect.X < 0)
            {
                if (this.speed > 0)
                {
                    this.effect = SpriteEffects.FlipHorizontally;
                }
                else
                {
                    this.effect = SpriteEffects.None;
                }
                this.speed = this.speed * -1;
            }
            this.spriteRect.X += this.speed;
            base.Update(gameTime);

        }
        public void Draw(GameTime gameTime)
        {
            base.Draw(gameTime, this.texture);
        }
    }
}
