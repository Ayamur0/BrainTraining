using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RiddleLoader : MonoBehaviour {
    public bool testLoad = false;
    public Riddle testRiddle;

    public Sprite exampleResultSprite;
    public Canvas mainArea;
    public InputField mainAreaInput;
    public Canvas mainAreaInputContainer;
    public Canvas resultCanvas;
    public ResultArea resultArea;
    public Text description;

    private Riddle currentRiddle;

    // Start is called before the first frame update
    void Start() {
        resultArea = new ResultArea(resultCanvas);
        mainAreaInputContainer = mainArea.transform.GetChild(0).GetComponent<Canvas>();
        mainAreaInput = mainAreaInputContainer.transform.GetChild(0).GetComponent<InputField>();
        if (testLoad) {
            currentRiddle = ScriptableObject.CreateInstance<R001>();
            LoadRiddle(currentRiddle);
        }
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.R)) {
            Debug.Log(currentRiddle.checkResult());
        }
    }

    void LoadRiddle(Riddle riddle) {
        description.text = riddle.description;
        switch (riddle.resultType) {
            case Riddle.NONE:
                resultArea.SetImage(riddle.resultAreaImage);
                break;
            case Riddle.TEXT:
                resultArea.EnableInput();
                break;
            case Riddle.NUMBER:
                resultArea.EnableInput();
                break;
        }
        if (riddle.interactive) {
            RectTransform rectTransform = riddle.interactiveArea.GetComponent<RectTransform>();
            rectTransform.sizeDelta = mainArea.GetComponent<RectTransform>().rect.size;
            rectTransform.anchorMin = new Vector2(0.5f, 0.5f);
            rectTransform.anchorMax = new Vector2(0.5f, 0.5f);
            rectTransform.position = Vector3.zero;
            riddle.interactiveArea.transform.SetParent(mainArea.transform, false);
            mainAreaInput.text = "Test";
            mainAreaInputContainer.enabled = false;
        } else {
            mainAreaInputContainer.enabled = true;
        }
    }
}

public class ResultArea {
    public Canvas canvas;
    public Image image;
    public Canvas input;

    public ResultArea(Canvas c) {
        canvas = c;
        image = canvas.transform.GetChild(0).GetComponent<Image>();
        input = canvas.transform.GetChild(1).GetComponent<Canvas>();
    }

    public void SetImage(Sprite sprite) {
        image.enabled = true;
        image.sprite = sprite;
        input.enabled = false;
    }

    public void EnableInput() {
        input.enabled = true;
        image.enabled = false;
    }
}
