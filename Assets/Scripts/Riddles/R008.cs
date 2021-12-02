using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class R008 : Riddle { // 55
    private static int[] result = { 1, 0, 4, 2, 3 };

    public override void OnEnable() {
        base.OnEnable();
        resultAreaImage = Resources.Load<Sprite>("RiddleAssets/008/result") as Sprite;
        description = $"Die schwarzen Gespenster wandeln auf weißen Wegen, die weißen Gespenster auf schwarzen. \n\n"
         + $"Sie wurden im Schwarz-Weiß-Labyrinth von ihren Freunden getrennt.\n\n"
         + $"Verwende die fünf Felder, um <color={RED}>die Wege zu verbinden</color> damit die <color={RED}>weißen Gespenster vereint werden</color> und die "
         + $"<color={RED}>schwarzen Gespenster ebenso</color>.\n\n"
         + "Ziehe die Felder in das Labyrinth im rechten Bild und vervollständige es.";

        interactiveArea = Instantiate(Resources.Load<GameObject>("RiddleAssets/008/R008")) as GameObject;
    }

    public override bool checkResult() {
        SnapDragController.Tile[] tiles = interactiveArea.transform.GetComponent<SnapDragController>().tiles;
        for (int i = 0; i < result.Length; i++) {
            if (tiles[i].occupiedLocationIndex != result[i])
                return false;
        }
        return true;
    }
}
