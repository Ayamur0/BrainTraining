using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SelectionController : EventTrigger {
    public Image marker;
    private Vector2 areaMin;
    private Vector2 areaMax;

    void Start() {
        marker = transform.GetChild(0).GetComponent<Image>();
        Rect rect = GetComponent<RectTransform>().rect;
        areaMin = transform.TransformPoint(new Vector2(rect.xMin, rect.yMin));
        areaMax = transform.TransformPoint(new Vector2(rect.xMax, rect.yMax));
    }

    public override void OnPointerDown(PointerEventData eventData) {
        float x = Input.mousePosition.x;
        float y = Input.mousePosition.y;
        if (x < areaMax.x && x > areaMin.x && y > areaMin.y && y < areaMax.y)
            marker.transform.position = new Vector2(x, y);
    }
}
