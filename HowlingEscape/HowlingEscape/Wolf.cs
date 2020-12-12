using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace HowlingEscape
{
    class Wolf : GameObject
    {
        Texture2D currentSprite;
        Texture2D[] sprites;
        int spriteTimer, animationTime = 5, spriteID;
        Vector2 velocity = Vector2.Zero;
        int airtime;
        bool grounded = true;
        float gravity = 0.2f;

        public Wolf()
        {
            position = new Vector2(100, 96);

            sprites = new Texture2D[5];
            sprites[0] = Game1.contentManager.Load<Texture2D>("W1");
            sprites[1] = Game1.contentManager.Load<Texture2D>("W2");
            sprites[2] = Game1.contentManager.Load<Texture2D>("W3");
            sprites[3] = Game1.contentManager.Load<Texture2D>("W4");
            sprites[4] = Game1.contentManager.Load<Texture2D>("W5");
            currentSprite = sprites[0];
        }

        public override void HandleInput(InputHelper inputHelper)
        {
            if (inputHelper.KeyDown(Microsoft.Xna.Framework.Input.Keys.Space) && grounded)
            {
                grounded = false;
                velocity.Y = -5.5f;
                airtime = 0;
            }
            if (inputHelper.KeyDown(Microsoft.Xna.Framework.Input.Keys.Space) && airtime < 15)
            {
                gravity = 0.1f;
            }
            else gravity = 0.3f;
        }

        public override void Update(GameTime gameTime)
        {
            velocity.Y += gravity;
            position += velocity;
            if (position.Y > 96)
            {
                grounded = true;
                airtime = 0;
                position.Y = 96;
            }
            else airtime++;

            if (velocity.Y > 0 && position.Y >= 50 && position.Y < 92)
            {
                foreach(Bush b in Objects.List.OfType<Bush>())
                {
                    if (b.position.X > position.X - b.sprite.Width && b.position.X < position.X + currentSprite.Width)
                    {
                        b.FallApart();
                        velocity.Y = -5.5f;
                    }
                }
            }

            if (position.Y == 96 && position.Y > 72)
            {
                foreach (Bush b in Objects.List.OfType<Bush>())
                {
                    if (b.position.X > position.X - b.sprite.Width && b.position.X < position.X + currentSprite.Width && !b.hit)
                    {
                        b.hit = true;
                        velocity.X = -5.5f;
                    }
                }
            }

            if (position.Y < 40 && position.Y > 10)
            {
                foreach (Bird b in Objects.List.OfType<Bird>())
                {
                    if (b.position.X > position.X - b.sprites[0].Width && b.position.X < position.X + currentSprite.Width && !b.hit)
                    {
                        b.GetHit();
                        velocity.X = -5.5f;
                    }
                }
            }

            if (position.Y < 10)
            {
                foreach (Bird b in Objects.List.OfType<Bird>())
                {
                    if (b.position.X > position.X - b.sprites[0].Width && b.position.X < position.X + currentSprite.Width && !b.hit)
                    {
                        b.GetHit();
                        velocity.Y = -5.5f;
                    }
                }
            }

            velocity.X *= 0.9f;

            if (position.X < 100)
            {
                position.X += 0.1f;
            }
            else
            {
                position.X = 100;
            }

            Animate();
        }

        void Animate()
        {
            if (grounded)
            {
                spriteTimer++;
                if (spriteTimer == animationTime)
                {
                    spriteTimer = 0;

                    spriteID++;
                    if (spriteID == 5)
                        spriteID = 0;
                    currentSprite = sprites[spriteID];
                }
            }
            else
            {
                currentSprite = sprites[4];
                spriteTimer = 0;
                spriteID = 0;
            }
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(currentSprite, position, Color.White);
        }
    }
}
