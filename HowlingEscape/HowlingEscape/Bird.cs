using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;

namespace HowlingEscape
{
    class Bird : GameObject
    {
        public Texture2D[] sprites;
        public bool hit;
        int spriteTimer, animationTime = 5, spriteID;
        SoundEffect sound;

        public Bird()
        {
            position = new Vector2(380, 30);
            sprites = new Texture2D[2];
            sprites[0] = Game1.contentManager.Load<Texture2D>("F1");
            sprites[1] = Game1.contentManager.Load<Texture2D>("F2");
            sound = Game1.contentManager.Load<SoundEffect>("pigeon");
        }

        public override void Update(GameTime gameTime)
        {
            position.X -= Game1.speed * 1.2f;
            spriteTimer++;
            if (spriteTimer == animationTime)
            {
                Animate();
                spriteTimer = 0;
            }
        }

        public void GetHit()
        {
            if (hit) return;
            hit = true;
            sound.Play();
        }

        public void Animate()
        {
            if (spriteID == 0) spriteID = 1;
            else spriteID = 0;
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprites[spriteID], position, Color.White);
        }
    }
}
