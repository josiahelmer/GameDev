using System;
using Microsoft.Xna.Framework
using Microsoft.Xna.Framework.Graphics;
using AfternoonGame.View;

namespace GameDev.Model
{
	public class Player
	{
		private int score;
		private bool active;
		private int health;
		private Animation playerAnimation;

		// Animation representing the player
		public Animation PlayerAnimation
		{
			get { return PlayerAnimation; }
			set { playerAnimation = value; }
		}
		//Animation representing the player
		public Texture2D PlayerTexture;

		//Postion of the Player relative to the upper left side of the screen
		public Vector2 Position;

		//State of the player
		public bool Active
		{
			get { return active; }
			set { active = value;

		}
		public int Score
		{
			get { return score; }
			set { score = value; }
		}

		public Player ()
		{
		}
	}
}

