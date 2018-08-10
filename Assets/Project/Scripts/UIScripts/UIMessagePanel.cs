using GFrame;
using System.Collections;
using UnityEngine;

public class UIMessagePanel : UIBehaviour
{
	protected override void InitUI()
	{
        alwaysShow = true;
		mUIComponents = m_IComponents as UIMessagePanelComponents;
	}

	protected override void RegisterUIEvent()
	{
        RegisterEvent(Event.ShowToast, (msg) => {
            EventMsgWithValue<string> event_msg = msg as EventMsgWithValue<string>;
            ShowMessage(event_msg.value);
        });
    }

    public void ShowMessage(string message)
    {
        var message_image = mUIComponents.Message_Image.transform.GetComponent<CanvasGroup>();

        mUIComponents.Info_Text.text = (message == null) ? "" : message;
        message_image.transform.localPosition = transform.localPosition;
        message_image.alpha = 1;

        message_image.gameObject.SetActive(true);
        StartCoroutine(IEun_ShowMeaagge(message_image));
    }

    IEnumerator IEun_ShowMeaagge(CanvasGroup canvas)
    {
        yield return new WaitForSeconds(1f);

        while (canvas.alpha > 0.01f)
        {
            float delTime = Time.deltaTime;
            canvas.transform.Translate(Vector3.up * delTime * 1f, Space.Self);
            canvas.alpha -= delTime;
            yield return null;
        }

        canvas.alpha = 0;

        canvas.gameObject.SetActive(false);
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
		UnityEngine.Debug.Log("[UIMessagePanel:]" + content);
	}

	UIMessagePanelComponents mUIComponents = null;
}
