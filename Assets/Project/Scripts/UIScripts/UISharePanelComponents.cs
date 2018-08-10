using GFrame;
using UnityEngine;
using UnityEngine.UI;

public class UISharePanelComponents : IUIComponents
{
	public void InitUIComponents()
	{
		Close_Button = UIManager.Instance.Get<UISharePanel>("HelpDialog/Close").GetComponent<Button>();
		ShareFriend_Button = UIManager.Instance.Get<UISharePanel>("HelpDialog/ShareFriendBg/ShareFriend").GetComponent<Button>();
		ShareFriendCircle_Button = UIManager.Instance.Get<UISharePanel>("HelpDialog/ShareFriendCircleBg/ShareFriendCircle").GetComponent<Button>();
	}

	public void Clear()
	{
		Close_Button = null;
		ShareFriend_Button = null;
		ShareFriendCircle_Button = null;
	}

	public Button Close_Button;
	public Button ShareFriend_Button;
	public Button ShareFriendCircle_Button;
}
