using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleButtonController : MonoBehaviour {
    public Sprite offSprite;
    public Sprite onSprite;
    public Button[] buttons;
    public bool[] buttonStates;

    void Start() {
        buttonStates = new bool[buttons.Length];
        for (int i = 0; i < buttons.Length; i++)
            buttonStates[i] = false;
    }

    public void ChangeImage(int i) {
        if (buttonStates[i]) {
            buttonStates[i] = false;
            buttons[i].GetComponent<Image>().sprite = offSprite;
        } else {
            buttonStates[i] = true;
            buttons[i].GetComponent<Image>().sprite = onSprite;
        }
    }
}
