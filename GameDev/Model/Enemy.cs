using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace GameDev
{
	public class Enemy
	{
		private Animation enemyAnimation;
		// Animation representing the enemy
		public Animation EnemyAnimation 
		{
			get { return enemyAnimation; }
			set { enemyAnimation = value; }
		}

		private Vector2 position;
		// The positon of the enemy shi[ relative to the top left corner of thescreen
		public Vector2 position 
		{
			get { return position; }
			set { enemyAnimation = value; }
		}
		//The state of the Enemy Ship
		public bool Active;
		{
			get { return active; }
			set { active = value; }
		}

		private int health;
		// The hit points of the enemy. if this goes to zero the enemy dies
		public int Health;

		//The amount of dameage the enemy inflicts on the player ship
		public int Damage;

		public Enemy ()
		{
		}
	}
}

