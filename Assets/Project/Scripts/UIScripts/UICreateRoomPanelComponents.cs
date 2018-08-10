using GFrame;
using UnityEngine;
using UnityEngine.UI;

public class UICreateRoomPanelComponents : IUIComponents
{
	public void InitUIComponents()
	{
		Close_Button = UIManager.Instance.Get<UICreateRoomPanel>("CreateRoomDialog/Close").GetComponent<Button>();
		Classical_Toggle = UIManager.Instance.Get<UICreateRoomPanel>("CreateRoomDialog/Game/Classical").GetComponent<Toggle>();
		Metallic_Toggle = UIManager.Instance.Get<UICreateRoomPanel>("CreateRoomDialog/Game/Metallic").GetComponent<Toggle>();
		Friend_Toggle = UIManager.Instance.Get<UICreateRoomPanel>("CreateRoomDialog/GameType/Friend").GetComponent<Toggle>();
		RandomPlayer_Toggle = UIManager.Instance.Get<UICreateRoomPanel>("CreateRoomDialog/GameType/RandomPlayer").GetComponent<Toggle>();
		BombScore_Toggle = UIManager.Instance.Get<UICreateRoomPanel>("CreateRoomDialog/GameModel/BombScore").GetComponent<Toggle>();
		BombDouble_Toggle = UIManager.Instance.Get<UICreateRoomPanel>("CreateRoomDialog/GameModel/BombDouble").GetComponent<Toggle>();
		ChangePartner_Toggle = UIManager.Instance.Get<UICreateRoomPanel>("CreateRoomDialog/GameModel/ChangePartner").GetComponent<Toggle>();
		Cancel_Button = UIManager.Instance.Get<UICreateRoomPanel>("CreateRoomDialog/Cancel").GetComponent<Button>();
		OK_Button = UIManager.Instance.Get<UICreateRoomPanel>("CreateRoomDialog/OK").GetComponent<Button>();
	}

	public void Clear()
	{
		Close_Button = null;
		Classical_Toggle = null;
		Metallic_Toggle = null;
		Friend_Toggle = null;
		RandomPlayer_Toggle = null;
		BombScore_Toggle = null;
		BombDouble_Toggle = null;
		ChangePartner_Toggle = null;
		Cancel_Button = null;
		OK_Button = null;
	}

	public Button Close_Button;
	public Toggle Classical_Toggle;
	public Toggle Metallic_Toggle;
	public Toggle Friend_Toggle;
	public Toggle RandomPlayer_Toggle;
	public Toggle BombScore_Toggle;
	public Toggle BombDouble_Toggle;
	public Toggle ChangePartner_Toggle;
	public Button Cancel_Button;
	public Button OK_Button;
}
