using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class R018 : Riddle { // 40
    public override void OnEnable() {
        base.OnEnable();
        description = $"Wie war gleich noch das Passwrot für den Tresor?. \n\n"
         + $"<color={RED}>Es is sechstellig und besteht aus den Buchstaben A, B und C</color>. \n\n"
         + $"Nutze die Hinweise und finde das Passwort heraus: \n\n"
         + $"C kann nicht neben einem anderen C pder einem B vorkommen.\n\n"
         + $"Derselbe Buchstabe wird nie mehr als zweimal genutzt.\n\n"
         + $"Das Passwort liest sich vorwärts und rückwärts gleich.";

        interactiveArea = Instantiate(Resources.Load<GameObject>("RiddleAssets/018/R018")) as GameObject;
    }

    public override bool checkResult() {
        return interactiveArea.GetComponent<TextInput>().GetInput() == "cabbac";
    }
}
