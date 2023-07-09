using System;

namespace 贪吃蛇
{
    public enum ESnakeBody
    {
        Head,
        Body
    }
    public class SnakeBody: GameObject
    {
        public ESnakeBody type;
        public SnakeBody(ESnakeBody type,int x,int y)
        {
            this.type = type;
            pos = new Position(x, y);
        }
        public override void Draw()
        {
            Console.SetCursorPosition(pos.x,pos.y);
            Console.ForegroundColor = (type==ESnakeBody.Head)?ConsoleColor.Yellow:
                    ConsoleColor.Green;
            Console.Write("●");
        }
    }
}