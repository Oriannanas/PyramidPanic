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
    public class AnimatedSprite
    {
        private PyramidPanic game;
        protected Rectangle spriteRect, sourceRect;
        private float timer = 0f;
        protected SpriteEffects effect;

        public AnimatedSprite(PyramidPanic game)
        {
            this.game = game;
            this.sourceRect = new Rectangle(64, 0, 32, 32);
            this.spriteRect = new Rectangle(100, 200, 32, 32);
            this.effect = SpriteEffects.FlipHorizontally;
        }
        public void Update(GameTime gameTime)
        {
            if (this.timer > 5 / 60f)
            {
                if (this.sourceRect.X < 96)
                {
                    this.sourceRect.X += 32;
                }
                else
                {
                    this.sourceRect.X = 0;
                }

                this.timer = 0f;
            }
            this.timer += 1 / 60f;
        }
        public void Draw(GameTime gameTime, Texture2D texture)
        {
            this.game.SpriteBatch.Draw(texture,
                this.spriteRect,
                this.sourceRect,
                Color.White,
                0f,
                Vector2.Zero,
                this.effect,
                0f);
        }
    
    }
}
