using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace HowlingEscape
{
    class Trunk : GameObject
    {
        Texture2D sprite;

        public Trunk(Vector2 pos)
        {
            position = pos;
            sprite = Game1.contentManager.Load<Texture2D>("Trunk");
        }

        public override void Update(GameTime gameTime)
        {
            position.X -= Game1.speed;
            if (position.X < -50)
                Objects.RemoveList.Add(this);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, position, Color.White);
        }
    }
}
