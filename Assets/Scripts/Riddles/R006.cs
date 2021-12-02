using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class R006 : Riddle { // 45
    public override void OnEnable() {
        base.OnEnable();
        resultAreaImage = Resources.Load<Sprite>("RiddleAssets/006/result") as Sprite;
        description = $"Hinter dem Vorhang ist eine Silhouette von etwas. \n\n"
         + $"Sie stammt <color={RED}>von drei Statuen</color>, aber von welchen?\n\n"
         + "Schaue dir die fünf Statuen an und wähle aus, welche sich hinter dem Vorhang befinden. Die Statuen können"
         + " nicht auseinandergebaut werden und müssen als Ganzes verwendet werden.";

        interactiveArea = Instantiate(Resources.Load<GameObject>("RiddleAssets/006/R006")) as GameObject;
    }

    public override bool checkResult() {
        bool[] selected = interactiveArea.GetComponent<ToggleButtonController>().buttonStates;
        return selected[0] && !selected[1] && selected[2] && selected[3] && !selected[4];
    }
}
