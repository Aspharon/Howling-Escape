using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace HowlingEscape
{
    class Bush : GameObject
    {
        Texture2D sprite;

        public Bush()
        {
            position = new Vector2(380, 72);
            sprite = Game1.contentManager.Load<Texture2D>("Bush");
        }

        public override void Update(GameTime gameTime)
        {
            position.X -= Game1.speed;
        }

        public override void HandleInput(InputHelper inputHelper)
        {
            if (inputHelper.KeyPressed(Microsoft.Xna.Framework.Input.Keys.B))
            {
                FallenBush fallenBush = new FallenBush(position);
                Trunk trunk = new Trunk(position);
                Objects.AddList.Add(fallenBush);
                Objects.AddList.Add(trunk);
                position.X = -200;
            }
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, position, Color.White);
        }
    }
}
