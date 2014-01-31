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
    public class Scorpion : IAnimatedSprite
    {
        // Fields
        private Vector2 position;
        private int speed = 2;
        private PyramidPanic game;
        private IEntityState state;
        private Texture2D texture;
        private WalkLeft walkLeft;
        private WalkRight walkRight;

        // Properties
        public Vector2 Position
        {
            get { return this.position; }
            set { this.position = value; }
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
        public WalkRight WalkRight
        {
            get { return this.walkRight; }
        }
        public WalkLeft WalkLeft
        {
            get { return this.walkLeft; }
        }


        // Maak de constructor
        public Scorpion(PyramidPanic game, Vector2 position, int speed)
        {
            //de variabele van de class worden gelijkt gezet aan wat aan de constructor is meegegeven
            this.position = position;
            this.game = game;
            this.speed = speed;
            //texture word geladen
            this.texture = this.game.Content.Load<Texture2D>(@"Monsters\Scorpion");
            //maakt nieuwe objecten aan voor de beweging classes
            this.walkRight = new WalkRight(this);
            this.walkLeft = new WalkLeft(this);
            this.state = this.walkRight;
        }
        //update
        public void Update(GameTime gameTime)
        {
            this.state.Update(gameTime);
        }
        //draw
        public void Draw(GameTime gameTime)
        {
            this.state.Draw(gameTime);
        }
    }
}
