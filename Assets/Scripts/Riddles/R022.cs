using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class R022 : Riddle { // 35
    public override void OnEnable() {
        base.OnEnable();
        title = "Wahrheit, Lügen und ein paar Bälle";
        points = 50;
        description = $"Vier Personen (A, B, C und D) unterhalten sich neben einer Kiste mit einem Raster aus 4 x 4 Feldern. \n\n"
         + $"A sagt: \"In jeder vertikalen Reihe befinden sich zwei Bälle.\" \n\n"
         + $"B sagt: \"In jeder horizontalen Reihe befindet sich ein Ball.\" \n\n"
         + $"C sagt: \"In jeder der vier Ecken befindet sich ein Ball.\" \n\n"
         + $"D sagt: \"Der einzige Lügner hier ist A.\" \n\n"
         + $"<color={RED}>Zwei der vier Personen lügen</color>. In jedes Feld passt ein Ball, aber wie viele Bälle befinden sich insgesamt in der Kiste?";
        solution = "Es sind insgesamt acht Bälle. Die Geschichten von A und C passen zueinander, B und D lügen. Ehrlich währt am längsten!";
        interactiveArea = Instantiate(Resources.Load<GameObject>("RiddleAssets/022/R022")) as GameObject;
    }

    public override bool checkResult() {
        return interactiveArea.GetComponent<NumberInput>().GetInput() == 8;
    }

    public override bool isResultValid() {
        return interactiveArea.GetComponent<NumberInput>().IsInputValid();
    }
}
