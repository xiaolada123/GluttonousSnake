using System;
using System.Threading;

namespace 贪吃蛇
{
    public class BeginScene: BaseChooseScene
    {
        public BeginScene()
        {
            strTitle = "贪吃蛇";
            strOne = "开始游戏";
        }
        
        public override void EnterJ()
        {
            if (nowSelIndex == 0)
            {
                Game.ChangeScene(E_SceneType.Game);
            }
            else
            {
                Environment.Exit(0);
            }
            
        }
    }
}