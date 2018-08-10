using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class Message : MonoBehaviour {
    Image Root;
    Text Info;
    Vector3 OriginalLocation;

    // Use this for initialization
    void Start () {
    }

    private void Init()
    {
        if (OriginalLocation == null)
        {
            OriginalLocation = transform.localPosition;
            Root = transform.GetComponent<Image>();
            Info = transform.GetChild(0).GetComponent<Text>();
        }
    }

   
}
