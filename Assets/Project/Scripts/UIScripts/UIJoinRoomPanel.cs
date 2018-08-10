using GFrame;
using Logic;
using UnityEngine;
using UnityEngine.UI;

public class UIJoinRoomPanel : UIBehaviour
{
	protected override void InitUI()
	{
		mUIComponents = m_IComponents as UIJoinRoomPanelComponents;
	}

    private void OnEnable()
    {
        room_info = null;
        RegisterInvoke();
    }

    private void RegisterInvoke()
    {
        //NetworkManager.Instance.Get<GameClient>().Client.RegisterInvokeInstance(null, this, "EnterRoomResult", typeof(bool));
        //NetworkManager.Instance.Get<GameClient>().Client.RegisterInvokeInstance(null, this, "UpdateRoom", typeof(RoomInfo));
    }

    protected override void RegisterUIEvent()
	{
        mUIComponents.Close_Button.onClick.AddListener(() => {
            this.Hide();
        });

        mUIComponents.OK_Button.onClick.AddListener(() => {
            //Join
            int room_key = GetRoomKey();
            if(room_key <= 0)
            {
                SendMsg(Event.ShowToast, "房间号输入有误!");
            }
            else
            {
                //NetworkManager.Instance.Get<GameClient>().Client.BeginInvokeServiceService((int)ServerCommand.EnterRoom, new object[] { room_key });
            }
        });

        mUIComponents.Zero_Button.onClick.AddListener(()=> { AddNumber(0); });
        mUIComponents.One_Button.onClick.AddListener(()=> { AddNumber(1); });
        mUIComponents.Two_Button.onClick.AddListener(()=> { AddNumber(2); });
        mUIComponents.Three_Button.onClick.AddListener(()=> { AddNumber(3); });
        mUIComponents.Four_Button.onClick.AddListener(()=> { AddNumber(4); });
        mUIComponents.Five_Button.onClick.AddListener(()=> { AddNumber(5); });
        mUIComponents.Six_Button.onClick.AddListener(()=> { AddNumber(6); });
        mUIComponents.Seven_Button.onClick.AddListener(()=> { AddNumber(7); });
        mUIComponents.Eight_Button.onClick.AddListener(()=> { AddNumber(8); });
        mUIComponents.Nine_Button.onClick.AddListener(()=> { AddNumber(9); });
        mUIComponents.Redo_Button.onClick.AddListener(()=> { ClearNumber(); });
        mUIComponents.Delete_Button.onClick.AddListener(()=> { RemoveNumber(); });
	}

    //[MethodType(MethodTypeEnum.InvokeWhenServerResponse)]
    //[CommandID((int)ServerCommand.EnterRoom)]
    //public void EnterRoomResult(bool is_success)
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
    //    else
    //    {
    //        SendMsg(Event.ShowToast, "无法加入房间");
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

    private void AddNumber(int number)
    {
        ChangeKeyNumber(number.ToString());
        if(m_keyIndex < 6)
            m_keyIndex++;
    }

    private void RemoveNumber()
    {
        if (m_keyIndex > 0)
            m_keyIndex--;
        ChangeKeyNumber("");
    }

    private void ClearNumber()
    {
        while(m_keyIndex >= 0)
        {
            ChangeKeyNumber("");
            m_keyIndex--;
        }
        m_keyIndex = 0;
    }

    private void ChangeKeyNumber(string number)
    {
        switch (m_keyIndex)
        {
            case 0:
                mUIComponents.key_0_Text.text = number.ToString();
                break;
            case 1:
                mUIComponents.key_1_Text.text = number.ToString();
                break;
            case 2:
                mUIComponents.key_2_Text.text = number.ToString();
                break;
            case 3:
                mUIComponents.key_3_Text.text = number.ToString();
                break;
            case 4:
                mUIComponents.key_4_Text.text = number.ToString();
                break;
            case 5:
                mUIComponents.key_5_Text.text = number.ToString();
                break;
            default:
                break;
        }
    }

    private int GetRoomKey()
    {
        if(m_keyIndex < 6)
        {
            return 0;
        }

        int key_0 = int.Parse(mUIComponents.key_0_Text.text);
        int key_1 = int.Parse(mUIComponents.key_1_Text.text);
        int key_2 = int.Parse(mUIComponents.key_2_Text.text);
        int key_3 = int.Parse(mUIComponents.key_3_Text.text);
        int key_4 = int.Parse(mUIComponents.key_4_Text.text);
        int key_5 = int.Parse(mUIComponents.key_5_Text.text);

        return key_0 * 100000 + key_1 * 10000 + key_2 * 1000 + key_3 * 100 + key_4 * 10 + key_5;
    }

	protected override void OnShow()
	{
		base.OnShow();
	}

	protected override void OnHide()
	{
        ClearNumber();
		base.OnHide();
	}

	protected override void OnClose()
	{
        ClearNumber();
		base.OnClose();
	}

	protected override void DestoryUI()
	{
		base.DestoryUI();
	}

	void ShowLog(string content)
	{
		UnityEngine.Debug.Log("[UIJoinRoomPanel:]" + content);
	}

	UIJoinRoomPanelComponents mUIComponents = null;
    int m_keyIndex = 0;
}
