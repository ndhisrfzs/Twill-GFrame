using UnityEngine;

[ExecuteInEditMode]
public class HandCardGrid : MonoBehaviour {

    [System.NonSerialized]
    public int old_child = 0;
	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        if(old_child != transform.childCount)
        {
            ResetPos();
            old_child = transform.childCount;
        }
	}

    public void ResetPos()
    {
        float start_pos = -(transform.childCount - 1) * 50 / 2 + 180;
        foreach (Transform child in transform)
        {
            var trans = child.GetComponent<RectTransform>();
            trans.localPosition = new Vector2(start_pos, trans.localPosition.y);
            child.GetComponent<SelectCard>().ResetPos();
            start_pos += 50;
        }
    }
}
