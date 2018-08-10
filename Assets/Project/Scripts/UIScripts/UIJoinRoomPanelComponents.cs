using GFrame;
using UnityEngine;
using UnityEngine.UI;

public class UIJoinRoomPanelComponents : IUIComponents
{
	public void InitUIComponents()
	{
		Close_Button = UIManager.Instance.Get<UIJoinRoomPanel>("JoinRoomDialog/Close").GetComponent<Button>();
		One_Button = UIManager.Instance.Get<UIJoinRoomPanel>("JoinRoomDialog/Num/One").GetComponent<Button>();
		Two_Button = UIManager.Instance.Get<UIJoinRoomPanel>("JoinRoomDialog/Num/Two").GetComponent<Button>();
		Three_Button = UIManager.Instance.Get<UIJoinRoomPanel>("JoinRoomDialog/Num/Three").GetComponent<Button>();
		Four_Button = UIManager.Instance.Get<UIJoinRoomPanel>("JoinRoomDialog/Num/Four").GetComponent<Button>();
		Five_Button = UIManager.Instance.Get<UIJoinRoomPanel>("JoinRoomDialog/Num/Five").GetComponent<Button>();
		Six_Button = UIManager.Instance.Get<UIJoinRoomPanel>("JoinRoomDialog/Num/Six").GetComponent<Button>();
		Seven_Button = UIManager.Instance.Get<UIJoinRoomPanel>("JoinRoomDialog/Num/Seven").GetComponent<Button>();
		Eight_Button = UIManager.Instance.Get<UIJoinRoomPanel>("JoinRoomDialog/Num/Eight").GetComponent<Button>();
		Nine_Button = UIManager.Instance.Get<UIJoinRoomPanel>("JoinRoomDialog/Num/Nine").GetComponent<Button>();
		Redo_Button = UIManager.Instance.Get<UIJoinRoomPanel>("JoinRoomDialog/Num/Redo").GetComponent<Button>();
		Zero_Button = UIManager.Instance.Get<UIJoinRoomPanel>("JoinRoomDialog/Num/Zero").GetComponent<Button>();
		Delete_Button = UIManager.Instance.Get<UIJoinRoomPanel>("JoinRoomDialog/Num/Delete").GetComponent<Button>();
		key_0_Text = UIManager.Instance.Get<UIJoinRoomPanel>("JoinRoomDialog/RoomKey/key_0").GetComponent<Text>();
		key_1_Text = UIManager.Instance.Get<UIJoinRoomPanel>("JoinRoomDialog/RoomKey/key_1").GetComponent<Text>();
		key_2_Text = UIManager.Instance.Get<UIJoinRoomPanel>("JoinRoomDialog/RoomKey/key_2").GetComponent<Text>();
		key_3_Text = UIManager.Instance.Get<UIJoinRoomPanel>("JoinRoomDialog/RoomKey/key_3").GetComponent<Text>();
		key_4_Text = UIManager.Instance.Get<UIJoinRoomPanel>("JoinRoomDialog/RoomKey/key_4").GetComponent<Text>();
		key_5_Text = UIManager.Instance.Get<UIJoinRoomPanel>("JoinRoomDialog/RoomKey/key_5").GetComponent<Text>();
		OK_Button = UIManager.Instance.Get<UIJoinRoomPanel>("JoinRoomDialog/OK").GetComponent<Button>();
	}

	public void Clear()
	{
		Close_Button = null;
		One_Button = null;
		Two_Button = null;
		Three_Button = null;
		Four_Button = null;
		Five_Button = null;
		Six_Button = null;
		Seven_Button = null;
		Eight_Button = null;
		Nine_Button = null;
		Redo_Button = null;
		Zero_Button = null;
		Delete_Button = null;
		key_0_Text = null;
		key_1_Text = null;
		key_2_Text = null;
		key_3_Text = null;
		key_4_Text = null;
		key_5_Text = null;
		OK_Button = null;
	}

	public Button Close_Button;
	public Button One_Button;
	public Button Two_Button;
	public Button Three_Button;
	public Button Four_Button;
	public Button Five_Button;
	public Button Six_Button;
	public Button Seven_Button;
	public Button Eight_Button;
	public Button Nine_Button;
	public Button Redo_Button;
	public Button Zero_Button;
	public Button Delete_Button;
	public Text key_0_Text;
	public Text key_1_Text;
	public Text key_2_Text;
	public Text key_3_Text;
	public Text key_4_Text;
	public Text key_5_Text;
	public Button OK_Button;
}
