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
    public class Menneke : AnimatedSprite
    {
        private PyramidPanic game;
        private Texture2D texture;
        private int speed = 3;

        public Menneke(PyramidPanic game) : base(game)
        {
            this.texture = game.Content.Load<Texture2D>(@"Explorer\Explorer");
            this.effect = SpriteEffects.None;
        }
        public new void Update(GameTime gameTime)
        {
            if (Input.EdgeDetectKeyDown(Keys.Left))
            {
            }
            this.spriteRect.Y += this.speed;
            base.Update(gameTime);

        }
        public void Draw(GameTime gameTime)
        {
            base.Draw(gameTime, this.texture);
        }
    }
}
