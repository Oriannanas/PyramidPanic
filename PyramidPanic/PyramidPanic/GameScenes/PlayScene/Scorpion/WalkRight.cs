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
    // Dit is de toestands class van de Beetle    
    public class WalkRight : AnimatedSprite, IEntityState
    {
        // Fields
        private Scorpion scorpion;
        private Vector2 velocity;


        // Constructor van deze toestands class krijgt altijd het object mee
        // van de hoofdclass Beetle als argument
        public WalkRight(Scorpion scorpion) : base(scorpion)
        {
            this.scorpion = scorpion;
            this.velocity = new Vector2(this.scorpion.Speed, 0f);
            this.effect = SpriteEffects.FlipVertically;
        }
        //initialize
        public void Initialize()
        {
            this.destinationRect.X = (int)this.scorpion.Position.X;
            this.destinationRect.Y = (int)this.scorpion.Position.Y;
            this.effect = SpriteEffects.None;
        }
        //update
        public new void Update(GameTime gameTime)
        {
            //wanneer de scorpion aan het einde van het scherm is 
            if (this.scorpion.Position.X > 640 - 16)
            {
                //word de richting omgedraaid
                this.scorpion.State = this.scorpion.WalkLeft;
                this.scorpion.WalkLeft.Initialize();
            }
            //hierdoor loopt de scorpion
            this.scorpion.Position += this.velocity;
            base.Update(gameTime);
        }
        //draw
        public new void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
    }
}
