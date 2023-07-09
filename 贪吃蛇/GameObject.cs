﻿using System;

namespace 贪吃蛇
{
   public struct Position
    {
        public int x;
        public int y;

        public Position(int x, int y)
        {
            this.x = x;
            this.y = y;
        } 

        public static bool operator ==(Position p1, Position p2)
        {
            if (p1.x == p2.x && p1.y == p2.y)
            {
                return true;
            }

            return false;
        }

        public static bool operator !=(Position p1, Position p2)
        {
            return !(p1 == p2);
        }
    }
    
    public abstract class GameObject:IDraw
    {
        public Position pos;

        public abstract void Draw();
    }
}