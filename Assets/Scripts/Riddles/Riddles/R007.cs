using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class R007 : Riddle { // 25
    private static Vector2 result = new Vector2(128, 58);

    public override void OnEnable() {
        base.init(7);
    }

    public override bool checkResult() {
        Image marker = interactiveArea.transform.GetChild(0).GetComponent<DynamicSelection>().marker;
        return Vector2.Distance(marker.transform.localPosition, result) < 10;
    }

    public override bool isResultValid() {
        return true;
    }
}
