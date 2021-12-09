using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class R003 : Riddle {
    public override void OnEnable() {
        base.init(3);
    }

    public override bool checkResult() {
        List<int> selected = interactiveArea.GetComponent<StaticSelection>().selectedIndices;
        return selected.Contains(1) && selected.Contains(2);
    }

    public override bool isResultValid() {
        return interactiveArea.GetComponent<StaticSelection>().selectedIndices.Count == 2;
    }
}
