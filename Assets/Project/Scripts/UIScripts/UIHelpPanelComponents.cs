using GFrame;
using UnityEngine;
using UnityEngine.UI;

public class UIHelpPanelComponents : IUIComponents
{
	public void InitUIComponents()
	{
		Close_Button = UIManager.Instance.Get<UIHelpPanel>("HelpDialog/Close").GetComponent<Button>();
	}

	public void Clear()
	{
		Close_Button = null;
	}

	public Button Close_Button;
}
