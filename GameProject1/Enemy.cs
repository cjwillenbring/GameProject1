﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace GameProject1
{
    public class Enemy
    {
        /// <summary>
        /// Holds the viewportWidth of the screen
        /// </summary>
        private static int viewportWidth;

        /// <summary>
        /// Stores the location of the enemy object on the sprite atlas
        /// </summary>
        private static Rectangle atlas_location = new Rectangle(19*16, 9*16, 16, 16);

        /// <summary>
        /// Sores the random generator for the enemy class
        /// </summary>
        private static Random rand = new Random();

        public Vector2 Position { get => position; }
        ///<summary>
        /// The enemy's position in the world
        ///</summary>
        private Vector2 position;

        /// <summary>
        /// The enemy's scale for when it gets rendered
        /// </summary>
        private Vector2 scalar;

        /// <summary>
        /// The speed of the enemy falling
        /// </summary>
        private int speed;
        
        public Enemy()
        {
            position = new Vector2((float)rand.NextDouble() * viewportWidth, 0);
            speed = rand.Next(30, 150);
            float rand_scale = (float)rand.NextDouble()*5;
            if(rand_scale > .5)
            {
                scalar = new Vector2(rand_scale, rand_scale);
            }
            else
            {
                scalar = new Vector2(1, 1);
            }
        }

        public static void RegisterViewportWidth(int w)
        {
            viewportWidth = w;
        }

        public void Update(GameTime gameTime)
        {
            position += new Vector2(0, 1) * speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch, Texture2D atlas)
        {
            spriteBatch.Draw(atlas, position, atlas_location, Color.White, 0, new Vector2(0,0), scalar, SpriteEffects.None, 0);
        }
    }
}
