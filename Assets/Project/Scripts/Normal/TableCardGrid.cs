using UnityEngine;

[ExecuteInEditMode]
public class TableCardGrid : MonoBehaviour {

    private int old_child = 0;
	
	// Update is called once per frame
	void Update () {
        if (old_child != transform.childCount)
        {
            ResetPos();
            old_child = transform.childCount;
        }
    }

    public void ResetPos()
    {
        var this_trans = transform.GetComponent<RectTransform>();
        this_trans.sizeDelta = new Vector2(transform.childCount * 50, this_trans.sizeDelta.y);
        foreach (Transform child in transform)
        {
            var select_card = child.GetComponent<SelectCard>();
            select_card.enabled = false;
        }
    }
}
