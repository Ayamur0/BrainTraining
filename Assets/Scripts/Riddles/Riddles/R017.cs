using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class R017 : Riddle {
    public override void OnEnable() {
        base.init(17);
    }

    public override bool checkResult() {
        NumberInput[] inputs = interactiveArea.GetComponents<NumberInput>();
        return inputs[0].GetInput() == 12 && inputs[1].GetInput() == 31;
    }

    public override bool isResultValid() {
        NumberInput[] inputs = interactiveArea.GetComponents<NumberInput>();
        return inputs[0].IsInputValid() && inputs[1].IsInputValid();
    }
}
