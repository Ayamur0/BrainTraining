using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class R019 : Riddle {
    private static int[,] defaultField = new int[5, 5] { { 0, 0, 0, 0, 0 }, { 0, -1, 0, 0, 0 }, { -1, 0, 0, 0, 0 }, { 0, -1, 0, 0, -1 }, { 0, 0, 0, 0, 0 } };
    private int[,] field = defaultField.Clone() as int[,];
    private int[] indexMap = new int[21] { 0, 1, 2, 3, 4, 5, 7, 8, 9, 11, 12, 13, 14, 15, 17, 18, 20, 21, 22, 23, 24 };
    public override void OnEnable() {
        base.OnEnable();
        resultAreaImage = Resources.Load<Sprite>("RiddleAssets/019/result") as Sprite;
        title = "Auseinander, ihr Ziegen!";
        points = 45;
        description = $"Wir haben hier neun Ziegen, die sich nicht vertragen. \n\n"
         + $"Wenn die merken, <color={RED}>dass sie in einem Abstand von nur zwei Feldern zueinander sind - vertikal oder horionzal -</color>, "
         + $"fangen sie Streit an. Zum Glück streiten sie nicht, wenn sie diagonal zueinander sind oder ein Felsen sie trennt.\n\n"
         + $"<color={RED}>Kannst die sie so stellen, dass sie sich nicht streiten?</color>\n\n"
         + $"Ziehe sie, um sie zu bewegen, und platziere sie dort, wo sie deiner Meinung nach am besten auf der Farm aufgehoben sind.";
        solution = "Die Stimmung auf der Farm ist jetzt ruhig und entspannt. Auch die Ziegen scheinen glücklich zu sein. Die Nähe der Felsen scheint eine besänftigende Wirkung auf sie zu haben.";

        interactiveArea = Instantiate(Resources.Load<GameObject>("RiddleAssets/019/R019")) as GameObject;
        Vector2 firstLocation = new Vector2(-21.2f, 87.4f);
        Vector2 xyChange = new Vector2(44, -47.4f);
        Vector2[] locations = new Vector2[21];
        int c = 0;
        for (int i = 0; i < field.GetLength(0); i++) {
            for (int j = 0; j < field.GetLength(0); j++) {
                if (field[i, j] == 0) {
                    locations[c] = new Vector2(firstLocation.x + j * xyChange.x, firstLocation.y + i * xyChange.y);
                    c++;
                }
            }
        }
        interactiveArea.transform.GetComponent<SnapDragController>().locations = locations;
        interactiveArea.transform.GetComponent<SnapDragController>().Start();
    }

    public override bool checkResult() {
        field = defaultField.Clone() as int[,];
        SnapDragController.Tile[] tiles = interactiveArea.transform.GetComponent<SnapDragController>().tiles;
        foreach (SnapDragController.Tile t in tiles) {
            if (t.occupiedLocationIndex == -1)
                return false;
            int index = indexMap[t.occupiedLocationIndex];
            field[index / 5, index % 5] = 1;
        }
        for (int i = 0; i < field.GetLength(0); i++) {
            Debug.Log(field[i, 0] + " " + field[i, 1] + " " + field[i, 2] + " " + field[i, 3] + " " + field[i, 4]);
        }
        return checkGoatPlacement();
    }

    public override bool isResultValid() {
        SnapDragController.Tile[] tiles = interactiveArea.transform.GetComponent<SnapDragController>().tiles;
        for (int i = 0; i < tiles.Length; i++) {
            if (tiles[i].occupiedLocationIndex == -1)
                return false;
        }
        return true;
    }

    private bool checkGoatPlacement() {
        for (int i = 0; i < field.GetLength(0); i++) {
            for (int j = 0; j < field.GetLength(0); j++) {
                if (field[i, j] == 1 && !goatPlacementValid(i, j))
                    return false;
            }
        }
        return true;
    }

    private bool goatPlacementValid(int i, int j) {
        if (!isStone(i - 1, j))
            if (isGoat(i - 1, j) || isGoat(i - 2, j))
                return false;
        if (!isStone(i + 1, j))
            if (isGoat(i + 1, j) || isGoat(i + 2, j))
                return false;
        if (!isStone(i, j - 1))
            if (isGoat(i, j - 1) || isGoat(i, j - 2))
                return false;
        if (!isStone(i, j + 1))
            if (isGoat(i, j + 1) || isGoat(i, j + 2))
                return false;
        return true;
    }

    private bool isStone(int i, int j) {
        if (i < 0 || j < 0 || i >= field.GetLength(0) || j >= field.GetLength(0))
            return false;
        Debug.Log("IsStone " + i + " " + j + " " + (field[i, j] == -1));
        return field[i, j] == -1;
    }

    private bool isGoat(int i, int j) {
        if (i < 0 || j < 0 || i >= field.GetLength(0) || j >= field.GetLength(0))
            return false;
        Debug.Log("IsGoat " + i + " " + j + " " + (field[i, j] == 1));
        return field[i, j] == 1;
    }
}
