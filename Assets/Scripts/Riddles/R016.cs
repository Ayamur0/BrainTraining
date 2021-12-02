using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class R016 : Riddle { // 35
    public override void OnEnable() {
        base.OnEnable();
        title = "Der goldene Schnitt";
        points = 35;
        description = $"Im Bild siehst du einen Kuchen in Form einer Sechs. \n\n"
         + $"Du musst ihn mit einer geraden Linie durchschneiden, damit <color={RED}>zwei Zahlen entstehen</color>. \n\n"
         + $"Wie kannst du den Kuchen schneiden, um das <color={RED}>größtmögliche Ergebnis</color> zu erreichen, "
         + $"wenn du <color={RED}>die beiden Zahlen addierst</color>? Wie lautet dieses Ergebnis?";
        interactiveArea = Instantiate(Resources.Load<GameObject>("RiddleAssets/016/R016")) as GameObject;

        solution = "Meisterlich aufgeschnitten!\n\nWenn du den Kuchen horizontal halbierst, erhältst du zwei Mal diselbe Zahl. Dreht man die Sechs um, erhält man eine Neun";
    }

    public override bool checkResult() {
        return interactiveArea.GetComponent<NumberInput>().GetInput() == 18;
    }

    public override bool isResultValid() {
        return interactiveArea.GetComponent<NumberInput>().IsInputValid();
    }
}
