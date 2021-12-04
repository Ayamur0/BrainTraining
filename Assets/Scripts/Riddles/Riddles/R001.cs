using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class R001 : Riddle {
    public GameObject smallTriangle1;
    public GameObject smallTriangle2;
    public GameObject bigTriangle;

    private static Vector2 topPos = new Vector2(-10, 71);
    private static Vector2 bottomPos = new Vector2(-10, -70);
    private static Vector2 rightPos = new Vector2(57, 2);

    public override void OnEnable() {
        base.init(1);

        Canvas canvas = interactiveArea.GetComponentInChildren<Canvas>();
        Image[] triangles = canvas.GetComponentsInChildren<Image>();
        // interactiveArea Gameobject at index 0
        bigTriangle = triangles[1].gameObject;
        smallTriangle1 = triangles[2].gameObject;
        smallTriangle2 = triangles[3].gameObject;
    }

    public override bool checkResult() {
        GameObject topTriangle = null;
        if (smallTriangle1.transform.eulerAngles.z % 360 == 90)
            topTriangle = smallTriangle1;
        else if (smallTriangle2.transform.eulerAngles.z % 360 == 90)
            topTriangle = smallTriangle2;
        if (topTriangle == null)
            return false;

        GameObject bottomTriangle = null;
        if (smallTriangle1.transform.eulerAngles.z % 360 == 180)
            bottomTriangle = smallTriangle1;
        else if (smallTriangle2.transform.eulerAngles.z % 360 == 180)
            bottomTriangle = smallTriangle2;
        if (bottomTriangle == null)
            return false;

        if (bigTriangle.transform.eulerAngles.z % 360 != 90)
            return false;

        return Vector2.Distance(topPos, topTriangle.transform.localPosition)
             + Vector2.Distance(bottomPos, bottomTriangle.transform.localPosition)
             + Vector2.Distance(rightPos, bigTriangle.transform.localPosition) < 30;
    }
}
