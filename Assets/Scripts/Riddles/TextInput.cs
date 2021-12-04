using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextInput : MonoBehaviour {
    public InputField[] letters;

    public bool IsInputValid() {
        foreach (InputField i in letters) {
            if (i.text.Length == 0)
                return false;
        }
        return true;
    }

    public string GetInput() {
        string s = "";
        foreach (InputField i in letters)
            s += i.text;
        return s.ToLower();
    }
}
