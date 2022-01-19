using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class R023 : Riddle {
    private static int[] resultIndices = { 3, -1, 0, 2, 1 };

    public override void OnEnable() {
        base.init(23);
    }

    public override bool checkResult() {
        SnapDragController.Tile[] tiles = interactiveArea.transform.GetComponent<SnapDragController>().tiles;
        for (int i = 0; i < resultIndices.Length; i++) {
            if (tiles[i].occupiedLocationIndex != resultIndices[i])
                return false;
        }
        if (tiles[0].image.transform.rotation.eulerAngles.z % 360 != 270)
            return false;
        if (tiles[2].image.transform.rotation.eulerAngles.z % 360 != 90 && tiles[2].image.transform.rotation.eulerAngles.z % 360 != 270)
            return false;
        if (tiles[3].image.transform.rotation.eulerAngles.z % 360 != 270)
            return false;
        return true;
    }

    public override bool isResultValid() {
        int unusedTiles = 0;
        SnapDragController.Tile[] tiles = interactiveArea.transform.GetComponent<SnapDragController>().tiles;
        if (tiles == null)
            return false;
        for (int i = 0; i < tiles.Length; i++) {
            if (tiles[i].occupiedLocationIndex == -1)
                unusedTiles++;
        }
        return unusedTiles == 1;
    }
}
