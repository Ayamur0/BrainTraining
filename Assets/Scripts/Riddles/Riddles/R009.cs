using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class R009 : Riddle {
    public override void OnEnable() {
        base.init(9);
    }

    public override bool checkResult() {
        return interactiveArea.GetComponent<TextInput>().GetInput() == "bbcabb";
    }

    public override bool isResultValid() {
        return interactiveArea.GetComponent<TextInput>().IsInputValid();
    }
}
