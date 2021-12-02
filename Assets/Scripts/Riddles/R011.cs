using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class R011 : Riddle { // 40
    public override void OnEnable() {
        base.OnEnable();
        description = $"Ein Mädchen verkauf Eis in einem Kiosk auf einer Aussichtsplattform. \n\n"
         + $"Ein Junge mit einer Kamera kommt vorbei und macht ein Foto, auf dem ein Junge und ein Mädchen zu sehen sind.\n\n"
         + $"Wie viele <color={RED}>Personen befanden sich mindestens</color> auf der Aussichtsplattform, als das Foto gemacht wurde?";
        interactiveArea = Instantiate(Resources.Load<GameObject>("RiddleAssets/011/R011")) as GameObject;
    }

    public override bool checkResult() {
        return interactiveArea.GetComponent<NumberInput>().GetInput() == 2;
    }
}
