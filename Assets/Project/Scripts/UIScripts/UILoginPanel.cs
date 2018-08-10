using GFrame;
using GN;
using Logic;

public class UILoginPanel : UIBehaviour
{
	protected override void InitUI()
	{
		mUIComponents = m_IComponents as UILoginPanelComponents;

        CheckVersion();
        mUIComponents.Login_Button.gameObject.SetActive(true);
    }

	protected override void RegisterUIEvent()
	{
        mUIComponents.Login_Button.onClick.AddListener(LoginServerLogin);
	}

    private void RegisterInvoke()
    {
        //var client = NetworkManager.Instance.Get<LoginClient>().Client;

        //client.RegisterInvokeInstance(null, this, "CheckVersionResult", typeof(VersionResult));
        //client.RegisterInvokeInstance(null, this, "LoginServerLoginResult", typeof(Common.Model.Login.LoginResult));

        //NetworkManager.Instance.Get<LoginClient>().ConnectToServer();

        //NetworkManager.Instance.Get<GameClient>().Client.RegisterInvokeInstance(null, this, "GameServerLoginResult", typeof(Common.Model.User.LoginResult));
    }

    #region CheckVersion
    private void CheckVersion()
    {
        DeviceInfo di = new DeviceInfo();
        di.version = Config.Instance.Version;
        //NetworkManager.Instance.Get<LoginClient>().Client.BeginInvokeServiceService((int)LoginCommand.CheckVersion, new object[] { Config.Instance.GameID, di });
    }

    //[MethodType(MethodTypeEnum.InvokeWhenServerResponse)]
    //[CommandID((int)LoginCommand.CheckVersion)]
    //public void CheckVersionResult(VersionResult result)
    //{
    //    if (result.is_success)
    //    {
    //        mUIComponents.Login_Button.gameObject.SetActive(true);
    //    }
    //    else
    //    {

    //    }
    //}
    #endregion

    #region LoginServerLogin
    private async void LoginServerLogin()
    {
        DeviceInfo di = new DeviceInfo();
        di.version = Config.Instance.Version;
        var LoginSession = Game.Scene.GetComponent<NetClientComponent>().Create(NetworkHelper.ToIPEndPoint(Config.Instance.LoginIp, Config.Instance.LoginPort));
        var result = (Login.Response)await LoginSession.Call(new Login.Request() { Account = di.deviceId, Password = "123456" });
        if(result.IsLogin)
        {
            LoginSession.Dispose();
            var session = Game.Scene.GetComponent<NetClientComponent>().Create(NetworkHelper.ToIPEndPoint(result.GateIP, result.GatePort));
            Game.Scene.GetComponent<SessionComponent>().Session = session;
            var gateLoginResult = (GateLogin.Response)await session.Call(new GateLogin.Request() { account = di.deviceId, key = result.Key });
            if (gateLoginResult.twill_user != null)
            {
                UserData.Instance.user = gateLoginResult.twill_user;
                SceneManager.Instance.OpenScene(GFrame.Scene.Main);
            }
        }

        //NetworkManager.Instance.Get<LoginClient>().Client.BeginInvokeServiceService((int)LoginCommand.Login, new object[] { Config.Instance.GameID, di.deviceId, "123456", null, null, di });
    }

    //[MethodType(MethodTypeEnum.InvokeWhenServerResponse)]
    //[CommandID((int)LoginCommand.Login)]
    //public void LoginServerLoginResult(Common.Model.Login.LoginResult result)
    //{
    //    if (result.is_success)
    //    {
    //        NetworkManager.Instance.Close<LoginClient>();

    //        ConnectToGameClient(result);
    //    }
    //}

    public void ConnectToGameClient(LoginResult result)
    {
        //var client = NetworkManager.Instance.Get<GameClient>();
        //client.IP = result.server.ip;
        //client.Port = (ushort)result.server.port;

        //GameLib.BetterSerialize.BytesWriter bw = new GameLib.BetterSerialize.BytesWriter(48);
        //bw.WriteRaw(result.token, 32);
        //bw.Write(result.uid);
        //bw.Write(DateTime.Now);
        //client.Token = bw.Bytes;
        //client.ConnectToServer();
        //GameServerLogin();
    }

    #endregion

    #region GameServerLogin
    private void GameServerLogin()
    {
        //NetworkManager.Instance.Get<GameClient>().Client.BeginInvokeServiceService((int)ServerCommand.Login, new object[] { null, null, (short)0 });
    }

    //[MethodType(MethodTypeEnum.InvokeWhenServerResponse)]
    //[CommandID((int)ServerCommand.Login)]
    //public void GameServerLoginResult(Common.Model.User.LoginResult result)
    //{
    //    if (result.is_success)
    //    {
    //        UserData.Instance.user = result.twill_user;
    //        if (result.state == Common.Model.User.PlayerState.Matching)
    //        {
    //            SceneManager.Instance.OpenScene(Scene.Room);
    //            SceneManager.Instance.OpenScene(Scene.Loading);
    //        }
    //        else if(result.state == Common.Model.User.PlayerState.Room)
    //        {
    //            SceneManager.Instance.OpenScene(Scene.Room);
    //            SendMsg(Event.UpdateRoomInfo, result.room_info);
    //        }
    //        else
    //        {
    //            SceneManager.Instance.OpenScene(Scene.Main);
    //        }

    //    }
    //}
    #endregion

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
		UnityEngine.Debug.Log("[UILoginPanel:]" + content);
	}

	UILoginPanelComponents mUIComponents = null;
}
