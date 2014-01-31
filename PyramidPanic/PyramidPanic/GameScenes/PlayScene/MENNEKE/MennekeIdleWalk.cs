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
    public class MennekeIdleWalk : AnimatedSprite, IEntityState
    {
        // Fields
        private Menneke menneke;
        private Vector2 velocity;

        //properties
        public SpriteEffects Effect
        {
            set { this.effect = value; }
        }

        // Constructor van deze toestands class krijgt altijd het object mee
        // van de hoofdclass Menneke als argument
        public MennekeIdleWalk(Menneke menneke)
            : base(menneke)
        {
            this.menneke = menneke;
            this.velocity = new Vector2(this.menneke.Speed, 0f);
            this.effect = SpriteEffects.None;
            this.imageNumber = 1;
            this.sourceRect = new Rectangle(this.imageNumber * 32, 0, 32, 32);
        }
        //Initalize
        public void Initialize()
        {
            this.destinationRect.X = (int)this.menneke.Position.X;
            this.destinationRect.Y = (int)this.menneke.Position.Y;
            this.effect = SpriteEffects.None;
        }
        //Update
        public new void Update(GameTime gameTime)
        {
            //wanneer de Knop naar rechts word losgelaten
            if (Input.EdgeDetectKeyUp(Keys.Right))
            {
                //gaat de state naar idle
                this.menneke.State = this.menneke.Idle;
                this.menneke.Idle.Initialize();
                //maar wordt zijn kijkrichting onthouden
                this.menneke.Idle.Rotation = 0f;
                this.menneke.Idle.Effect = SpriteEffects.None;
            }
            //wanneer de Knop naar links word losgelaten
            if (Input.EdgeDetectKeyUp(Keys.Left))
            {
                //gaat de state naar idle
                this.menneke.State = this.menneke.Idle;
                this.menneke.Idle.Initialize();
                //maar wordt zijn kijkrichting onthouden
                this.menneke.Idle.Rotation = 0f;
                this.menneke.Idle.Effect = SpriteEffects.FlipHorizontally;
            }
            //wanneer de Knop naar beneden word losgelaten
            if (Input.EdgeDetectKeyUp(Keys.Down))
            {
                //gaat de state naar idle
                this.menneke.State = this.menneke.Idle;
                this.menneke.Idle.Initialize();
                //maar wordt zijn kijkrichting onthouden
                this.menneke.Idle.Rotation = (float)Math.PI/2;
                this.menneke.Idle.Effect = SpriteEffects.None;
            }
            //wanneer de Knop naar boven word losgelaten
            if (Input.EdgeDetectKeyUp(Keys.Up))
            {
                //gaat de state naar idle
                this.menneke.State = this.menneke.Idle;
                this.menneke.Idle.Initialize();
                //maar wordt zijn kijkrichting onthouden
                this.menneke.Idle.Rotation = (float)Math.PI / 2;
                this.menneke.Idle.Effect = SpriteEffects.FlipHorizontally;
            }
            base.Update(gameTime);
        }
        //Update
        public new void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
    }
}
