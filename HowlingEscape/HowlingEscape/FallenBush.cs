using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace HowlingEscape
{
    class FallenBush : GameObject
    {
        public Texture2D sprite;
        float rotation;
        Vector2 origin;
        public bool hit;

        public FallenBush(Vector2 pos)
        {
            position = pos;
            sprite = Game1.contentManager.Load<Texture2D>("FallenBush");
            origin = new Vector2(sprite.Width / 2, sprite.Height / 2);
        }

        public override void Update(GameTime gameTime)
        {
            rotation -= 0.03f;
            position.X -= Game1.speed + 5;
            if (position.X < -50)
                Objects.RemoveList.Add(this);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, position + origin, null, Color.White, rotation, origin, 1, 0, 0);
        }
    }
}
