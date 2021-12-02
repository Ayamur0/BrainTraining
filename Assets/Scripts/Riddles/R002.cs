using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class R002 : Riddle {
    public override void OnEnable() {
        base.OnEnable();
        title = "Die Zuckerwaagen";
        points = 50;
        description = $"Hier stehen zwei digitale Waagen. \n\n"
         + $"Die Displays sind an der gleichen Stelle kaputt. Daher kann man den <color={RED}>linken unteren Teil der Zahl nicht erkennen</color>. \n\n"
         + $"Zum Beispiel würde die Zahl \"6\" als \"5\" erscheinen. Der Zucker wird durch das kaputte Display "
         + $"auf der <color={RED}>linken Waage ein Gramm schwerer</color> und auf der <color={RED}>rechten Waage ein Gramm leichter angezeigt</color>, als er tatsächlich ist.\n\n"
         + $"Was ist das tatsächliche <color={RED}>Gesamtgewicht in Gramm</color> des Zuckers für jede der beiden Waagen?";
        solution = "Zuckersüß!\n\nDas eigentliche Gesamtgewicht des Zuckers war acht Gramm auf der linken Waage und sechs Gramm auf der rechten. "
         + "Vielleicht sollte man sie mal reparieren lassen.";

        interactiveArea = Instantiate(Resources.Load<GameObject>("RiddleAssets/002/R002")) as GameObject;
    }

    public override bool checkResult() {
        return interactiveArea.GetComponent<NumberInput>().GetInput() == 14;
    }

    public override bool isResultValid() {
        return interactiveArea.GetComponent<NumberInput>().IsInputValid();
    }
}
