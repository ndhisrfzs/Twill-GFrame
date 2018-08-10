using GFrame;

public class UIRoomBg : UIBehaviour
{
	protected override void InitUI()
	{
		mUIComponents = m_IComponents as UIRoomBgComponents;
	}

	protected override void RegisterUIEvent()
	{
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
		UnityEngine.Debug.Log("[UIRoomBg:]" + content);
	}

	UIRoomBgComponents mUIComponents = null;
}
