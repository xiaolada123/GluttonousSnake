using System;

namespace 贪吃蛇
{
    public enum E_SceneType
    {
        Bgein,
        Game,
        End,
    }
    /// <summary>
    /// 游戏管理类
    /// </summary>
    public class Game
    {
        public const int w = 80;
        public const int h = 20;

        public static ISenceUpdate nowScene;

        public Game()
        {
            Console.CursorVisible = false;
            Console.SetWindowSize(w,h);
            Console.SetBufferSize(w,h);
            
            ChangeScene(E_SceneType.Bgein);
        }

        public void Start()
        {
            while (true)
            {
                if (nowScene != null)
                {
                    nowScene.Update();
                }
            }
        }

        public static void ChangeScene(E_SceneType type)
        {
            //切换场景前擦除之前内容
            Console.Clear();
            switch (type)
            {
                case E_SceneType.Bgein:
                    nowScene = new BeginScene();
                    break;
                case E_SceneType.Game:
                    nowScene = new GameScene();
                    break;
                case E_SceneType.End:
                    nowScene = new EndScene();
                    break;
                default:
                    break;
            }
        }
    }
    
    
}