using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class R006 : Riddle {
    public override void OnEnable() {
        base.init(6);
    }

    public override bool checkResult() {
        bool[] selected = interactiveArea.GetComponent<ToggleButtonController>().buttonStates;
        return selected[0] && !selected[1] && selected[2] && selected[3] && !selected[4];
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
