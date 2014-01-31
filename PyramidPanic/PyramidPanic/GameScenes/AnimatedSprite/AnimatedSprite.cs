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
        //Fields
        private IAnimatedSprite iAnimatedSprite;
        protected Rectangle destinationRect, sourceRect;
        protected SpriteEffects effect = SpriteEffects.None;
        private float timer = 0f;
        protected int imageNumber = 0;
        protected float rotation = 0f;
        private Vector2 pivot;

        //properties
        public float Rotation
        {
            //alleen een setter
            set { this.rotation = value; }
        }


        // Constructor
        public AnimatedSprite(IAnimatedSprite iAnimatedSprite)
        {
            this.iAnimatedSprite = iAnimatedSprite;
            //we maken een destinationRect aan die gebruikt word vooor de geanimeerde sprites
            this.destinationRect = new Rectangle((int)this.iAnimatedSprite.Position.X,(int)this.iAnimatedSprite.Position.Y, 32, 32);
            //en een sourceRect voor de animatie(soort van cameraatje)
            this.sourceRect = new Rectangle(this.imageNumber * 32, 0, 32, 32);
            // hier word de vector pivot een waarde gegeven
            this.pivot = new Vector2(16f, 16);
        }
        //Update methode
        public void Update(GameTime gameTime)
        {
            //timertje
            if (this.timer > 5 / 60f)
            {
                //checkt of de sourceRect niet op zn maximum (laatste plaatje) staat
                if (this.sourceRect.X < 96)
                {
                    //zo ja? de camera gaat verder
                    this.sourceRect.X += 32;
                }
                else
                {
                    //zo niet? de camera word gereset
                    this.sourceRect.X = 0;
                }
                //timer reset
                this.timer = 0f;
            }
            else
            {
                //onderdeel van timertje
                this.timer += 1 / 60f;
            }

            //zet de position van de sprite gelijk aan de hier gedefineerde destination rect
            this.destinationRect.X = (int)this.iAnimatedSprite.Position.X;
            this.destinationRect.Y = (int)this.iAnimatedSprite.Position.Y;
        }

        // Draw method
        public void Draw(GameTime gameTime)
        {
            // hier wordt de AnimatedSprite gedrawed
            this.iAnimatedSprite.Game.SpriteBatch.Draw(this.iAnimatedSprite.Texture,this.destinationRect,this.sourceRect, Color.White, this.rotation,this.pivot, this.effect, 0f);
        }
    }
}
