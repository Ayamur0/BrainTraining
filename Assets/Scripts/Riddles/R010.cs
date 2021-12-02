using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class R010 : Riddle { // 35
    public override void OnEnable() {
        base.OnEnable();
        description = $"Hier hängen einige Papierschnipsel mit Zahlen, und einer davon fehlt. \n\n"
         + $"<color={RED}>Welche Zahl</color> ist deiner Meinung nach auf <color={RED}>dem fehlenden Papierschnipsel gewesen</color>?";

        interactiveArea = Instantiate(Resources.Load<GameObject>("RiddleAssets/010/R010")) as GameObject;
    }

    public override bool checkResult() {
        return interactiveArea.GetComponent<NumberInput>().GetInput() == 2;
    }
}
