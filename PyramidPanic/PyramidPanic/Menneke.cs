using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace PyramidPanic
{
    class Menneke
    {
        private KeyboardState ks, oks;
        private Texture2D texture;
        private Rectangle rect, cam;
        private Vector2 position;
        private Keys downKey, upKey, leftKey, rightKey;
        private SpriteEffects spriteEffects;

        public Menneke(Texture2D texture, int x, int y, Keys downKey, Keys upKey, Keys leftKey, Keys rightKey)
        {
            this.texture = texture;
            this.position = new Vector2(x, y);
            this.downKey = downKey;
            this.upKey = upKey;
            this.leftKey = leftKey;
            this.rightKey = rightKey;
            this.spriteEffects = SpriteEffects.None;
            this.rect = new Rectangle((int)this.position.X, (int)this.position.Y, 32, 32);
            this.cam = new Rectangle(0, 0, 32, 32);
        }
        public void Update()
        {
            this.ks = Keyboard.GetState();

            oks = ks;
        }
        public void Draw(SpriteBatch spriteBatch)
        {

            spriteBatch.Draw(texture, rect, cam, Color.White, 0f, new Vector2(0, 0), spriteEffects, 1f);

        }
    }
}
