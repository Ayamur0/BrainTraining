using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumberInput : MonoBehaviour {
    public InputField tens;
    public InputField ones;

    public bool IsInputValid() {
        return ones.text.Length > 0 || tens.text.Length > 0;
    }

    public int GetInput() {
        if (tens.text.Length == 0)
            return int.Parse(ones.text);
        if (ones.text.Length == 0)
            return int.Parse(tens.text);
        return int.Parse(tens.text) * 10 + int.Parse(ones.text);
    }
}
