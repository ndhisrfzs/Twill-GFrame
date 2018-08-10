using GFrame;
using UnityEngine;
using UnityEngine.UI;

public class UISettingPanelComponents : IUIComponents
{
	public void InitUIComponents()
	{
		Close_Button = UIManager.Instance.Get<UISettingPanel>("SetingDialog/Close").GetComponent<Button>();
		MusicToggle_Toggle = UIManager.Instance.Get<UISettingPanel>("SetingDialog/Music/MusicToggle").GetComponent<Toggle>();
		SoundToggle_Toggle = UIManager.Instance.Get<UISettingPanel>("SetingDialog/Sound/SoundToggle").GetComponent<Toggle>();
		Logout_Button = UIManager.Instance.Get<UISettingPanel>("SetingDialog/Logout").GetComponent<Button>();
	}

	public void Clear()
	{
		Close_Button = null;
		MusicToggle_Toggle = null;
		SoundToggle_Toggle = null;
		Logout_Button = null;
	}

	public Button Close_Button;
	public Toggle MusicToggle_Toggle;
	public Toggle SoundToggle_Toggle;
	public Button Logout_Button;
}
