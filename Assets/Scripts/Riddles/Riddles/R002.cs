using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class R002 : Riddle {
    public override void OnEnable() {
        base.init(2);
    }

    public override bool checkResult() {
        return interactiveArea.GetComponent<NumberInput>().GetInput() == 14;
    }

    public override bool isResultValid() {
        return interactiveArea.GetComponent<NumberInput>().IsInputValid();
    }
}
