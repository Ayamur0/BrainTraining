using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class R004 : Riddle { // 35
    public override void OnEnable() {
        base.OnEnable();
        resultType = NUMBER;
        image = Resources.Load<Sprite>("RiddleAssets/004/main") as Sprite;
        description = $"Das ist ein Amida-kuji, eine sogenannte Leiter-Lotterie. \n\n"
         + $"Du musst waagerechte Linien platzieren, um die Tierkinder zu ihren Müttern zu bringen."
         + $" Dabei <color={RED}>muss das Tierkind einer waagerechten Linie folgen</color>, sobald es auf eine trifft.\n\n"
         + $"<color={RED}>Wie viele waagerechte Linien musst du mindestens</color> platzieren?";
        interactive = false;
    }

    public override bool checkResult(int result) {
        return result == 5;
    }
}
