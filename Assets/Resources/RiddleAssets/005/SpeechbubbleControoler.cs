using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeechbubbleControoler : MonoBehaviour {
    public Image speechbubble;
    public Sprite[] speechbubbleSprites;
    public Text speechbubbleText;
    private string[] ghostTexts = { "Von uns lügt niemand!", "Ich bin der einzige, der lügt!", "Zwei von uns lügen!", "Du musst wissen, dass nicht alle lügen." };


    public void ChangeSpeechbubble(int i) {
        if (!speechbubble.enabled) {
            speechbubble.enabled = true;
        }
        speechbubble.sprite = speechbubbleSprites[i];
        speechbubbleText.text = ghostTexts[i];
    }
}
