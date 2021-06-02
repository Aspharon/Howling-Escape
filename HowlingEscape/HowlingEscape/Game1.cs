using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Linq;
using System;


namespace HowlingEscape
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        private InputHelper inputHelper;
        private GraphicsHelper graphicsHelper;
        private Wolf wolf;
        private Vine vine;
        public static ContentManager contentManager;
        public static Random rand;
        public static int speed = 4;
        public static int gamestate;

        int timeSinceLastBush, timeSinceLastTree;

        public Game1()
        {
            contentManager = Content;
            contentManager.RootDirectory = "Content";
            graphicsHelper = new GraphicsHelper(this);
            inputHelper = new InputHelper();
            IsMouseVisible = true;
            rand = new Random();
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            Background BG = new Background(contentManager.Load<Texture2D>("start"), 0, 1);
            Objects.List.Add(BG);
            gamestate = 1;
            base.Initialize();
        }

        void Start()
        {
            gamestate = 0;
            Objects.List.Clear();
            Background BG1 = new Background(contentManager.Load<Texture2D>("BG1"), speed / 4, 60);
            Objects.List.Add(BG1);
            Background BG2 = new Background(contentManager.Load<Texture2D>("BG2"), speed / 4 * 2, 120);
            Objects.List.Add(BG2);
            Background BG3 = new Background(contentManager.Load<Texture2D>("BG3"), speed / 4 * 3, 240);
            Objects.List.Add(BG3);
            Background BG4 = new Background(contentManager.Load<Texture2D>("BG4"), speed, 357);
            Objects.List.Add(BG4);

            wolf = new Wolf();
            Objects.List.Add(wolf);

            vine = new Vine();
            Objects.List.Add(vine);
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {

        }
        
        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            inputHelper.Update(gameTime);

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (gamestate == 0)
            {
                timeSinceLastBush++;
                timeSinceLastTree++;

                if (timeSinceLastBush > 100 && rand.Next(100) == 1 || timeSinceLastBush > 360)
                {
                    timeSinceLastBush = 0;
                    Bush bush = new Bush();
                    Objects.List.Add(bush);
                }

                if (rand.Next(350) == 1)
                {
                    Bird bird = new Bird();
                    Objects.List.Add(bird);
                }

                if (timeSinceLastTree > 4 && rand.Next(6) == 1)
                {
                    timeSinceLastTree = 0;
                    Tree tree = new Tree();
                    Objects.List.Add(tree);
                }
                
                //The following code removes the wolf, vine, and bushes from the object list, and then re-adds them, ensuring they get drawn in the right order. It's filthy and not at all recommended.

                List<Bush> bushes = new List<Bush>();
                foreach(Bush bush in Objects.List.OfType<Bush>())
                {
                    bushes.Add(bush);
                }

                foreach (Bush bush in bushes)
                {
                    Objects.List.Remove(bush);
                    Objects.List.Add(bush);
                }

                Objects.List.Remove(vine);
                Objects.List.Add(vine);

                Objects.List.Remove(wolf);
                Objects.List.Add(wolf);
            }
            else
            {
                if (inputHelper.KeyDown(Keys.Space))
                {
                    Start();
                }
            }

            base.Update(gameTime);
            graphicsHelper.Update(gameTime);
            graphicsHelper.HandleInput(inputHelper);
            foreach (GameObject obj in Objects.List)
                obj.HandleInput(inputHelper);
            foreach (GameObject obj in Objects.List)
                obj.Update(gameTime);
            foreach (GameObject obj in Objects.AddList)
                Objects.List.Add(obj);
            Objects.AddList.Clear();
            foreach (GameObject obj in Objects.RemoveList)
                Objects.List.Remove(obj);
            Objects.RemoveList.Clear();
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            GraphicsDevice.SetRenderTarget(null);
            graphicsHelper.Draw(gameTime);
        }
    }
}
