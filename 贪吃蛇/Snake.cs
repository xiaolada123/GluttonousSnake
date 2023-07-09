using System;
using System.Security.Policy;

namespace 贪吃蛇
{
   public enum EMoveDir
    {
        Up,
        Down,
        Left,
        Right
    }
    
    public class Snake: IDraw
    {
        SnakeBody[] bodys;

        private int nowNum = 0;

        public EMoveDir dir;
        
        public Snake(int x, int y)
        {
            bodys = new SnakeBody[200];
            bodys[0] = new SnakeBody(ESnakeBody.Head, x, y);
            nowNum = 1;
            dir = EMoveDir.Left;
        }
        
        public void Draw()
        {
            for (int i = 0; i < nowNum; i++)
            {
                bodys[i].Draw();
            }

        }

        public void Move()
        {
            SnakeBody lastBody = bodys[nowNum - 1];
            Console.SetCursorPosition(lastBody.pos.x,lastBody.pos.y);
            Console.Write("  ");
            
            for (int i =nowNum-1  ; i >=1; i--)
            {
                bodys[i].pos = bodys[i - 1].pos;
            }
            
            switch (dir)
            {
                case EMoveDir.Up:
                    --bodys[0].pos.y;
                    break;
                case EMoveDir.Down:
                    ++bodys[0].pos.y;
                    break;
                case EMoveDir.Left:
                    bodys[0].pos.x-=2;
                    break;
                case EMoveDir.Right:
                    bodys[0].pos.x+=2;
                    break;
                default:
                    break;
            }

            
        }

        public void ChangeDir(EMoveDir dir)
        {
            if (dir == this.dir || 
                (nowNum>1&&(this.dir==EMoveDir.Up && dir==EMoveDir.Down)||
                    (this.dir==EMoveDir.Down && dir==EMoveDir.Up)||
                    (this.dir==EMoveDir.Left && dir==EMoveDir.Right)||
                    (this.dir==EMoveDir.Right && dir==EMoveDir.Left)
                    ))
            {
                return;
            }

            this.dir = dir;
        }

        public bool CheckEnd(Map map)
        {
            for (int i = 0; i < map.walls.Length; i++)
            {
                if (bodys[0].pos == map.walls[i].pos)
                {
                    return true;
                }
            }

            for (int i = 1; i < nowNum; i++)
            {
                if (bodys[0].pos == bodys[i].pos)
                {
                    return true;
                }
            }
            return false;
        }
        //判断传入的位置是否重合
        public bool CheckSamePos(Position p)
        {
            for (int i = 0; i < nowNum; i++)
            {
                if (p == bodys[i].pos)
                {
                    return true;
                }
            }

            return false;
        }

        public void CheckEatFood(Food food)
        {
            if (bodys[0].pos == food.pos)
            {
                food.RandomPos(this);
                GrowUp();
            }

        }

        public void GrowUp()
        {
            SnakeBody lastBody = bodys[nowNum-1];
            bodys[nowNum] = new SnakeBody(ESnakeBody.Body, lastBody.pos.x, lastBody.pos.y);
            ++nowNum;
        }
    }
}