using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Riddle {
    public const int NONE = 0;
    public const int TEXT = 1;
    public const int NUMBER = 2;

    public int resultType;
    public Sprite resultAreaImage;
    public string description;
    public bool interactive;
    public Canvas interactiveArea;

    public Riddle() {
        GameObject temp = new GameObject();
        interactiveArea = temp.AddComponent<Canvas>();
        temp.AddComponent<GraphicRaycaster>();
    }
}
