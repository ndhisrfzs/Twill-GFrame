using GFrame;
using UnityEngine;
using UnityEngine.UI;

public class UINoticePanelComponents : IUIComponents
{
	public void InitUIComponents()
	{
		Close_Button = UIManager.Instance.Get<UINoticePanel>("NoticeDialog/Close").GetComponent<Button>();
	}

	public void Clear()
	{
		Close_Button = null;
	}

	public Button Close_Button;
}
