using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RiddleLoader : MonoBehaviour {
    public bool testLoad = false;
    public Riddle testRiddle;

    public Canvas mainArea;
    public Image resultImage;
    public ResultArea resultArea;
    public Text description;
    public Canvas solution;
    public Button submitButton;

    private Riddle currentRiddle;

    // Start is called before the first frame update
    void Start() {
        resultArea = new ResultArea(resultImage);

        if (testLoad) {
            currentRiddle = ScriptableObject.CreateInstance<R017>();
            LoadRiddle(currentRiddle);
        }
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.R)) {
            Debug.Log(currentRiddle.checkResult());
        }
        Color color = submitButton.image.color;
        if (currentRiddle.isResultValid())
            color.a = 1f;
        else
            color.a = 0.5f;
        submitButton.image.color = color;
    }

    void LoadRiddle(Riddle riddle) {
        description.text = riddle.description;
        if (riddle.autoSubmit)
            submitButton.gameObject.SetActive(false);
        else
            submitButton.gameObject.SetActive(true);
        if (riddle.resultAreaImage != null)
            resultArea.SetImage(riddle.resultAreaImage);
        else
            resultArea.SetStandardImage();
        RectTransform rectTransform = riddle.interactiveArea.GetComponent<RectTransform>();
        rectTransform.sizeDelta = mainArea.GetComponent<RectTransform>().rect.size;
        rectTransform.anchorMin = new Vector2(0.5f, 0.5f);
        rectTransform.anchorMax = new Vector2(0.5f, 0.5f);
        rectTransform.position = Vector3.zero;
        riddle.interactiveArea.transform.SetParent(mainArea.transform, false);
    }

    void ShowSolution(string text) {
        solution.GetComponent<Text>().text = text;
        solution.enabled = true;
    }

    public class ResultArea {
        private Image backgroundImage;
        private Sprite standardBackground;

        public ResultArea(Image b) {
            backgroundImage = b;
            standardBackground = backgroundImage.sprite;
        }

        public void SetStandardImage() {
            backgroundImage.sprite = standardBackground;
        }

        public void SetImage(Sprite sprite) {
            backgroundImage.sprite = sprite;
        }
    }
}

