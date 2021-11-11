using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class R001 : Riddle {
    public R001() {
        resultType = 0;
        resultAreaImage = Resources.Load<Sprite>("Sprites/RiddleAssets/001/result") as Sprite;
        description = "Aus dem Schild über dem Kuchenladen ist ein \"K\" heruntergefallen. \n\n"
         + "Verwende die drei Dreicke, um den Buchstaben \"K\" im Kasten zu bilden."
         + "Klicke auf ein Dreick und halte die Maustaste gedrückt um es zu nehmen. Sobald du es genommen hast, kannst du es mit Q und E drehen. \n\n"
         + "Lasse die Maustaste los, um das Dreieck abzulegen. Wenn du ein \"K\" bildest, erscheint sofort die Erfolgsnachricht.";

        interactive = true;
        Sprite canvasSprite = Resources.Load<Sprite>("Sprites/RiddleAssets/001/canvas") as Sprite;
        Sprite smallTriangleSprite = Resources.Load<Sprite>("Sprites/RiddleAssets/001/triangleSmall") as Sprite;
        Sprite bigTriangleSprite = Resources.Load<Sprite>("Sprites/RiddleAssets/001/triangleBig") as Sprite;
    }
}
