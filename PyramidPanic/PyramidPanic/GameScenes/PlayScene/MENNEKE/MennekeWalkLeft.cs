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
    public class MennekeWalkLeft : AnimatedSprite, IEntityState
    {
        // Fields
        private Menneke menneke;
        private Vector2 velocity;


        // Constructor van deze toestands class krijgt altijd het object mee
        // van de hoofdclass Menneke als argument
        public MennekeWalkLeft(Menneke menneke)
            : base(menneke)
        {
            this.menneke = menneke;
            this.velocity = new Vector2(this.menneke.Speed, 0f);
            this.effect = SpriteEffects.FlipHorizontally;
        }
        //Initialize
        public void Initialize()
        {
            this.destinationRect.X = (int)this.menneke.Position.X;
            this.destinationRect.Y = (int)this.menneke.Position.Y;
        }
        //Update
        public new void Update(GameTime gameTime)
        {
            //zorgt dat menneke vooruit gaat
            this.menneke.Position -= this.velocity;
            this.destinationRect.X = (int)this.menneke.Position.X;
            this.destinationRect.Y = (int)this.menneke.Position.Y;

            //wanneer de menneke aan het einde van het scherm zit
            if (this.menneke.Position.X < 16)
            {
                //word menneke eens tapje terug gezet
                this.menneke.Position += this.velocity;
                //de state op idleWalk gezet
                this.menneke.State = this.menneke.IdleWalk;
                this.menneke.IdleWalk.Initialize();
                //terwijl de kijkrichting onthouden word
                this.menneke.IdleWalk.Effect = SpriteEffects.FlipHorizontally;
                this.menneke.IdleWalk.Rotation = 0f;
            }
            //wanneer de linker knop word los gelaten
            if (Input.LevelDetectKeyUp(Keys.Left))
            {
                //gaat de state naar idle
                this.menneke.State = this.menneke.Idle;
                this.menneke.Idle.Initialize();
                //terwijl de kijkricht bewaard blijft
                this.menneke.Idle.Effect = SpriteEffects.FlipHorizontally;
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
