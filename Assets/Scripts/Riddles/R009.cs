using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class R009 : Riddle {
    public override void OnEnable() {
        base.OnEnable();
        title = "Passwort-ABC";
        points = 40;
        description = $"Wie war gleich noch das Passwort für den Tresor?. \n\n"
         + $"<color={RED}>Es is sechstellig und besteht aus den Buchstaben A, B und C</color>. \n\n"
         + $"Nutze die Hinweise und finde das Passwort heraus: \n\n"
         + $"Es gibt zwei Stellen, an denen derselbe Buchstabe zweimal hintereinander vorkommt.\n\n"
         + $"A und C kommen gleich häufig vor, aber zussammen weniger oft als B.\n\n"
         + $"Auf ein C folgt immer ein A.";
        solution = "Panzerknacker!\n\nDas Licht leuchtet auf, und der Tresor öffnet sich! Was da wohl drin ist...?";

        interactiveArea = Instantiate(Resources.Load<GameObject>("RiddleAssets/009/R009")) as GameObject;
    }

    public override bool checkResult() {
        return interactiveArea.GetComponent<TextInput>().GetInput() == "bbacbb";
    }

    public override bool isResultValid() {
        return interactiveArea.GetComponent<TextInput>().IsInputValid();
    }
}
