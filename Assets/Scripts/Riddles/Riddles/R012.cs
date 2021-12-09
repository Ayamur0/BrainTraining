using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class R012 : Riddle {
    public override void OnEnable() {
        base.init(12);
    }

    public override bool checkResult() {
        List<int> selected = interactiveArea.GetComponent<StaticSelection>().selectedIndices;
        return selected.Contains(0) && selected.Contains(4) && selected.Contains(8);
    }

    public override bool isResultValid() {
        return interactiveArea.GetComponent<StaticSelection>().selectedIndices.Count == 3;
    }
}
