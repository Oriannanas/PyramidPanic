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
    // Dit is de toestands class van de Beetle    
    public class WalkLeft : AnimatedSprite, IEntityState
    {
        // Fields
        private Scorpion scorpion;
        private Vector2 velocity;
        
        // Constructor van deze toestands class krijgt altijd het object mee
        // van de hoofdclass Beetle als argument
        public WalkLeft(Scorpion scorpion) : base(scorpion)
        {
            this.scorpion = scorpion;
        }
        //initialize
        public void Initialize()
        {
            this.destinationRect.X = (int)this.scorpion.Position.X;
            this.destinationRect.Y = (int)this.scorpion.Position.Y;
            this.effect = SpriteEffects.FlipHorizontally;
            this.velocity = new Vector2(this.scorpion.Speed, 0f);
        }
        //update
        public new void Update(GameTime gameTime)
        {
            //wanneer de scorpion aan het einde van het scherm is
            if (this.scorpion.Position.X < 16)
            {
                //word de looprichting omgedraaid
                this.scorpion.State = this.scorpion.WalkRight;
                this.scorpion.WalkRight.Initialize();
            }
            //zorgt ervoor dat de scorpion loopt
            this.scorpion.Position -= this.velocity;
            base.Update(gameTime);
        }
        //draw
        public new void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
    }
}
