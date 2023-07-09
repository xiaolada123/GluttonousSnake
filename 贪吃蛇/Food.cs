using System;

namespace 贪吃蛇
{
   
    
    public class Food: GameObject
    {
        
        
        public Food(Snake snake)
        {
            RandomPos(snake);
        }
        
        public override void Draw()
        {
            Console.SetCursorPosition(pos.x,pos.y);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("●");
        }
        
        //随机位置行为
        public void RandomPos(Snake snake)
        {
            Random r = new Random();
            int x = r.Next(2, Game.w / 2 - 1) * 2;
            int y = r.Next(1, Game.h - 3);
            pos = new Position(x, y);
            //如果跟蛇的位置重合
            if (snake.CheckSamePos(pos))
            {
                RandomPos(snake);
            }
        }
    }
}