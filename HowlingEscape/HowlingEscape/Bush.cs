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
    class Bush : GameObject
    {
        public Texture2D sprite;
        public bool hit;
        SoundEffect sound;
        public Bush()
        {
            position = new Vector2(380, 72);
            sprite = Game1.contentManager.Load<Texture2D>("Bush");
            sound = Game1.contentManager.Load<SoundEffect>("leaves");
        }

        public override void Update(GameTime gameTime)
        {
            position.X -= Game1.speed;
            if (position.X < -50)
                Objects.RemoveList.Add(this);
        }

        public override void HandleInput(InputHelper inputHelper)
        {
            if (inputHelper.KeyPressed(Microsoft.Xna.Framework.Input.Keys.B))
            {
                //FallApart();
            }
        }

        public void FallApart()
        {
            if (hit) return;
            sound.Play();
            FallenBush fallenBush = new FallenBush(position);
            Trunk trunk = new Trunk(position);
            Objects.AddList.Add(fallenBush);
            Objects.AddList.Add(trunk);
            Objects.RemoveList.Add(this);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, position, Color.White);
        }
    }
}
