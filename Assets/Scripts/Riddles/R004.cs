using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class R004 : Riddle {
    public override void OnEnable() {
        base.OnEnable();
        title = "Wiedervereint";
        points = 35;
        description = $"Das ist ein Amida-kuji, eine sogenannte Leiter-Lotterie. \n\n"
         + $"Du musst waagerechte Linien platzieren, um die Tierkinder zu ihren Müttern zu bringen."
         + $" Dabei <color={RED}>muss das Tierkind einer waagerechten Linie folgen</color>, sobald es auf eine trifft.\n\n"
         + $"<color={RED}>Wie viele waagerechte Linien musst du mindestens</color> platzieren?";
        solution = "Alle glücklich vereint!\n\nWas sind sie doch froh, wieder bei ihren Müttern zu sein. Es gibt mehrere Möglichkeiten, die fünd waagerechten Linien zu platzieren.";
        interactiveArea = Instantiate(Resources.Load<GameObject>("RiddleAssets/004/R004")) as GameObject;
    }

    public override bool checkResult() {
        return interactiveArea.GetComponent<NumberInput>().GetInput() == 5;
    }

    public override bool isResultValid() {
        return interactiveArea.GetComponent<NumberInput>().IsInputValid();
    }
}
