using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class R017 : Riddle { // 50
    public override void OnEnable() {
        base.OnEnable();
        description = $"Ein Mann und seine Frau haben eine seltsame Unterhaltung. \n\n"
         + $"Der Mann sagt zu seiner Frau: \"Es war unser <color={RED}>siebter Hochzeitstag</color> am 30. Juni <color={RED}>letzten Jahres</color>, und unser "
         + $"<color={RED}>zehnter Hochzeitstag ist im nächsten Jahr</color>.\"\n\n"
         + $"An welchem <color={RED}>Tag haben sie diese Unterhaltung begonnen</color>?";
        interactiveArea = Instantiate(Resources.Load<GameObject>("RiddleAssets/017/R017")) as GameObject;
    }

    public override bool checkResult() {
        NumberInput[] inputs = interactiveArea.GetComponents<NumberInput>();
        return inputs[0].GetInput() == 12 && inputs[1].GetInput() == 31;
    }
}
