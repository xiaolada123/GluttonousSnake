using System;

namespace 贪吃蛇
{
    public class EndScene: BaseChooseScene
    {
        public EndScene()
        {
            strTitle = "游戏结束";
            strOne = "回到标题界面";
        }
        public override void EnterJ()
        {
            if (nowSelIndex == 0)
            {
                Game.ChangeScene(E_SceneType.Bgein);
            }
            else
            {
                Environment.Exit(0);
            }
        }
    }
}