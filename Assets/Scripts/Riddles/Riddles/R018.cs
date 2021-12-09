using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class R018 : Riddle {
    public override void OnEnable() {
        base.init(18);
    }

    public override bool checkResult() {
        return interactiveArea.GetComponent<TextInput>().GetInput() == "cabbac";
    }

    public override bool isResultValid() {
        return interactiveArea.GetComponent<TextInput>().IsInputValid();
    }
}
