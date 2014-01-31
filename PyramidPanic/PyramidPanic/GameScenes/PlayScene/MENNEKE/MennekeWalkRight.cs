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
    // Dit is de toestands class van de Menneke    
    public class MennekeWalkRight : AnimatedSprite, IEntityState
    {
        // Fields
        private Menneke menneke;
        private Vector2 velocity;

        // Constructor van deze toestands class krijgt altijd het object mee
        // van de hoofdclass Menneke als argument
        public MennekeWalkRight(Menneke menneke)  : base(menneke)
        {
            this.menneke = menneke;
            this.velocity = new Vector2(this.menneke.Speed, 0f);
            this.effect = SpriteEffects.None;
            this.imageNumber = 1;
            this.sourceRect = new Rectangle(this.imageNumber * 32, 0, 32, 32);
        }
        //initialize
        public void Initialize()
        {
            this.destinationRect.X = (int)this.menneke.Position.X;
            this.destinationRect.Y = (int)this.menneke.Position.Y;
            this.effect = SpriteEffects.None;
        }
        //update
        public new void Update(GameTime gameTime)
        {
            //zorgt dat menneke vooruitgaat
            this.menneke.Position += this.velocity;
            this.destinationRect.X = (int)this.menneke.Position.X;
            this.destinationRect.Y = (int)this.menneke.Position.Y;
            //wanneer menneke aan het einde van het scherm staat
            if (this.menneke.Position.X > 640 - 16)
            {
                //word een klein stapje terug gezet
                this.menneke.Position -= this.velocity;
                //en word de state gezet op IdleWalk
                this.menneke.State = this.menneke.IdleWalk;
                this.menneke.IdleWalk.Initialize();
                //terwijl de kijkrichting bewaard word
                this.menneke.IdleWalk.Rotation = 0f;
                this.menneke.IdleWalk.Effect = SpriteEffects.None;
            }
            //wanneer de knop naar rechts losgelaten word
            if (Input.LevelDetectKeyUp(Keys.Right))
            {
                //gaat de state naar idle
                this.menneke.State = this.menneke.Idle;
                this.menneke.Idle.Initialize();
                // terwijl de kijkrichting bewaard blijft
                this.menneke.Idle.Rotation = 0f;
            }
            // Zorgt voor de animatie 
            base.Update(gameTime);
        }
        //draw
        public new void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
    }
}
