using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class R020 : Riddle {
    private static Vector2 result = new Vector2(-36, 12.5f);

    public override void OnEnable() {
        base.init(20);
    }

    public override bool checkResult() {
        Image marker = interactiveArea.transform.GetChild(0).GetComponent<DynamicSelection>().marker;
        return Vector2.Distance(marker.transform.localPosition, result) < 7;
    }

    public override bool isResultValid() {
        return true;
    }
}
