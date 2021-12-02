using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class R003 : Riddle {
    public override void OnEnable() {
        base.OnEnable();
        resultAreaImage = Resources.Load<Sprite>("RiddleAssets/003/result") as Sprite;
        description = "Aus dem Schild über dem Kuchenladen ist ein \"K\" heruntergefallen. \n\n"
         + "Verwende die drei Dreicke, um den Buchstaben \"K\" im Kasten zu bilden."
         + "Klicke auf ein Dreick und halte die Maustaste gedrückt um es zu nehmen. Sobald du es genommen hast, kannst du es mit Q und E drehen. \n\n"
         + "Lasse die Maustaste los, um das Dreieck abzulegen. Wenn du ein \"K\" bildest, erscheint sofort die Erfolgsnachricht.";

        interactiveArea = Instantiate(Resources.Load<GameObject>("RiddleAssets/003/R003")) as GameObject;
    }

    public override bool checkResult() {
        List<int> selected = interactiveArea.GetComponent<CircleSelectionManager>().selectedIndices;
        return selected.Contains(1) && selected.Contains(2);
    }
}
