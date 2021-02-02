﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace GameProject1
{
    public struct BoundingCircle
    {
        public float X;
        public float Y;
        public float Radius;
    }

    public struct BoundingRectangle
    {
        public float X;
        public float Y;
        public float Width;
        public float Height;
    }

    public struct BoundingPoint
    {
        public float X;
        public float Y;

        /// <summary>
        /// Constructs a BoundingPoint with the provided coordinates
        /// </summary>
        /// <param name="x">The x coordinate</param>
        /// <param name="y">The y coordinate</param>
        public BoundingPoint(float x, float y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// Determines if this BoundingPoint collides with another BoundingPoint
        /// </summary>
        /// <param name="o">the other bounding point</param>
        /// <returns>true on collision, false otherwise</returns>
        public bool CollidesWith(BoundingPoint o)
        {
            return CollisionHelper.Collides(o, this);
        }

        /// <summary>
        /// Determines if this BoundingPoint collides with a BoundingCircle
        /// </summary>
        /// <param name="c">the BoundingCircle</param>
        /// <returns>true on collision, false otherwise</returns>
        public bool CollidesWith(BoundingCircle c)
        {
            return CollisionHelper.Collides(c, this);
        }

        /// <summary>
        /// Determines if this BoundingPoint collides with a BoundingCircle
        /// </summary>
        /// <param name="r">the BoundingRectangle</param>
        /// <returns>true on collision, false otherwise</returns>
        public bool CollidesWith(BoundingRectangle r)
        {
            return CollisionHelper.Collides(r, this);
        }
    }

    public static class CollisionHelper
    {
        /// <summary>
        /// Detects a collision between two points
        /// </summary>
        /// <param name="p1">the first point</param>
        /// <param name="p2">the second point</param>
        /// <returns>true when colliding, false otherwise</returns>
        public static bool Collides(BoundingPoint p1, BoundingPoint p2)
        {
            return p1.X == p2.X && p1.Y == p2.Y;
        }

        /// <summary>
        /// Detects a collision between two circles
        /// </summary>
        /// <param name="c1">the first circle</param>
        /// <param name="c2">the second circle</param>
        /// <returns>true for a collision, false otherwise</returns>
        public static bool Collides(BoundingCircle c1, BoundingCircle c2)
        {
            return Math.Pow(c1.Radius + c2.Radius, 2) >= Math.Pow(c2.X - c1.X, 2) + Math.Pow(c2.Y - c1.Y, 2);
        }

        /// <summary>
        /// Detects a collision between two rectangles
        /// </summary>
        /// <param name="r1">The first rectangle</param>
        /// <param name="r2">The second rectangle</param>
        /// <returns>true on collision, false otherwise</returns>
        public static bool Collides(BoundingRectangle r1, BoundingRectangle r2)
        {
            return !(r1.X + r1.Width < r2.X    // r1 is to the left of r2
                    || r1.X > r2.X + r2.Width     // r1 is to the right of r2
                    || r1.Y + r1.Height < r2.Y    // r1 is above r2 
                    || r1.Y > r2.Y + r2.Height); // r1 is below r2
        }

        /// <summary>
        /// Detects a collision between a circle and point
        /// </summary>
        /// <param name="c">the circle</param>
        /// <param name="p">the point</param>
        /// <returns>true on collision, false otherwise</returns>
        public static bool Collides(BoundingCircle c, BoundingPoint p)
        {
            return Math.Pow(c.Radius, 2) >= Math.Pow(c.X - p.X, 2) + Math.Pow(c.Y - p.Y, 2);
        }

        /// <summary>
        /// Detects a collision between a rectangle and a point
        /// </summary>
        /// <param name="r">The rectangle</param>
        /// <param name="p">The point</param>
        /// <returns>true on collision, false otherwise</returns>
        public static bool Collides(BoundingRectangle r, BoundingPoint p)
        {
            return p.X >= r.X && p.X <= r.X + r.Width && p.Y >= r.Y && p.X <= r.Y + r.Width;
        }

        /// <summary>
        /// Determines if there is a collision between a circle and rectangle
        /// </summary>
        /// <param name="r">The bounding rectangle</param>
        /// <param name="c">The bounding circle</param>
        /// <returns>true for collision, false otherwise</returns>
        public static bool Collides(BoundingRectangle r, BoundingCircle c)
        {
            BoundingPoint p;
            p.X = MathHelper.Clamp(c.X, r.X, r.X + r.Width);
            p.Y = MathHelper.Clamp(c.Y, r.Y, r.Y + r.Height);
            return Collides(c, p);
        }
    }
}
