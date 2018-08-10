using GFrame;

public class UIMainPanel : UIBehaviour
{
	protected override void InitUI()
	{
		mUIComponents = m_IComponents as UIMainPanelComponents;

        mUIComponents.Name_Text.text = UserData.Instance.user.name;
        mUIComponents.UID_Text.text = UserData.Instance.user.uid.ToString();
        mUIComponents.Gold_Text.text = UserData.Instance.user.gold.ToString();
    }

    protected override void RegisterUIEvent()
    {
        mUIComponents.Settings_Button.onClick.AddListener(() =>
        {
            SceneManager.Instance.OpenScene(Scene.Setting);
        });

        mUIComponents.GameLog_Button.onClick.AddListener(() =>
        {
            SceneManager.Instance.OpenScene(Scene.GameLog);
        });

        mUIComponents.Notice_Button.onClick.AddListener(() =>
        {
            SceneManager.Instance.OpenScene(Scene.Notice);
        });

        mUIComponents.Help_Button.onClick.AddListener(() =>
        {
            SceneManager.Instance.OpenScene(Scene.Help);
        });

        mUIComponents.Share_Button.onClick.AddListener(() => {
            SceneManager.Instance.OpenScene(Scene.Share);
        });

        mUIComponents.CreateRoom_Button.onClick.AddListener(() => {
            SceneManager.Instance.OpenScene(Scene.CreateRoom);
        });

        mUIComponents.EnterRoom_Button.onClick.AddListener(() => {
            SceneManager.Instance.OpenScene(Scene.JoinRoom);
        });
    } 

	protected override void OnShow()
	{
		base.OnShow();
	}

	protected override void OnHide()
	{
		base.OnHide();
	}

	protected override void OnClose()
	{
		base.OnClose();
	}

	protected override void DestoryUI()
	{
		base.DestoryUI();
	}

	void ShowLog(string content)
	{
		UnityEngine.Debug.Log("[UIMainPanel:]" + content);
	}

	UIMainPanelComponents mUIComponents = null;
}
