using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class R023 : Riddle {
    private static int[] resultIndices = { 3, -1, 0, 2, 1 };

    public override void OnEnable() {
        base.OnEnable();
        resultAreaImage = Resources.Load<Sprite>("RiddleAssets/023/result") as Sprite;
        title = "Das Rätsel der Hoffnung";
        points = 45;
        description = $"Auf dem Tisch stehen fünf Platten aus Buntglas. \n\n"
         + $"<color={RED}>Stelle vier von ihnen auf dem Tisch auf</color> und verwende das Licht der Kerzen, damit das englisch Wort \"<color={RED}>HOPE</color>\" für Hoffnugn zu sehen ist.\n\n"
         + $"Ziehe die Platten, um sie zu bewegen, und stelle sie der Reihe nach in die Rahmen, um das Rätsel zu lösen.\n\n"
         + $"Klicke sie kurz an, um sie zu drehen.";
        solution = "So macht man Hoffnung! \n\n HOPE...\n Die Platten zeigen die Buchstaben, wenn das Licht der Kerzen durch sie scheint. Da wird einem ganz warm ums Herz.";

        interactiveArea = Instantiate(Resources.Load<GameObject>("RiddleAssets/023/R023")) as GameObject;
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
        for (int i = 0; i < tiles.Length; i++) {
            if (tiles[i].occupiedLocationIndex == -1)
                unusedTiles++;
        }
        return unusedTiles == 1;
    }
}
