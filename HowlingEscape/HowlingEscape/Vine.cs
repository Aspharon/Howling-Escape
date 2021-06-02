using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace HowlingEscape
{
    class Vine : GameObject
    {
        Texture2D sprite;
        float creepSpeed = 0.15f;
        float velocity;

        public Vine()
        {
            sprite = Game1.contentManager.Load<Texture2D>("vine");
            position = Vector2.Zero;
            position.X = -1 * sprite.Width;
            position.Y = 100;
        }

        public override void Update(GameTime gameTime)
        {
            position.X += creepSpeed;
            Wiggle();

            foreach (Wolf w in Objects.List.OfType<Wolf>())
            {
                if (position.X + sprite.Width > w.position.X + 15)
                {
                    EndGame();
                }
            }

            foreach (FallenBush b in Objects.List.OfType<FallenBush>())
            {
                if (b.position.X > position.X - b.sprite.Width && b.position.X < position.X + sprite.Width && !b.hit)
                {
                    b.hit = true;
                    velocity = -5.5f;
                }
            }

            velocity *= 0.9f;

            position.X += velocity;

            if (position.X < -1 * sprite.Width)
            {
                position.X = -1 * sprite.Width;
                velocity = 0;
            }
        }

        void Wiggle()
        {
            if (Game1.rand.Next(10) > 0) return;
            position.Y += Game1.rand.Next(-1, 2);
            position.Y = Math.Min(Math.Max(position.Y, 95), 105); //This is fucking ugly but I don't have Clamp() :(
        }

        void EndGame() //this definitely shouldn't be stored in this class lol
        {
            foreach (GameObject o in Objects.List)
            {
                Objects.RemoveList.Add(o);
            }
            Background endScreen = new Background(Game1.contentManager.Load<Texture2D>("end"), 0, 1);
            Objects.AddList.Add(endScreen);
            Game1.gamestate++;
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, position, Color.White);
        }
    }
}
