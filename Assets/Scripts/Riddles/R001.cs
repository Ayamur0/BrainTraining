using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class R001 : Riddle {
    public GameObject smallTriangle1;
    public GameObject smallTriangle2;
    public GameObject bigTriangle;

    private static Vector2 topPos = new Vector2(-15, 98);
    private static Vector2 bottomPos = new Vector2(-15, -95);
    private static Vector2 rightPos = new Vector2(70, 0);

    public override void OnEnable() {
        base.OnEnable();
        resultType = 0;
        resultAreaImage = Resources.Load<Sprite>("RiddleAssets/001/result") as Sprite;
        description = "Aus dem Schild über dem Kuchenladen ist ein \"K\" heruntergefallen. \n\n"
         + "Verwende die drei Dreicke, um den Buchstaben \"K\" im Kasten zu bilden."
         + "Klicke auf ein Dreick und halte die Maustaste gedrückt um es zu nehmen. Sobald du es genommen hast, kannst du es mit Q und E drehen. \n\n"
         + "Lasse die Maustaste los, um das Dreieck abzulegen. Wenn du ein \"K\" bildest, erscheint sofort die Erfolgsnachricht.";

        interactive = true;
        interactiveArea = Instantiate(Resources.Load<GameObject>("RiddleAssets/001/R001")) as GameObject;
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

        Debug.Log("result: " + Vector2.Distance(topPos, topTriangle.transform.localPosition)
             + " " + Vector2.Distance(bottomPos, bottomTriangle.transform.localPosition)
             + " " + Vector2.Distance(rightPos, bigTriangle.transform.localPosition));

        return Vector2.Distance(topPos, topTriangle.transform.localPosition)
             + Vector2.Distance(bottomPos, bottomTriangle.transform.localPosition)
             + Vector2.Distance(rightPos, bigTriangle.transform.localPosition) < 30;
    }
}
