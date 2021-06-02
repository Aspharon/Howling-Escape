using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace HowlingEscape
{
    class Tree : GameObject
    {
        Texture2D sprite;

        public Tree()
        {
            position = new Vector2(380, 66);
            int type = Game1.rand.Next(5);

            switch (type)
            {
                case 0:
                    sprite = Game1.contentManager.Load<Texture2D>("tree0");
                    break;
                case 1:
                    sprite = Game1.contentManager.Load<Texture2D>("tree1");
                    break;
                case 2:
                    sprite = Game1.contentManager.Load<Texture2D>("tree2");
                    break;
                case 3:
                    sprite = Game1.contentManager.Load<Texture2D>("tree3");
                    break;
                case 4:
                    sprite = Game1.contentManager.Load<Texture2D>("tree4");
                    break;
            }

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
