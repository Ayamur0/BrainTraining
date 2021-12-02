using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class R021 : Riddle { // 50
    public override void OnEnable() {
        base.OnEnable();
        resultAreaImage = Resources.Load<Sprite>("RiddleAssets/021/result") as Sprite;
        title = "Brücke über aufgewühlte Wasser";
        points = 35;
        description = $"Ein Dreisprung Athlet hat sich entscheiden seiner Freundin einen besonderen Antrag zu machen, indem er auf schwimmenden Planken über den Fluss springt.\n\n"
         + $"Bei seinem ersten \"Hop\" und dem zweiten \"Step\" kann er <color={RED}>entweder eine Planke nach vorne, links oder rechts gehen</color>, "
         + $"und dabei die Richtung ändern falls nötig. Aber beim letzten \"Jump\", muss er sich <color={RED}>in dieselbe Richtung bewegen, in die er sich beim \"Step\" bewegt hat, "
         + $"wobei er eine Planke überspringt und auf der übernächsten landet.</color> \n\n"
         + "Diese Abfolge wiederholt er solange, bis er die rosa Planke vor seiner Freundin, auf der anderen Seite, erreicht.\n\n"
         + "Wo sollte er starten?";

        solution = "Du hast es geschafft! \n\n Mit einem Hop, Step, Jump und \"Ja, ich will\" ist der Job erledigt. Gratulation!";

        interactiveArea = Instantiate(Resources.Load<GameObject>("RiddleAssets/021/R021")) as GameObject;
    }

    public override bool checkResult() {
        bool[] selected = interactiveArea.GetComponent<ToggleButtonController>().buttonStates;
        return selected[0] && !selected[1] && !selected[2] && !selected[3];
    }

    public override bool isResultValid() {
        bool[] selected = interactiveArea.GetComponent<ToggleButtonController>().buttonStates;
        foreach (bool b in selected) {
            if (b)
                return true;
        }
        return false;
    }
}
