using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Input;
using GameDev.View;
using GameDev.Model;

namespace GameDev.Controller
{
	/// <summary>
	/// This is the main type for your game.
	/// </summary>
	public class GameDev : Game
	{
		#region Declaration Section
		private GraphicsDeviceManager graphics;
		private SpriteBatch spriteBatch;
		private Player player;

		Texture2D mainBackground;

		ParallaxingBackground bgLayer1;
		ParallaxingBackground bgLayer2;

		private KeyboardState currentKyBoardState;
		private KeyboardState previousKeyBoardStae;

		private float playerMoveSpeed;
		#endregion

		#region Constructor
		public GameDev ()
		{
			graphics = new GraphicsDeviceManager (this);

			graphics.PreferredBackBufferWidth = 800;
			graphics.PreferredBackBufferHeight = 800;
			graphics.IsFullScreen = true;
			graphics.ApplyChanges ();

			Content.RootDirectory = "Content";
		}
		#endregion

		#region Intialize (For Game Engine)
		protected override void Intialize ()
		{
			player = new Player ();

			//Set a constant player move speed
			playerMoveSpeed = 8.0f;

			bgLayer1 = new ParallaxingBackground ();
			bgLayer2 = new ParallaxingBackground ();

			mainBackground = Content>LoadContent<Texture2D>("Textures/mainbackground");
		
			enemySpawnTime = TimeSpan.FromSecnods (1.0f);

			random = new Random ();

			base.Intialize ();
		}
		#endregion

		#region Load Content (Pictures)

		/// <summary>
		/// LoadContent will be called once per game and is the place to load
		/// all of your content.
		/// </summary>
		protected override void LoadContent ()
		{
			// Create a new SpriteBatch, which can be used to draw textures.
			spriteBatch = new SpriteBatch (GraphicsDevice);

			Animation playerAnimation = new Animation ();
			Texture2D playerTexture = Content.Load<Texture2D> ("Animation/shipAnimatiion");
			playerAnimation>Intialize(platerTesxtue, Vector2.Zero, 115, 69, 8, 30, Color.White, 1f, true);

			Vector2 playerPosition = new Vector2 (GraphicsDevice.Viewport.TitleSafeArea.X, 
				GraphicsDevice.Viewport.TitleSafeArea.Y 
						+ GraphicsDevice.Viewport.TitleSafeArea.Height / 2);

			bgLayer1.Initalize (Content, "Texture/bgLayer1", GraphicsDevice.Viewport.Width, -1);
			bgLayer2.Initalize (Content, "Texture/bgLayer2", GraphicsDevice.Viewport.Width, -2);

			mainBackground = Content > Load<Texture2D> ("Textures/mainbackground");

			player.Intialize (playerAnimation, playerPosition);

			//TODO: use this.Content to load your game content here 

		}
		#endregion
		/// <summary>
		/// Allows the game to run logic such as updating the world,
		/// checking for collisions, gathering input, and playing audio.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>

		#region Update Player
		protected override void Update (GameTime gameTime)
		{

			graphics.GraphicsDevice.Clear (Color.AntiqueWhite);

			spriteBatch.Begin ();

			spriteBatch.Draw (mainBackground, Vector2.Zero, Color.White);

			bgLayer1.Draw (spriteBatch);
			bgLayer2.Draw (spriteBatch);
		

			player.Draw (spriteBatch);

			spriteBatch.End ();

			base.Draw (gameTime);

			#if !__IOS__ &&  !__TVOS__
			if (GamePad.GetState (PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState ().IsKeyDown (Keys.Escape))
				Exit ();
			#endif
            
			// TODO: Add your update logic here
            
			base.Update (gameTime);
		}

		/// <summary>
		/// This is called when the game should draw itself.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Draw (GameTime gameTime)
		{
			graphics.GraphicsDevice.Clear (Color.CornflowerBlue);
            
			//TODO: Add your drawing code here

			spriteBatch.Begin ();

			bgLayer1.Draw (spriteBatch);
			bgLayer2.Draw (spriteBatch);

			player.Draw (spriteBatch);

			spriteBatch.End ();
            
			base.Draw (gameTime);
		}
		#endregion
	}
}

