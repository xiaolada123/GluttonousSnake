using System;

namespace 贪吃蛇
{
    
    public abstract class BaseChooseScene: ISenceUpdate
    {
        protected int nowSelIndex = 0;
        protected string strTitle;
        protected string strOne;
        
        public abstract void EnterJ();
        public void Update()
        {
            Console.ForegroundColor = ConsoleColor.White;
            //显示标题
            Console.SetCursorPosition(Game.w/2-strTitle.Length,5);
            Console.Write(strTitle);
            //显示选项1
            Console.SetCursorPosition(Game.w/2-strOne.Length,8);
            Console.ForegroundColor = (nowSelIndex == 0) ? ConsoleColor.Red : ConsoleColor.White;
            Console.Write(strOne);
            //显示选项2
            Console.SetCursorPosition(Game.w/2-4,11);
            Console.ForegroundColor = (nowSelIndex == 1) ? ConsoleColor.Red : ConsoleColor.White;
            Console.Write("退出游戏");

            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.W:
                    --nowSelIndex;
                    if (nowSelIndex < 0)
                    {
                        nowSelIndex = 0;
                    }
                    break;
                case ConsoleKey.S:
                    ++nowSelIndex;
                    if (nowSelIndex>1)
                    {
                        nowSelIndex = 1;
                    }
                    break;
                case ConsoleKey.J:
                    //重写
                    EnterJ();
                    break;
            }
        }
    }
}