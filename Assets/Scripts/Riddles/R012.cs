using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class R012 : Riddle { //45
    public override void OnEnable() {
        base.OnEnable();
        resultAreaImage = Resources.Load<Sprite>("RiddleAssets/012/result") as Sprite;
        description = "Drei der Schatzkisten enthalten jeweils ein Juwel. \n\n"
         + $"Berühre die Schalter zwischen den Truhe, um eine Zahl erscheinen zu lassen. Die Zahl sagt dir dann, "
         + $"<color={RED}>wie viele Juwelen sich in den umliegenden Kisten befinden</color>.\n\n"
         + $"<color={RED}>Wo verstecken sich die Juwelen</color>? Klicke auf eine Truhe, wenn du meinst, dass sich ein Juwel darin befindet. Berühre sie erneut um die Auswahl zu löschen.";

        interactiveArea = Instantiate(Resources.Load<GameObject>("RiddleAssets/012/R012")) as GameObject;
    }

    public override bool checkResult() {
        List<int> selected = interactiveArea.GetComponent<CircleSelectionManager>().selectedIndices;
        return selected.Contains(0) && selected.Contains(4) && selected.Contains(8);
    }
}
