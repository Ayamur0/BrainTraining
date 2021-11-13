using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIElementDragger : EventTrigger {
    public GameObject parent;
    private bool dragging;
    private Vector2 offset;

    private Vector2 parentMin;
    private Vector2 parentMax;
    private float width;
    private float height;

    void Start() {
        parent = transform.parent.gameObject;
        Rect rect = parent.GetComponent<RectTransform>().rect;
        parentMin = parent.transform.TransformPoint(new Vector2(rect.xMin, rect.yMin));
        parentMax = parent.transform.TransformPoint(new Vector2(rect.xMax, rect.yMax));
        RectTransform rectTransform = GetComponent<RectTransform>();
        width = rectTransform.sizeDelta.x;
        height = rectTransform.sizeDelta.y;
    }


    public void Update() {
        if (dragging) {
            Move();
            Rotate();
        }
    }

    void Move() {
        float x = Input.mousePosition.x - offset.x;
        if (x + width / 2 > parentMax.x) {
            x = parentMax.x - width / 2;
        }
        if (x - width / 2 < parentMin.x) {
            x = parentMin.x + width / 2;
        }
        float y = Input.mousePosition.y - offset.y;
        if (y + height / 2 > parentMax.y) {
            y = parentMax.y - height / 2;
        }
        if (y - height / 2 < parentMin.y) {
            y = parentMin.y + height / 2;
        }
        transform.position = new Vector2(x, y);
    }

    void Rotate() {
        if (Input.GetKeyDown(KeyCode.Q)) {
            transform.Rotate(0.0f, 0.0f, 90.0f, Space.Self);
            float d = height;
            height = width;
            width = d;
        }
        if (Input.GetKeyDown(KeyCode.E)) {
            transform.Rotate(0.0f, 0.0f, -90.0f, Space.Self);
            float d = height;
            height = width;
            width = d;
        }
    }

    public override void OnPointerDown(PointerEventData eventData) {
        dragging = true;
        offset = eventData.position - new Vector2(transform.position.x, transform.position.y);
    }

    public override void OnPointerUp(PointerEventData eventData) {
        dragging = false;
    }
}
