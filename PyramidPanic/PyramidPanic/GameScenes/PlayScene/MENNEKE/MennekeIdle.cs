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
    public class MennekeIdle : AnimatedSprite, IEntityState
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
        public MennekeIdle(Menneke menneke)
            : base(menneke)
        {
            this.menneke = menneke;
            this.velocity = new Vector2(this.menneke.Speed, 0f);
            this.effect = SpriteEffects.None;
            this.imageNumber = 1;
            //maakt nieuwe "camera"
            this.sourceRect = new Rectangle(this.imageNumber * 32, 0, 32, 32);
        }
        //initalize
        public void Initialize()
        {
            //geeft menneke een begin positie
            this.destinationRect.X = (int)this.menneke.Position.X;
            this.destinationRect.Y = (int)this.menneke.Position.Y;
            //zet de Spriteeffect op niks
            this.effect = SpriteEffects.None;
        }
        //Update
        public new void Update(GameTime gameTime)
        {
            //zo lang als dat de knop naar rechts is ingedrukt
            if (Input.LevelDetectKeyDown(Keys.Right))
            {
                //veranderd de State van Menneke in de WalkRight state
                this.menneke.State = this.menneke.WalkRight;
                this.menneke.WalkRight.Initialize();
            }
            //wanneer de knop links ingedrukt is
            if (Input.LevelDetectKeyDown(Keys.Left))
            {
                //word de state veranderd naar WalkLeft
                this.menneke.State = this.menneke.WalkLeft;
                this.menneke.WalkLeft.Initialize();
            }
            //en het zelfde voor de knop Down
            if (Input.LevelDetectKeyDown(Keys.Down))
            {
                //en WalkDown
                this.menneke.State = this.menneke.WalkDown;
                this.menneke.WalkDown.Initialize();
            }
            //en als laatste de knop Up
            if (Input.LevelDetectKeyDown(Keys.Up))
            {
                //naar de state WalkUp
                this.menneke.State = this.menneke.WalkUp;
                this.menneke.WalkUp.Initialize();
            }
        }
        //Draw
        public new void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
    }
}
