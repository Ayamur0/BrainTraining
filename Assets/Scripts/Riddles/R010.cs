using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class R010 : Riddle {
    public override void OnEnable() {
        base.OnEnable();
        title = "Zahlenreihe";
        points = 35;
        description = $"Hier hängen einige Papierschnipsel mit Zahlen, und einer davon fehlt. \n\n"
         + $"<color={RED}>Welche Zahl</color> ist deiner Meinung nach auf <color={RED}>dem fehlenden Papierschnipsel gewesen</color>?";
        solution = "Du hast es geschafft!\n\nDie Zahlen sind ihrer Größe nach aufgehängt: 9, 10, 11, 12, 13.";

        interactiveArea = Instantiate(Resources.Load<GameObject>("RiddleAssets/010/R010")) as GameObject;
    }

    public override bool checkResult() {
        return interactiveArea.GetComponent<NumberInput>().GetInput() == 2;
    }

    public override bool isResultValid() {
        return interactiveArea.GetComponent<NumberInput>().IsInputValid();
    }
}
