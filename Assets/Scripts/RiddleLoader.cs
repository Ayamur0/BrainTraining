using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RiddleLoader : MonoBehaviour {
    public bool testLoad = false;
    public Riddle testRiddle;

    public Sprite exampleResultSprite;
    public Canvas mainArea;
    public Image mainImage;
    public Canvas resultCanvas;
    public ResultArea resultArea;
    public Text description;
    public Canvas solution;
    public Button submitButton;

    private Riddle currentRiddle;

    // Start is called before the first frame update
    void Start() {
        resultArea = new ResultArea(resultCanvas);

        if (testLoad) {
            currentRiddle = ScriptableObject.CreateInstance<R002>();
            // LoadRiddle(currentRiddle);
        }
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.R)) {
            Debug.Log(currentRiddle.checkResult());
        }
        // TODO move to on input changed
        Color color = submitButton.image.color;
        if (currentRiddle.resultType == Riddle.NUMBER && resultArea.IsInputValid())
            color.a = 1f;
        else
            color.a = 0.5f;
        submitButton.image.color = color;
    }

    void LoadRiddle(Riddle riddle) {
        description.text = riddle.description;
        switch (riddle.resultType) {
            case Riddle.NONE:
                resultArea.SetImage(riddle.image);
                resultArea.DisableInput();
                submitButton.gameObject.SetActive(false);
                break;
            case Riddle.TEXT:
                resultArea.SetStandardImage();
                resultArea.EnableInput();
                submitButton.gameObject.SetActive(true);
                break;
            case Riddle.NUMBER:
                resultArea.SetStandardImage();
                resultArea.EnableInput();
                submitButton.gameObject.SetActive(true);
                break;
        }
        if (riddle.interactive) {
            RectTransform rectTransform = riddle.interactiveArea.GetComponent<RectTransform>();
            rectTransform.sizeDelta = mainArea.GetComponent<RectTransform>().rect.size;
            rectTransform.anchorMin = new Vector2(0.5f, 0.5f);
            rectTransform.anchorMax = new Vector2(0.5f, 0.5f);
            rectTransform.position = Vector3.zero;
            riddle.interactiveArea.transform.SetParent(mainArea.transform, false);
            mainImage.enabled = false;
        } else {
            mainImage.sprite = riddle.image;
            mainImage.enabled = true;
        }
    }

    void ShowSolution(string text) {
        solution.GetComponent<Text>().text = text;
        solution.enabled = true;
    }
}

public class ResultArea {
    private Canvas canvas;
    private Image image;
    private Sprite standardBackground;
    private Canvas inputContainer;
    private InputField tens;
    private InputField ones;

    public ResultArea(Canvas c) {
        canvas = c;
        image = canvas.transform.GetChild(0).GetComponent<Image>();
        standardBackground = image.sprite;
        inputContainer = canvas.transform.GetChild(1).GetComponent<Canvas>();
        tens = inputContainer.GetComponentsInChildren<InputField>()[0];
        ones = inputContainer.GetComponentsInChildren<InputField>()[1];
    }

    public void SetStandardImage() {
        image.sprite = standardBackground;
    }

    public void SetImage(Sprite sprite) {
        image.sprite = sprite;
    }

    public void EnableInput() {
        inputContainer.enabled = true;
    }

    public void DisableInput() {
        inputContainer.enabled = false;
    }

    public bool IsInputValid() {
        return ones.text.Length > 0;
    }

    public int GetInput() {
        return int.Parse(tens.text) * 10 + int.Parse(ones.text);
    }
}
