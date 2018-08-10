using GFrame;
using UnityEngine;
using UnityEngine.UI;

public class UIGameLogPanelComponents : IUIComponents
{
	public void InitUIComponents()
	{
		Close_Button = UIManager.Instance.Get<UIGameLogPanel>("GameLogDialog/Close").GetComponent<Button>();
		ItemGrid_Transform = UIManager.Instance.Get<UIGameLogPanel>("GameLogDialog/ScrollView/Viewport/ItemGrid").GetComponent<Transform>();
		OK_Button = UIManager.Instance.Get<UIGameLogPanel>("GameLogDialog/OK").GetComponent<Button>();
	}

	public void Clear()
	{
		Close_Button = null;
		ItemGrid_Transform = null;
		OK_Button = null;
	}

	public Button Close_Button;
	public Transform ItemGrid_Transform;
	public Button OK_Button;
}
