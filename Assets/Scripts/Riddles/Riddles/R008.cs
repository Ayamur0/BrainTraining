using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class R008 : Riddle {
    private static int[] result = { 1, 0, 4, 2, 3 };

    public override void OnEnable() {
        base.init(8);
    }

    public override bool checkResult() {
        SnapDragController.Tile[] tiles = interactiveArea.transform.GetComponent<SnapDragController>().tiles;
        for (int i = 0; i < result.Length; i++) {
            if (tiles[i].occupiedLocationIndex != result[i])
                return false;
        }
        return true;
    }

    public override bool isResultValid() {
        SnapDragController.Tile[] tiles = interactiveArea.transform.GetComponent<SnapDragController>().tiles;
        for (int i = 0; i < result.Length; i++) {
            if (tiles[i].occupiedLocationIndex == -1)
                return false;
        }
        return true;
    }
}
