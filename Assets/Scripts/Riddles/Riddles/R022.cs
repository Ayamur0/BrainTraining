using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class R022 : Riddle {
    public override void OnEnable() {
        base.init(22);
    }

    public override bool checkResult() {
        return interactiveArea.GetComponent<NumberInput>().GetInput() == 8;
    }

    public override bool isResultValid() {
        return interactiveArea.GetComponent<NumberInput>().IsInputValid();
    }
}
