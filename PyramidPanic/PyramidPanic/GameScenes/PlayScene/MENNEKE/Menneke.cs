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
    public class Menneke : IAnimatedSprite
    {
        // Fields
        private Vector2 position;
        private int speed = 2;
        private PyramidPanic game;
        private IEntityState state;
        private Texture2D texture;
        private MennekeIdle idle;
        private MennekeWalkRight walkRight;
        private MennekeWalkLeft walkLeft;
        private MennekeWalkDown walkDown;
        private MennekeWalkUp walkUp;
        private MennekeIdleWalk idleWalk;

        // Properties zijn nodig om de waarden in andere classes 
        // op te kunnen vragen of eventueel te kunnen veranderen
        public Vector2 Position
        {
            get { return this.position; }
            set
            {
                this.position = value;
            }
        }
        public PyramidPanic Game
        {
            get { return this.game; }
        }
        public int Speed
        {
            get { return this.speed; }
        }
        public IEntityState State
        {
            get { return this.state; }
            set { this.state = value; }
        }
        public Texture2D Texture
        {
            get { return this.texture; }
        }
        public MennekeIdle Idle
        {
            get { return this.idle; }
        }
        public MennekeWalkRight WalkRight
        {
            get { return this.walkRight; }
        }
        public MennekeWalkLeft WalkLeft
        {
            get { return this.walkLeft; }
        }
        public MennekeWalkDown WalkDown
        {
            get { return this.walkDown; }
        }
        public MennekeWalkUp WalkUp
        {
            get { return this.walkUp; }
        }
        public MennekeIdleWalk IdleWalk
        {
            get { return this.idleWalk; }
        }


        // Maak de constructor
        public Menneke(PyramidPanic game, Vector2 position, int speed)
        {
            //de variabele van de class worden gelijkt gezet aan wat aan de constructor is meegegeven
            this.position = position;
            this.game = game;
            this.speed = speed;
            //laad de nieuwe texture
            this.texture = this.game.Content.Load<Texture2D>(@"Explorer\explorer");
            //maakt nieuwe objecten aan voor de bewegings classes
            this.idle = new MennekeIdle(this);
            this.walkRight = new MennekeWalkRight(this);
            this.walkLeft = new MennekeWalkLeft(this);
            this.walkDown = new MennekeWalkDown(this);
            this.walkUp = new MennekeWalkUp(this);
            this.idleWalk = new MennekeIdleWalk(this);
            this.state = this.idle;
        }
        //Update
        public void Update(GameTime gameTime)
        {
            this.state.Update(gameTime);
        }
        //Draw
        public void Draw(GameTime gameTime)
        {
            this.state.Draw(gameTime);
        }
    }
}
