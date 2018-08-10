using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectCard : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler
{
    [System.NonSerialized]
    public bool isSelected;
    Vector3 originPos;
    public void OnPointerDown(PointerEventData eventData)
    {
        SelectMovie(); 
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (eventData.pointerPress)
        {
            SelectMovie();
        }
    }

    public void SelectMovie() {
        originPos.y += isSelected ? -30 : 30;
        gameObject.transform.DOLocalMove(originPos, 0.2f);
        isSelected = !isSelected;
    }

    public void ResetPos()
    {
        originPos = gameObject.transform.localPosition;	
    }


    // Use this for initialization
    void Start () {
        ResetPos();
	}
}
