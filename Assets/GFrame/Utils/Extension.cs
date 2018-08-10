using UnityEngine;

public static class Extemsion {
    public static void SetParentAndInit(this Transform transform, Transform parent)
    {
        transform.gameObject.SetActive(false);
        transform.SetParent(parent);
        var uiGoRectTrans = transform.GetComponent<RectTransform>();
        uiGoRectTrans.offsetMin = new Vector2(0.5f, 0.5f);
        uiGoRectTrans.offsetMax = new Vector2(0.5f, 0.5f);
        uiGoRectTrans.anchoredPosition3D = Vector3.zero;
        uiGoRectTrans.pivot = new Vector2(0.5f, 0.5f);
        uiGoRectTrans.anchorMin = new Vector2(0.5f, 0.5f);
        uiGoRectTrans.anchorMax = new Vector2(0.5f, 0.5f);

        transform.localScale = Vector3.one;
        transform.gameObject.SetActive(true);
    }
}
