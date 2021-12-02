using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuzzerDisplayController : MonoBehaviour {
    public Image[] displays;

    public void OnBuzzerPressed(int buzzer) {
        foreach (Image d in displays)
            d.enabled = false;
        displays[buzzer].enabled = true;
    }
}
