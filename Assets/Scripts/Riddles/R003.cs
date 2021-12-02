using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class R003 : Riddle {
    public override void OnEnable() {
        base.OnEnable();
        resultAreaImage = Resources.Load<Sprite>("RiddleAssets/003/result") as Sprite;
        title = "Ein Fingerzeig";
        points = 45;
        description = $"Wir haben hier neun Leute. Einige gehören zu den <color={RED}>\"Braven\"</color>, die anderen zu den <color={RED}>\"Bösen\"</color>.\n\n"
         + $"<color={RED}>Wenn ein Braver einen Bösen neben sich hat, zeigt er auf ihn. Ansonsten verschränkt er die Arme.</color>\n\n"
         + $"<color={RED}>Die Bösen zeigen immer auf jemanden, ganze egal, ob diese Person brav oder böse ist.</color>\n\n"
         + $"Klicke auf eine Person, um die Markierung zu aktivieren oder deaktivieren.\n\n"
         + $"Markiere die beiden Bösen, die sich in der Gruppe verstecken.";
        solution = "Die guten ins Töpfchen...\n\n Die Bösen befinden sich oben in der Mitte und rechts. Wenn man weiß, dass die Bösen auf die Braven zeigen, findet man sie schnell.";

        interactiveArea = Instantiate(Resources.Load<GameObject>("RiddleAssets/003/R003")) as GameObject;
    }

    public override bool checkResult() {
        List<int> selected = interactiveArea.GetComponent<StaticSelection>().selectedIndices;
        return selected.Contains(1) && selected.Contains(2);
    }

    public override bool isResultValid() {
        return interactiveArea.GetComponent<StaticSelection>().selectedIndices.Count == 2;
    }
}
