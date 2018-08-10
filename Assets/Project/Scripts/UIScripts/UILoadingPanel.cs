using GFrame;
using UnityEngine.UI;
using DG.Tweening;
using System.Collections;
using UnityEngine;

public class UILoadingPanel : UIBehaviour
{
	protected override void InitUI()
	{
		mUIComponents = m_IComponents as UILoadingPanelComponents;
        var slider = mUIComponents.Loading_Image.transform.GetComponent<Slider>();
        DOTween.To(()=>slider.value, x=>slider.value=x, 90, 3);
    }

    protected override void RegisterUIEvent()
	{
        RegisterEvent(Event.LoadingUpdate, (msg) => {
            var slider = mUIComponents.Loading_Image.transform.GetComponent<Slider>();
            slider.value = 100;
            StartCoroutine(WaitClose());
        });
	}

    IEnumerator WaitClose()
    {
        yield return new WaitForSeconds(0.01f);
        UIManager.Instance.CloseUI<UILoadingPanel>();
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
        UnRegisterAllEvent();
	}

	protected override void DestoryUI()
	{
		base.DestoryUI();
	}

	void ShowLog(string content)
	{
		UnityEngine.Debug.Log("[UILoadingPanel:]" + content);
	}

	UILoadingPanelComponents mUIComponents = null;
}
