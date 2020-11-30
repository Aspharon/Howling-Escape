using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace HowlingEscape
{
    class Background : GameObject
    {
        Texture2D sprite;

        public Background()
        {
            sprite = Game1.contentManager.Load<Texture2D>("BG");
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, Vector2.Zero, Color.White);
        }
    }
}
