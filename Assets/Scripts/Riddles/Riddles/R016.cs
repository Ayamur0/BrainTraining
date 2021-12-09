using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class R016 : Riddle {
    public override void OnEnable() {
        base.init(16);
    }

    public override bool checkResult() {
        return interactiveArea.GetComponent<NumberInput>().GetInput() == 18;
    }

    public override bool isResultValid() {
        return interactiveArea.GetComponent<NumberInput>().IsInputValid();
    }
}
