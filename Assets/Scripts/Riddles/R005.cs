using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class R005 : Riddle { // 50
    public override void OnEnable() {
        base.OnEnable();
        resultType = SUBMIT;
        image = Resources.Load<Sprite>("RiddleAssets/005/result") as Sprite;
        description = $"Ein paar freche Gespenster möchten mit dir spielen: Du musst Ihnen zuhören und <color={RED}>herausfinden, wer lügt</color>. \n\n"
         + $"Offenbar sagen <color={RED}>höchstens zwei</color> von ihnen nicht die Wahrheit.\n\n"
         + "Klicke auf ein Gespenst, um zu hören, was es zu sagen hat.";

        interactive = true;
        interactiveArea = Instantiate(Resources.Load<GameObject>("RiddleAssets/005/R005")) as GameObject;
    }

    public override bool checkResult() {
        bool[] selected = interactiveArea.GetComponent<ToggleButtonController>().buttonStates;
        return selected[0] && selected[1] && !selected[2] && !selected[3];
    }
}
