using GFrame;
using UnityEngine;
using UnityEngine.UI;

public class UIMainPanelComponents : IUIComponents
{
	public void InitUIComponents()
	{
		AvatarImage_Image = UIManager.Instance.Get<UIMainPanel>("Avatar/AvatarMask/AvatarImage").GetComponent<Image>();
		Name_Text = UIManager.Instance.Get<UIMainPanel>("Name").GetComponent<Text>();
		UID_Text = UIManager.Instance.Get<UIMainPanel>("UID").GetComponent<Text>();
		Shop_Button = UIManager.Instance.Get<UIMainPanel>("Diamond/Shop").GetComponent<Button>();
		Gold_Text = UIManager.Instance.Get<UIMainPanel>("Diamond/Gold").GetComponent<Text>();
		Settings_Button = UIManager.Instance.Get<UIMainPanel>("Settings").GetComponent<Button>();
		CreateRoom_Button = UIManager.Instance.Get<UIMainPanel>("CreateRoom").GetComponent<Button>();
		EnterRoom_Button = UIManager.Instance.Get<UIMainPanel>("EnterRoom").GetComponent<Button>();
		GameLog_Button = UIManager.Instance.Get<UIMainPanel>("BottomBar/Image/GameLog").GetComponent<Button>();
		Notice_Button = UIManager.Instance.Get<UIMainPanel>("BottomBar/Image (1)/Notice").GetComponent<Button>();
		Help_Button = UIManager.Instance.Get<UIMainPanel>("BottomBar/Image (2)/Help").GetComponent<Button>();
		Share_Button = UIManager.Instance.Get<UIMainPanel>("BottomBar/Image (3)/Share").GetComponent<Button>();
	}

	public void Clear()
	{
		AvatarImage_Image = null;
		Name_Text = null;
		UID_Text = null;
		Shop_Button = null;
		Gold_Text = null;
		Settings_Button = null;
		CreateRoom_Button = null;
		EnterRoom_Button = null;
		GameLog_Button = null;
		Notice_Button = null;
		Help_Button = null;
		Share_Button = null;
	}

	public Image AvatarImage_Image;
	public Text Name_Text;
	public Text UID_Text;
	public Button Shop_Button;
	public Text Gold_Text;
	public Button Settings_Button;
	public Button CreateRoom_Button;
	public Button EnterRoom_Button;
	public Button GameLog_Button;
	public Button Notice_Button;
	public Button Help_Button;
	public Button Share_Button;
}
