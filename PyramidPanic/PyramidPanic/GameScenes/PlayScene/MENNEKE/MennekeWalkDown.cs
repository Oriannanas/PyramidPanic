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
    public class MennekeWalkDown : AnimatedSprite, IEntityState
    {
        // Fields
        private Menneke menneke;
        private Vector2 velocity;


        // Constructor van deze toestands class krijgt altijd het object mee
        // van de hoofdclass Menneke als argument
        public MennekeWalkDown(Menneke menneke)
            : base(menneke)
        {
            this.menneke = menneke;
            this.velocity = new Vector2(0f, this.menneke.Speed);
            this.effect = SpriteEffects.None;
            this.rotation = (float)Math.PI / 2;
        }
        //Initialize
        public void Initialize()
        {
            this.destinationRect.X = (int)this.menneke.Position.X;
            this.destinationRect.Y = (int)this.menneke.Position.Y;
            this.effect = SpriteEffects.None;
        }

        //Update
        public new void Update(GameTime gameTime)
        {
            //zorgt dat menneke vooruit gaat
            this.menneke.Position += this.velocity;
            this.destinationRect.X = (int)this.menneke.Position.X;
            this.destinationRect.Y = (int)this.menneke.Position.Y;

            //wanneer je tegen de buitenkant van het leven aan loopt
            if (this.menneke.Position.Y > 480 - 16f)
            {
                //word een klein stapje terug gezet
                this.menneke.Position -= this.velocity;
                //en gaat de state naar idle
                this.menneke.State = this.menneke.IdleWalk;
                this.menneke.IdleWalk.Initialize();
                //terwijl de kijkrichting hetzelfde blijft
                this.menneke.IdleWalk.Effect = SpriteEffects.None;
                this.menneke.IdleWalk.Rotation = (float)Math.PI / 2;
            }
            //wanneer de Knop word losgelaten
            if (Input.LevelDetectKeyUp(Keys.Down))
            {
                //gaat de state naar idle
                this.menneke.State = this.menneke.Idle;
                this.menneke.Idle.Initialize();
                //terwijl de kijkRichting onthouden word
                this.menneke.Idle.Rotation = (float)Math.PI / 2;
            }

            // Zorgt voor de animatie 
            base.Update(gameTime);
        }
        //Draw
        public new void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
    }
}
