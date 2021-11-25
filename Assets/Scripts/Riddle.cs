using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Riddle : ScriptableObject {
    public const int NONE = 0;
    public const int TEXT = 1;
    public const int NUMBER = 2;

    public int resultType;
    public Sprite resultAreaImage;
    public string description;
    public bool interactive;
    public GameObject interactiveArea;

    virtual public void OnEnable() {
    }

    virtual public bool checkResult() { return false; }
}
