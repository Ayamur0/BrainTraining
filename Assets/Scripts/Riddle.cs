using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Riddle : ScriptableObject {
    public const string RED = "#b83e39";

    public int resultType;
    public Sprite resultAreaImage;
    public string description;
    public GameObject interactiveArea;
    public bool autoSubmit = false;

    virtual public void OnEnable() {
    }

    virtual public bool checkResult() { return false; }

    virtual public bool isResultValid() { return false; }

}
