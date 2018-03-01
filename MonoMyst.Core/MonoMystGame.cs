﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

using MonoMyst.Core.ECS;

namespace MonoMyst.Core
{
    public class MonoMystGame : Game
    {
        public static Scene Scene { get; private set; }

        protected GraphicsDeviceManager GraphicsDeviceManager;
        private SpriteBatch spriteBatch;

        public static Camera Camera { get; private set; }

        public MonoMystGame ()
        {
            GraphicsDeviceManager = new GraphicsDeviceManager (this);
            IsMouseVisible = true;

            Camera = new Camera (GraphicsDevice)
            {
                Position = Vector2.Zero
            };
        }

        protected override void Initialize ()
        {
            base.Initialize ();
        }

        protected override void LoadContent ()
        {
            spriteBatch = new SpriteBatch (GraphicsDevice);
        }

        protected override void Update (GameTime gameTime)
        {
            base.Update (gameTime);

            float deltaTime = (float) gameTime.ElapsedGameTime.TotalSeconds;
            Scene.Update (deltaTime);
        }

        protected override void Draw (GameTime gameTime)
        {
            GraphicsDevice.Clear (Scene.ClearColor);

            spriteBatch.Begin (transformMatrix: Camera.Transform);

            Scene.Draw (spriteBatch);

            spriteBatch.End ();

            base.Draw (gameTime);
        }

        /// <summary>
        /// Switches to the next scene.
        /// </summary>
        public void NextScene (Scene scene)
        {
            Scene = scene;
            Scene.Current = Scene;
            Scene.Initialize ();
        }
    }
}
