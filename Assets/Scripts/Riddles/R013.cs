using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class R013 : Riddle {
    public override void OnEnable() {
        base.OnEnable();
        resultAreaImage = Resources.Load<Sprite>("RiddleAssets/013/result") as Sprite;
        title = "Die Schatzkarte";
        points = 45;
        description = "Du hast eine Schatzkarte gefunden, die mehrere Inseln mit unerschiedlichen Ruinen zeigt. \n\n"
         + $"Der Schatz befindet sich in der Mitte eines gleichseitigen Dreiecks, das drei Insel verbindet, auf denen "
         + $"<color={RED}>verschieden geformte Ruinen liegen</color>.\n\n"
         + $"Klicke die drei Inseln an, die zeigen, wo such der Schatz befinden, um deine Antwort zu geben. Klicke eine Insel erneut an um die Auswahl zu löschen.\n\n"
         + "Der Abstand zwischen den Punkten auf der Karte ist immer gleich groß.";
        solution = "Schatzjagd erfolgreich!\n\nDie Mitte des Dreiecks liegt in der Mitte des Meeres. Du hast Ruinen auf dem Meeresboden gefunden!";

        interactiveArea = Instantiate(Resources.Load<GameObject>("RiddleAssets/013/R013")) as GameObject;
    }

    public override bool checkResult() {
        List<int> selected = interactiveArea.GetComponent<StaticSelection>().selectedIndices;
        return selected.Contains(1) && selected.Contains(9) && selected.Contains(11);
    }

    public override bool isResultValid() {
        return interactiveArea.GetComponent<StaticSelection>().selectedIndices.Count == 3;
    }
}
