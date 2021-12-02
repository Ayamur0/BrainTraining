using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class R015 : Riddle { // 50
    public override void OnEnable() {
        base.OnEnable();
        resultAreaImage = Resources.Load<Sprite>("RiddleAssets/015/result") as Sprite;
        description = $"Von links nach rechts haben wir Personen A, B und C. \n\n"
         + $"<color={RED}>Finde heraus in welchem Monat sie jeweils geboren sind</color>. Dabei helfen dir ihre Aussage:\n\n"
         + $"A: \"C wurde <color={RED}>zwei Monate nach mir geboren</color>.\" \n\n"
         + $"B: \"A und mit trennen <color={RED}>6 Monate</color>.\" \n\n"
         + $"C: \"B wurde <color={RED}>in dem Monat geboren, dessen Zahl drei Mal so groß ist wie die meines Geburtsmonats</color>.\" \n\n"
         + $"Gib deine Antwort als Zahl ein (1 für Januar, 2 für Februar usw.).";

        interactiveArea = Instantiate(Resources.Load<GameObject>("RiddleAssets/015/R015")) as GameObject;
    }

    public override bool checkResult() {
        NumberInput[] inputs = interactiveArea.GetComponents<NumberInput>();
        return inputs[0].GetInput() == 12 && inputs[1].GetInput() == 6 && inputs[2].GetInput() == 2;
    }
}
