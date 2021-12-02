using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class R020 : Riddle {
    private static Vector2 result = new Vector2(-36, 12.5f);

    public override void OnEnable() {
        base.OnEnable();
        resultAreaImage = Resources.Load<Sprite>("RiddleAssets/020/result") as Sprite;
        title = "Unglaublicher Durchbruch";
        points = 40;
        description = $"Findest du durch das Labyrinth?\n\n"
         + $"Um vom Startpunkt links unten zum Ziel rechts oben zu gelangen, <color={RED}>musst du eine Stelle der Mauer durchbrechen</color>.\n\n"
         + "Klicke um den Kreis auf dem Mauerstück zu platzieren, das deiner Meinung nach zerstört werden muss.";
        solution = "Was für ein Durchbruch!\n\nDu hast den Weg durch den Irrgarten gefunden. Das ist offenbar eine Art Schatzkammer.";

        interactiveArea = Instantiate(Resources.Load<GameObject>("RiddleAssets/020/R020")) as GameObject;
    }

    public override bool checkResult() {
        Image marker = interactiveArea.transform.GetChild(0).GetComponent<DynamicSelection>().marker;
        return Vector2.Distance(marker.transform.localPosition, result) < 7;
    }

    public override bool isResultValid() {
        return true;
    }
}
