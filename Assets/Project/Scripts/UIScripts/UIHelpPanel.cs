using GFrame;

public class UIHelpPanel : UIBehaviour
{
	protected override void InitUI()
	{
		mUIComponents = m_IComponents as UIHelpPanelComponents;
	}

	protected override void RegisterUIEvent()
	{
        mUIComponents.Close_Button.onClick.AddListener(() => {
            this.Hide();
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
		UnityEngine.Debug.Log("[UIHelpPanel:]" + content);
	}

	UIHelpPanelComponents mUIComponents = null;
}
