using GFrame;
using UnityEngine;

public class UISettingPanel : UIBehaviour
{
	protected override void InitUI()
	{
		mUIComponents = m_IComponents as UISettingPanelComponents;
        if(PlayerPrefs.GetFloat("MusicVolume", 0.8f) <= 0)
        {
            mUIComponents.MusicToggle_Toggle.isOn = true;
        }
        if(PlayerPrefs.GetFloat("EffectVolume", 0.8f) <= 0)
        {
            mUIComponents.SoundToggle_Toggle.isOn = true;
        }
    }

	protected override void RegisterUIEvent()
	{
        mUIComponents.Close_Button.onClick.AddListener(() => {
            this.Hide();
        });
        mUIComponents.MusicToggle_Toggle.onValueChanged.AddListener((ret) => {
            if (mUIComponents.MusicToggle_Toggle.isOn)
            {
                PlayerPrefs.SetFloat("MusicVolume", 0f);
                AudioManager.Instance.SetMusicVolume(0f);
            }
            else
            {
                PlayerPrefs.SetFloat("MusicVolume", 0.8f);
                AudioManager.Instance.SetMusicVolume(0.8f);
            }
        });
        mUIComponents.SoundToggle_Toggle.onValueChanged.AddListener((ret) => {
            if (mUIComponents.SoundToggle_Toggle.isOn)
            {
                PlayerPrefs.SetFloat("EffectVolume", 0f);
                AudioManager.Instance.SetEffectVolume(0f);
            }
            else
            {
                PlayerPrefs.SetFloat("EffectVolume", 0.8f);
                AudioManager.Instance.SetEffectVolume(0.8f);
            }
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
		UnityEngine.Debug.Log("[UISettingPanel:]" + content);
	}

	UISettingPanelComponents mUIComponents = null;
}
