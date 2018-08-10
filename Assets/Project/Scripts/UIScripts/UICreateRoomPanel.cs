using GFrame;
using GN;
using Logic;

public class UICreateRoomPanel : UIBehaviour
{
	protected override void InitUI()
	{
		mUIComponents = m_IComponents as UICreateRoomPanelComponents;
    }

    private void OnEnable()
    {
        room_info = null;
        RegisterInvoke();
    }

    private void RegisterInvoke()
    {
        //NetworkManager.Instance.Get<GameClient>().Client.RegisterInvokeInstance(null, this, "MatchPlayerResult", typeof(bool));
        //NetworkManager.Instance.Get<GameClient>().Client.RegisterInvokeInstance(null, this, "UpdateRoom", typeof(RoomInfo));
    }

    protected override void RegisterUIEvent()
	{
        mUIComponents.OK_Button.onClick.AddListener(ClickOkButton);

        mUIComponents.Cancel_Button.onClick.AddListener(() => {
            this.Hide();
        });

        mUIComponents.Close_Button.onClick.AddListener(() => {
            this.Hide();
        });
	}

    public async void ClickOkButton()
    {
        Games game = mUIComponents.Classical_Toggle.isOn ? Games.Classical : Games.Metallic;
        GameType game_type = mUIComponents.Friend_Toggle.isOn ? GameType.Friend : GameType.Random;
        byte model_type = 0;
        model_type |= mUIComponents.BombScore_Toggle.isOn ? (byte)ModelType.BombScore : (byte)0;
        model_type |= mUIComponents.BombDouble_Toggle.isOn ? (byte)ModelType.BombDouble : (byte)0;
        model_type |= mUIComponents.ChangePartner_Toggle.isOn ? (byte)ModelType.ChangePartner : (byte)0;

        var session = Game.Scene.GetComponent<SessionComponent>().Session;
        var MatchPlayerResult = (MatchPlayer.Response)await session.Call(new MatchPlayer.Request() { game = game, gameType = game_type, modelType = model_type });
        if(MatchPlayerResult.isSuccess)
        {
            SceneManager.Instance.OpenScene(GFrame.Scene.Loading);
            //SceneManager.Instance.OpenScene(GFrame.Scene.Room);
        }
    }

    //[MethodType(MethodTypeEnum.InvokeWhenServerResponse)]
    //[CommandID((int)ServerCommand.MatchPlayer)]
    //public void MatchPlayerResult(bool is_success)
    //{
    //    if (is_success)
    //    {
    //        SceneManager.Instance.OpenScene(Scene.Room);
    //        if (room_info == null)
    //        {
    //            SceneManager.Instance.OpenScene(Scene.Loading);
    //        }
    //        else
    //        {
    //            SendMsg(Event.UpdateRoomInfo, room_info);
    //        }
    //    }
    //}

    RoomInfo room_info;
    ///// <summary>
    ///// 更新Room信息
    ///// </summary>
    ///// <param name="room_info"></param>
    //[MethodType(MethodTypeEnum.InvokeForServerRequest)]
    //[CommandID((int)ClientCommand.UpdateRoom)]
    //public void UpdateRoom(RoomInfo room_info)
    //{
    //    if (room_info != null)
    //    {
    //        room_info.InitSort(UserData.Instance.user.uid);
    //        this.room_info = room_info;
    //    }
    //}

    protected override void OnShow()
	{
		base.OnShow();
	}

	protected override void OnHide()
	{
		base.OnHide();
	}

	protected override void OnClose()
	{
		base.OnClose();
	}

	protected override void DestoryUI()
	{
		base.DestoryUI();
	}

	void ShowLog(string content)
	{
		UnityEngine.Debug.Log("[UICreateRoomPanel:]" + content);
	}

	UICreateRoomPanelComponents mUIComponents = null;
}
