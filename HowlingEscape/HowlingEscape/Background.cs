using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace HowlingEscape
{
    class Background : GameObject
    {
        public Texture2D sprite;
        int scrollSpeed, shawm, xpos; 

        public Background(Texture2D art, int speed, int seam)
        {
            //sprite = Game1.contentManager.Load<Texture2D>("BG");
            sprite = art;
            scrollSpeed = speed;
            shawm = seam; //It's a deltarune pun
        }

        public override void Update(GameTime gameTime)
        {
            xpos -= scrollSpeed; //making use of an int instead of the provided Position vector2 to avoid floats, so I can do this:
            if (xpos * -1 % shawm == 0)
                xpos = 0;


        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, new Vector2(xpos, 0), Color.White);
            spriteBatch.Draw(sprite, new Vector2(xpos + sprite.Width, 0), Color.White);
        }
    }
}
