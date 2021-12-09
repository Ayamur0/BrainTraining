using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class R004 : Riddle {
    public override void OnEnable() {
        base.init(4);
    }

    public override bool checkResult() {
        return interactiveArea.GetComponent<NumberInput>().GetInput() == 5;
    }

    public override bool isResultValid() {
        return interactiveArea.GetComponent<NumberInput>().IsInputValid();
    }
}
