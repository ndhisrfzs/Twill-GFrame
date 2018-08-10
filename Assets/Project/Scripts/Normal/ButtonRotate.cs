using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ButtonRotate : MonoBehaviour {
    bool is_selected = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnButtonClick()
    {
        is_selected = !is_selected;
        transform.GetChild(1).transform.DORotate(new Vector3(0, 0, is_selected ? 180 : 0), 0.1f).OnComplete(()=> {
            transform.GetChild(0).gameObject.SetActive(is_selected);
        });
    }

    private void OnEnable()
    {
        transform.GetChild(1).transform.Rotate(new Vector3(0, 0, is_selected ? 180 : 0));
        is_selected = false;
        transform.GetChild(0).gameObject.SetActive(is_selected);
    }
}
