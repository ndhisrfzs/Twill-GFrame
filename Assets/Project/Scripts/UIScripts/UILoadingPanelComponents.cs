using GFrame;
using UnityEngine;
using UnityEngine.UI;

public class UILoadingPanelComponents : IUIComponents
{
	public void InitUIComponents()
	{
		Loading_Image = UIManager.Instance.Get<UILoadingPanel>("Loading").GetComponent<Image>();
	}

	public void Clear()
	{
		Loading_Image = null;
	}

	public Image Loading_Image;
}
