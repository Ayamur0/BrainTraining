using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class R007 : Riddle { // 25
    private static Vector2 result = new Vector2(128, 58);

    public override void OnEnable() {
        base.OnEnable();
        resultType = SUBMIT;
        image = Resources.Load<Sprite>("RiddleAssets/007/result") as Sprite;
        description = $"Diesen abgeschlossenen Raum betritt normalerweise nie jemand. \n\n"
         + $"Jetzt ist jedoch <color={RED}>ein Jahr vergangen</color>, und offenbar <color={RED}>hat sich etwas im Raum verändert</color>. Was nur?\n\n"
         + "Klicke um den Kreis auf dem Element zu platzieren, das sich deiner Meinung nach verändert hat.";

        interactive = true;
        interactiveArea = Instantiate(Resources.Load<GameObject>("RiddleAssets/007/R007")) as GameObject;
    }

    public override bool checkResult() {
        Image marker = interactiveArea.transform.GetChild(0).GetComponent<SelectionController>().marker;
        return Vector2.Distance(marker.transform.localPosition, result) < 10;
    }
}
