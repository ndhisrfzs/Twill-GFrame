using GFrame;
using UnityEngine;
using UnityEngine.UI;

public class UILoginPanelComponents : IUIComponents
{
	public void InitUIComponents()
	{
		Login_Button = UIManager.Instance.Get<UILoginPanel>("Login").GetComponent<Button>();
	}

	public void Clear()
	{
		Login_Button = null;
	}

	public Button Login_Button;
}
