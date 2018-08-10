namespace GFrame
{
    public enum Scene
    {
        Login,
        Main,
        Setting,
        GameLog,
        Notice,
        Help,
        Share,
        CreateRoom,
        JoinRoom,
        Room,
        Loading,
    }
    public class SceneManager : Singleton<SceneManager>
    {
        private SceneManager()
        {
            UIManager.Instance.SetResolution(1920, 1080);
            UIManager.Instance.SetMatchOnWidthOrHeight();
        }

        public void OpenScene(Scene scene)
        {
            switch (scene)
            {
                case Scene.Login:
                    {
                        UIManager.Instance.HideAll();
                        UILevel.Bg.OpenUI<UILoginBg>();
                        UILevel.Common.OpenUI<UILoginPanel>();
                        UILevel.Toast.OpenUI<UIMessagePanel>();
                    }
                    break;
                case Scene.Main:
                    {
                        UIManager.Instance.HideAll();
                        UILevel.Bg.OpenUI<UIMainBg>();
                        UILevel.Common.OpenUI<UIMainPanel>();
                    }
                    break;
                case Scene.Setting:
                    {
                        UILevel.PopUI.OpenUI<UISettingPanel>();
                    }
                    break;
                case Scene.GameLog:
                    {
                        UILevel.PopUI.OpenUI<UIGameLogPanel>();
                    }
                    break;
                case Scene.Notice:
                    {
                        UILevel.PopUI.OpenUI<UINoticePanel>();
                    }
                    break;
                case Scene.Help:
                    {
                        UILevel.PopUI.OpenUI<UIHelpPanel>();
                    }
                    break;
                case Scene.Share:
                    {
                        UILevel.PopUI.OpenUI<UISharePanel>();
                    }
                    break;
                case Scene.CreateRoom:
                    {
                        UILevel.PopUI.OpenUI<UICreateRoomPanel>();
                    }
                    break;
                case Scene.JoinRoom:
                    {
                        UILevel.PopUI.OpenUI<UIJoinRoomPanel>();
                    }
                    break;
                case Scene.Room:
                    {
                        UIManager.Instance.HideAll();
                        UILevel.Bg.OpenUI<UIRoomBg>();
                        UILevel.Common.OpenUI<UIRoomPanel>();
                    }
                    break;
                case Scene.Loading:
                    {
                        UIManager.Instance.HideAll();
                        UILevel.Common.OpenUI<UILoadingPanel>();
                    }
                    break;
            }
        }
    }
}
