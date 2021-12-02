using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class R005 : Riddle {
    public override void OnEnable() {
        base.OnEnable();
        resultAreaImage = Resources.Load<Sprite>("RiddleAssets/005/result") as Sprite;
        title = "Verlogene Phantome";
        points = 50;
        description = $"Ein paar freche Gespenster möchten mit dir spielen: Du musst Ihnen zuhören und <color={RED}>herausfinden, wer lügt</color>. \n\n"
         + $"Offenbar sagen <color={RED}>höchstens zwei</color> von ihnen nicht die Wahrheit.\n\n"
         + "Klicke auf ein Gespenst, um zu hören, was es zu sagen hat.";
        solution = "Perfekt durchschaut!\n\nAund B haben gelogen. Denen hat das Spiel so richtig Spaß gemacht. Offenbar sind sie noch lange nicht fertig!";

        interactiveArea = Instantiate(Resources.Load<GameObject>("RiddleAssets/005/R005")) as GameObject;
    }

    public override bool checkResult() {
        bool[] selected = interactiveArea.GetComponent<ToggleButtonController>().buttonStates;
        return selected[0] && selected[1] && !selected[2] && !selected[3];
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
