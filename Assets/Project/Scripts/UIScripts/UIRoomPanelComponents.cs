﻿using GFrame;
using UnityEngine;
using UnityEngine.UI;

public class UIRoomPanelComponents : IUIComponents
{
	public void InitUIComponents()
	{
		Time_Text = UIManager.Instance.Get<UIRoomPanel>("GameInfo/Time").GetComponent<Text>();
		RoomKey_Text = UIManager.Instance.Get<UIRoomPanel>("GameInfo/RoomKey/RoomKey").GetComponent<Text>();
		Game_Text = UIManager.Instance.Get<UIRoomPanel>("GameInfo/Game/Game").GetComponent<Text>();
		GameType_Text = UIManager.Instance.Get<UIRoomPanel>("GameInfo/GameType/GameType").GetComponent<Text>();
		GameModel_Text = UIManager.Instance.Get<UIRoomPanel>("GameInfo/GameModel/GameModel").GetComponent<Text>();
		P1AvatarImage_Image = UIManager.Instance.Get<UIRoomPanel>("P1Info/Avatar/AvatarMask/P1AvatarImage").GetComponent<Image>();
		P1Name_Text = UIManager.Instance.Get<UIRoomPanel>("P1Info/P1Name").GetComponent<Text>();
		P1Score_Text = UIManager.Instance.Get<UIRoomPanel>("P1Info/P1Score").GetComponent<Text>();
		P1Light_Image = UIManager.Instance.Get<UIRoomPanel>("P1Info/P1Light").GetComponent<Image>();
		P1Time_Text = UIManager.Instance.Get<UIRoomPanel>("P1Info/P1Light/Timer/P1Time").GetComponent<Text>();
		HandCardGrid_Transform = UIManager.Instance.Get<UIRoomPanel>("P1Info/HandCardGrid").GetComponent<Transform>();
		P1Ready_Image = UIManager.Instance.Get<UIRoomPanel>("P1Info/P1Ready").GetComponent<Image>();
		P2Info_Image = UIManager.Instance.Get<UIRoomPanel>("P2Info").GetComponent<Image>();
		P2AvatarImage_Image = UIManager.Instance.Get<UIRoomPanel>("P2Info/Avatar/AvatarMask/P2AvatarImage").GetComponent<Image>();
		P2Name_Text = UIManager.Instance.Get<UIRoomPanel>("P2Info/P2Name").GetComponent<Text>();
		P2Score_Text = UIManager.Instance.Get<UIRoomPanel>("P2Info/P2Score").GetComponent<Text>();
		P2Light_Image = UIManager.Instance.Get<UIRoomPanel>("P2Info/P2Light").GetComponent<Image>();
		P2Time_Text = UIManager.Instance.Get<UIRoomPanel>("P2Info/P2Light/Timer/P2Time").GetComponent<Text>();
		P2HandCard_Image = UIManager.Instance.Get<UIRoomPanel>("P2Info/P2HandCard").GetComponent<Image>();
		P2CardNum_Text = UIManager.Instance.Get<UIRoomPanel>("P2Info/P2HandCard/P2CardNum").GetComponent<Text>();
		P2Ready_Image = UIManager.Instance.Get<UIRoomPanel>("P2Info/P2Ready").GetComponent<Image>();
		P3Info_Image = UIManager.Instance.Get<UIRoomPanel>("P3Info").GetComponent<Image>();
		P3AvatarImage_Image = UIManager.Instance.Get<UIRoomPanel>("P3Info/Avatar/AvatarMask/P3AvatarImage").GetComponent<Image>();
		P3Name_Text = UIManager.Instance.Get<UIRoomPanel>("P3Info/P3Name").GetComponent<Text>();
		P3Score_Text = UIManager.Instance.Get<UIRoomPanel>("P3Info/P3Score").GetComponent<Text>();
		P3Light_Image = UIManager.Instance.Get<UIRoomPanel>("P3Info/P3Light").GetComponent<Image>();
		P3Time_Text = UIManager.Instance.Get<UIRoomPanel>("P3Info/P3Light/Timer/P3Time").GetComponent<Text>();
		P3HandCard_Image = UIManager.Instance.Get<UIRoomPanel>("P3Info/P3HandCard").GetComponent<Image>();
		P3CardNum_Text = UIManager.Instance.Get<UIRoomPanel>("P3Info/P3HandCard/P3CardNum").GetComponent<Text>();
		P3Ready_Image = UIManager.Instance.Get<UIRoomPanel>("P3Info/P3Ready").GetComponent<Image>();
		P4Info_Image = UIManager.Instance.Get<UIRoomPanel>("P4Info").GetComponent<Image>();
		P4AvatarImage_Image = UIManager.Instance.Get<UIRoomPanel>("P4Info/Avatar/AvatarMask/P4AvatarImage").GetComponent<Image>();
		P4Name_Text = UIManager.Instance.Get<UIRoomPanel>("P4Info/P4Name").GetComponent<Text>();
		P4Score_Text = UIManager.Instance.Get<UIRoomPanel>("P4Info/P4Score").GetComponent<Text>();
		P4Light_Image = UIManager.Instance.Get<UIRoomPanel>("P4Info/P4Light").GetComponent<Image>();
		P4Time_Text = UIManager.Instance.Get<UIRoomPanel>("P4Info/P4Light/Timer/P4Time").GetComponent<Text>();
		P4HandCard_Image = UIManager.Instance.Get<UIRoomPanel>("P4Info/P4HandCard").GetComponent<Image>();
		P4CardNum_Text = UIManager.Instance.Get<UIRoomPanel>("P4Info/P4HandCard/P4CardNum").GetComponent<Text>();
		P4Ready_Image = UIManager.Instance.Get<UIRoomPanel>("P4Info/P4Ready").GetComponent<Image>();
		ButtonBar_Transform = UIManager.Instance.Get<UIRoomPanel>("ButtonBar").GetComponent<Transform>();
		Abandon_Button = UIManager.Instance.Get<UIRoomPanel>("ButtonBar/Abandon").GetComponent<Button>();
		Prompt_Button = UIManager.Instance.Get<UIRoomPanel>("ButtonBar/Prompt").GetComponent<Button>();
		Discard_Button = UIManager.Instance.Get<UIRoomPanel>("ButtonBar/Discard").GetComponent<Button>();
		P1Table_Transform = UIManager.Instance.Get<UIRoomPanel>("Table/P1Table").GetComponent<Transform>();
		P2Table_Transform = UIManager.Instance.Get<UIRoomPanel>("Table/P2Table").GetComponent<Transform>();
		P3Table_Transform = UIManager.Instance.Get<UIRoomPanel>("Table/P3Table").GetComponent<Transform>();
		P4Table_Transform = UIManager.Instance.Get<UIRoomPanel>("Table/P4Table").GetComponent<Transform>();
		Ready_Button = UIManager.Instance.Get<UIRoomPanel>("Ready").GetComponent<Button>();
		Message_Image = UIManager.Instance.Get<UIRoomPanel>("Message").GetComponent<Image>();
		Info_Text = UIManager.Instance.Get<UIRoomPanel>("Message/Info").GetComponent<Text>();
		Result_Image = UIManager.Instance.Get<UIRoomPanel>("Result").GetComponent<Image>();
		P1RAvatar_Image = UIManager.Instance.Get<UIRoomPanel>("Result/P1Result/Avatar/AvatarMask/P1RAvatar").GetComponent<Image>();
		P1RName_Text = UIManager.Instance.Get<UIRoomPanel>("Result/P1Result/P1RName").GetComponent<Text>();
		P1RId_Text = UIManager.Instance.Get<UIRoomPanel>("Result/P1Result/P1RId").GetComponent<Text>();
		P1BombGrid_Transform = UIManager.Instance.Get<UIRoomPanel>("Result/P1Result/Image/ScrollView/Viewport/P1BombGrid").GetComponent<Transform>();
		P1RScore_Text = UIManager.Instance.Get<UIRoomPanel>("Result/P1Result/P1RScore").GetComponent<Text>();
		P2RAvatar_Image = UIManager.Instance.Get<UIRoomPanel>("Result/P2Result/Avatar/AvatarMask/P2RAvatar").GetComponent<Image>();
		P2RName_Text = UIManager.Instance.Get<UIRoomPanel>("Result/P2Result/P2RName").GetComponent<Text>();
		P2RId_Text = UIManager.Instance.Get<UIRoomPanel>("Result/P2Result/P2RId").GetComponent<Text>();
		P2BombGrid_Transform = UIManager.Instance.Get<UIRoomPanel>("Result/P2Result/Image/ScrollView/Viewport/P2BombGrid").GetComponent<Transform>();
		P2RScore_Text = UIManager.Instance.Get<UIRoomPanel>("Result/P2Result/P2RScore").GetComponent<Text>();
		P3RAvatar_Image = UIManager.Instance.Get<UIRoomPanel>("Result/P3Result/Avatar/AvatarMask/P3RAvatar").GetComponent<Image>();
		P3RName_Text = UIManager.Instance.Get<UIRoomPanel>("Result/P3Result/P3RName").GetComponent<Text>();
		P3RId_Text = UIManager.Instance.Get<UIRoomPanel>("Result/P3Result/P3RId").GetComponent<Text>();
		P3BombGrid_Transform = UIManager.Instance.Get<UIRoomPanel>("Result/P3Result/Image/ScrollView/Viewport/P3BombGrid").GetComponent<Transform>();
		P3RScore_Text = UIManager.Instance.Get<UIRoomPanel>("Result/P3Result/P3RScore").GetComponent<Text>();
		P4RAvatar_Image = UIManager.Instance.Get<UIRoomPanel>("Result/P4Result/Avatar/AvatarMask/P4RAvatar").GetComponent<Image>();
		P4RName_Text = UIManager.Instance.Get<UIRoomPanel>("Result/P4Result/P4RName").GetComponent<Text>();
		P4RId_Text = UIManager.Instance.Get<UIRoomPanel>("Result/P4Result/P4RId").GetComponent<Text>();
		P4BombGrid_Transform = UIManager.Instance.Get<UIRoomPanel>("Result/P4Result/Image/ScrollView/Viewport/P4BombGrid").GetComponent<Transform>();
		P4RScore_Text = UIManager.Instance.Get<UIRoomPanel>("Result/P4Result/P4RScore").GetComponent<Text>();
		ResultBack_Button = UIManager.Instance.Get<UIRoomPanel>("Result/ResultBack").GetComponent<Button>();
		ResultShare_Button = UIManager.Instance.Get<UIRoomPanel>("Result/ResultShare").GetComponent<Button>();
		Setting_Button = UIManager.Instance.Get<UIRoomPanel>("Menu/Dialog/Setting").GetComponent<Button>();
		Leave_Button = UIManager.Instance.Get<UIRoomPanel>("Menu/Dialog/Leave").GetComponent<Button>();
	}

	public void Clear()
	{
		Time_Text = null;
		RoomKey_Text = null;
		Game_Text = null;
		GameType_Text = null;
		GameModel_Text = null;
		P1AvatarImage_Image = null;
		P1Name_Text = null;
		P1Score_Text = null;
		P1Light_Image = null;
		P1Time_Text = null;
		HandCardGrid_Transform = null;
		P1Ready_Image = null;
		P2Info_Image = null;
		P2AvatarImage_Image = null;
		P2Name_Text = null;
		P2Score_Text = null;
		P2Light_Image = null;
		P2Time_Text = null;
		P2HandCard_Image = null;
		P2CardNum_Text = null;
		P2Ready_Image = null;
		P3Info_Image = null;
		P3AvatarImage_Image = null;
		P3Name_Text = null;
		P3Score_Text = null;
		P3Light_Image = null;
		P3Time_Text = null;
		P3HandCard_Image = null;
		P3CardNum_Text = null;
		P3Ready_Image = null;
		P4Info_Image = null;
		P4AvatarImage_Image = null;
		P4Name_Text = null;
		P4Score_Text = null;
		P4Light_Image = null;
		P4Time_Text = null;
		P4HandCard_Image = null;
		P4CardNum_Text = null;
		P4Ready_Image = null;
		ButtonBar_Transform = null;
		Abandon_Button = null;
		Prompt_Button = null;
		Discard_Button = null;
		P1Table_Transform = null;
		P2Table_Transform = null;
		P3Table_Transform = null;
		P4Table_Transform = null;
		Ready_Button = null;
		Message_Image = null;
		Info_Text = null;
		Result_Image = null;
		P1RAvatar_Image = null;
		P1RName_Text = null;
		P1RId_Text = null;
		P1BombGrid_Transform = null;
		P1RScore_Text = null;
		P2RAvatar_Image = null;
		P2RName_Text = null;
		P2RId_Text = null;
		P2BombGrid_Transform = null;
		P2RScore_Text = null;
		P3RAvatar_Image = null;
		P3RName_Text = null;
		P3RId_Text = null;
		P3BombGrid_Transform = null;
		P3RScore_Text = null;
		P4RAvatar_Image = null;
		P4RName_Text = null;
		P4RId_Text = null;
		P4BombGrid_Transform = null;
		P4RScore_Text = null;
		ResultBack_Button = null;
		ResultShare_Button = null;
		Setting_Button = null;
		Leave_Button = null;
	}

	public Text Time_Text;
	public Text RoomKey_Text;
	public Text Game_Text;
	public Text GameType_Text;
	public Text GameModel_Text;
	public Image P1AvatarImage_Image;
	public Text P1Name_Text;
	public Text P1Score_Text;
	public Image P1Light_Image;
	public Text P1Time_Text;
	public Transform HandCardGrid_Transform;
	public Image P1Ready_Image;
	public Image P2Info_Image;
	public Image P2AvatarImage_Image;
	public Text P2Name_Text;
	public Text P2Score_Text;
	public Image P2Light_Image;
	public Text P2Time_Text;
	public Image P2HandCard_Image;
	public Text P2CardNum_Text;
	public Image P2Ready_Image;
	public Image P3Info_Image;
	public Image P3AvatarImage_Image;
	public Text P3Name_Text;
	public Text P3Score_Text;
	public Image P3Light_Image;
	public Text P3Time_Text;
	public Image P3HandCard_Image;
	public Text P3CardNum_Text;
	public Image P3Ready_Image;
	public Image P4Info_Image;
	public Image P4AvatarImage_Image;
	public Text P4Name_Text;
	public Text P4Score_Text;
	public Image P4Light_Image;
	public Text P4Time_Text;
	public Image P4HandCard_Image;
	public Text P4CardNum_Text;
	public Image P4Ready_Image;
	public Transform ButtonBar_Transform;
	public Button Abandon_Button;
	public Button Prompt_Button;
	public Button Discard_Button;
	public Transform P1Table_Transform;
	public Transform P2Table_Transform;
	public Transform P3Table_Transform;
	public Transform P4Table_Transform;
	public Button Ready_Button;
	public Image Message_Image;
	public Text Info_Text;
	public Image Result_Image;
	public Image P1RAvatar_Image;
	public Text P1RName_Text;
	public Text P1RId_Text;
	public Transform P1BombGrid_Transform;
	public Text P1RScore_Text;
	public Image P2RAvatar_Image;
	public Text P2RName_Text;
	public Text P2RId_Text;
	public Transform P2BombGrid_Transform;
	public Text P2RScore_Text;
	public Image P3RAvatar_Image;
	public Text P3RName_Text;
	public Text P3RId_Text;
	public Transform P3BombGrid_Transform;
	public Text P3RScore_Text;
	public Image P4RAvatar_Image;
	public Text P4RName_Text;
	public Text P4RId_Text;
	public Transform P4BombGrid_Transform;
	public Text P4RScore_Text;
	public Button ResultBack_Button;
	public Button ResultShare_Button;
	public Button Setting_Button;
	public Button Leave_Button;
}
