using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class R011 : Riddle {
    public override void OnEnable() {
        base.OnEnable();
        title = "Bitte lächeln";
        points = 40;
        description = $"Ein Mädchen verkauft Eis in einem Kiosk auf einer Aussichtsplattform. \n\n"
         + $"Ein Junge mit einer Kamera kommt vorbei und macht ein Foto, auf dem ein Junge und ein Mädchen zu sehen sind.\n\n"
         + $"Wie viele <color={RED}>Personen befanden sich mindestens</color> auf der Aussichtsplattform, als das Foto gemacht wurde?";
        solution = "Alles im Fokus!\n\n Das Foto mit Junge und Mädchen zeigte das Mädchen im Kiosk und den Jungen mit der Kamera.";
        interactiveArea = Instantiate(Resources.Load<GameObject>("RiddleAssets/011/R011")) as GameObject;
    }

    public override bool checkResult() {
        return interactiveArea.GetComponent<NumberInput>().GetInput() == 2;
    }

    public override bool isResultValid() {
        return interactiveArea.GetComponent<NumberInput>().IsInputValid();
    }
}
