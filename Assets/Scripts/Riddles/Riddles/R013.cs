using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class R013 : Riddle {
    public override void OnEnable() {
        base.init(13);
    }

    public override bool checkResult() {
        List<int> selected = interactiveArea.GetComponent<StaticSelection>().selectedIndices;
        return selected.Contains(1) && selected.Contains(9) && selected.Contains(11);
    }

    public override bool isResultValid() {
        return interactiveArea.GetComponent<StaticSelection>().selectedIndices.Count == 3;
    }
}
