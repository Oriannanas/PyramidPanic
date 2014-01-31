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
    public class MennekeWalkUp : AnimatedSprite, IEntityState
    {
        // Fields
        private Menneke menneke;
        private Vector2 velocity;

        // Constructor van deze toestands class krijgt altijd het object mee
        // van de hoofdclass Menneke als argument
        public MennekeWalkUp(Menneke menneke)
            : base(menneke)
        {
            this.menneke = menneke;
            this.velocity = new Vector2(0f, this.menneke.Speed);
            this.effect = SpriteEffects.FlipHorizontally;
            this.rotation = (float)Math.PI /2;
        }
        // initialize
        public void Initialize()
        {
            this.destinationRect.X = (int)this.menneke.Position.X;
            this.destinationRect.Y = (int)this.menneke.Position.Y;
            
        }
        //update
        public new void Update(GameTime gameTime)
        {
            //zorgt ervoor dat menneke kan beweegen
            this.menneke.Position -= this.velocity;
            this.destinationRect.X = (int)this.menneke.Position.X;
            this.destinationRect.Y = (int)this.menneke.Position.Y;
            //wanneer menneke aan het einde van het scherm is
            if (this.menneke.Position.Y < 16)
            {
                //word een klein stapje terug gedaan
                this.menneke.Position += this.velocity;
                //de state word op idleWalk gezet
                this.menneke.State = this.menneke.IdleWalk;
                this.menneke.IdleWalk.Initialize();
                //terwijl de kijkrichting bewaard word
                this.menneke.IdleWalk.Effect = SpriteEffects.FlipHorizontally;
                this.menneke.IdleWalk.Rotation = (float)Math.PI / 2;
            }
            //wanneer de knop naar boven word losgelaten
            if (Input.LevelDetectKeyUp(Keys.Up))
            {
                //gaat de state naar idle
                this.menneke.State = this.menneke.Idle;
                this.menneke.Idle.Initialize();
                //terwijl de kijkrichting onthouden word
                this.menneke.Idle.Effect = SpriteEffects.FlipHorizontally;
                this.menneke.Idle.Rotation = (float)Math.PI / 2;
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
