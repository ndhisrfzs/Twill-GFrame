using GFrame;
using UnityEngine;
using UnityEngine.UI;

public class UIMessagePanelComponents : IUIComponents
{
	public void InitUIComponents()
	{
		Message_Image = UIManager.Instance.Get<UIMessagePanel>("Message").GetComponent<Image>();
		Info_Text = UIManager.Instance.Get<UIMessagePanel>("Message/Info").GetComponent<Text>();
	}

	public void Clear()
	{
		Message_Image = null;
		Info_Text = null;
	}

	public Image Message_Image;
	public Text Info_Text;
}
