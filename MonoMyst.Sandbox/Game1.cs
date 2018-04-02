﻿using MonoMyst.Engine;
using MonoMyst.Engine.ECS;

namespace MonoMyst.Sandbox
{
    public class Game1 : MonoMystGame
    {
        public Game1 () : base ()
        {
            Window.AllowUserResizing = true;
            GraphicsDeviceManager.PreferredBackBufferWidth = 1280;
            GraphicsDeviceManager.PreferredBackBufferHeight = 720;
            GraphicsDeviceManager.ApplyChanges ();
        }

        protected override void Initialize ()
        {
            base.Initialize ();

            Scene scene = new MainScene (this, GraphicsDeviceManager.GraphicsDevice);
            NextScene (scene);
        }
    }
}
