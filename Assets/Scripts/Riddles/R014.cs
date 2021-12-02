using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class R014 : Riddle { // 30
    private static int[] result = { 0, -1, 2, -1, -1, -1, -1, 1, -1 };

    public override void OnEnable() {
        base.OnEnable();
        resultAreaImage = Resources.Load<Sprite>("RiddleAssets/014/result") as Sprite;
        description = $"Ein Kindergartenkind feiert Geburtstag. \n\n"
         + $"Sein Vater hat eine Packung mit Zahlenkerzen geöffnet, um eine davon auf den Kuchen zu stecken, aber sie sind ihm heruntergefallen und jetzt kaputt.\n\n"
         + $"Wenn du, <color={RED}>drei Bruchstücke kombinierst, erhältst du die richtige Zahl</color>.\n\n"
         + $"Ziehe die Kerzenteile in das Feld rechts, um die Zahl zu bilden";

        interactiveArea = Instantiate(Resources.Load<GameObject>("RiddleAssets/014/R014")) as GameObject;
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