using System;

namespace 贪吃蛇
{
    public class GameScene:ISenceUpdate
    {
        private Map map;
        private Snake snake;
        private int updateIndex;
        private Food food;
        public GameScene()
        {
            map = new Map();
            snake = new Snake(40, 10);
            food = new Food(snake);
        }
        
        public void Update()
        {
            if (updateIndex % 5000 == 0)
            {
                food.Draw();
                map.Draw();
                snake.Move();
                snake.Draw();
                if (snake.CheckEnd(map))
                {
                    //End Game
                    Game.ChangeScene(E_SceneType.End);
                }
                snake.CheckEatFood(food);
                
                
                
                
            }

            ++updateIndex;

            //检测键盘激活的时候执行转向
            if (Console.KeyAvailable)
            {
                switch (Console.ReadKey(true).Key)
                {
                    case  ConsoleKey.W:
                        snake.ChangeDir(EMoveDir.Up);
                        break;
                    case  ConsoleKey.A:
                        snake.ChangeDir(EMoveDir.Left);
                        break;
                    case  ConsoleKey.S:
                        snake.ChangeDir(EMoveDir.Down);
                        break;
                    case  ConsoleKey.D:
                        snake.ChangeDir(EMoveDir.Right);
                        break;
                }
            }
        }
    }
}