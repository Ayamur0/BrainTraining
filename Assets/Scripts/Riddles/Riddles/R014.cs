using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class R014 : Riddle {
    private static int[] result = { 0, -1, 2, -1, -1, -1, -1, 1, -1 };

    public override void OnEnable() {
        base.init(14);
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
        int unusedTiles = 0;
        SnapDragController.Tile[] tiles = interactiveArea.transform.GetComponent<SnapDragController>().tiles;
        for (int i = 0; i < result.Length; i++) {
            if (tiles[i].occupiedLocationIndex == -1)
                unusedTiles++;
        }
        return unusedTiles == 6;
    }
}
