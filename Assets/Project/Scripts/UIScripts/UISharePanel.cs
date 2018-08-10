using GFrame;
using UnityEngine;

public class UISharePanel : UIBehaviour
{
    private byte[] _IconBytes;
    public byte[] IconBytes
    {
        get
        {
            if (_IconBytes == null)
            {
                Texture2D t2d = Resources.Load<Texture2D>("Texture/Icon");
                _IconBytes = t2d.EncodeToJPG(90);
            }
            return _IconBytes;
        }
    }

    protected override void InitUI()
	{
		mUIComponents = m_IComponents as UISharePanelComponents;
	}

	protected override void RegisterUIEvent()
	{
        mUIComponents.Close_Button.onClick.AddListener(() => {
            this.Hide();
        });
        mUIComponents.ShareFriend_Button.onClick.AddListener(() => {
            WXSDK.ShareUrl("http://www.baidu.com", "开心双扣", "帅哥，来玩啊!", IconBytes, WXShareType.WXSceneSession, (value)=> { SendMsg(Event.ShowToast, value); });
        });
        mUIComponents.ShareFriendCircle_Button.onClick.AddListener(() => {
            WXSDK.ShareUrl("http://www.baidu.com", "开心双扣", "帅哥，来玩啊!", IconBytes, WXShareType.WXSceneTimeline, (value)=> { SendMsg(Event.ShowToast, value); });
        });
	}

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
		UnityEngine.Debug.Log("[UISharePanel:]" + content);
	}

	UISharePanelComponents mUIComponents = null;
}
