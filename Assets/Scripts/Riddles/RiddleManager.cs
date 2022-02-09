using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RiddleManager : MonoBehaviour {
    [HideInInspector]
    public static int riddleId = 1;

    public Canvas mainArea;
    public Image resultImage;
    public ResultArea resultArea;
    public Text description;
    public Canvas solution;
    public Text solutionText;
    public Image solutionImage;
    public Button submitButton;

    [HideInInspector]
    public static Riddle currentRiddle;

    // Start is called before the first frame update
    void Start() {
        resultArea = new ResultArea(resultImage);
        LoadRiddle(riddleId);
    }

    void Update() {
        if (currentRiddle == null)
            return;
        if (currentRiddle.info.autoSubmit && !solution.enabled && currentRiddle.checkResult())
            SubmitSolution();
        if (Input.GetKeyDown(KeyCode.R)) {
            Debug.Log(currentRiddle.checkResult());
        }
        Color color = submitButton.image.color;
        if (currentRiddle.isResultValid()) {
            color.a = 1f;
            submitButton.enabled = true;
        } else {
            color.a = 0.5f;
            submitButton.enabled = false;
        }
        submitButton.image.color = color;
    }

    void LoadRiddle(int id) {
        solution.enabled = false;
        if (currentRiddle != null)
            currentRiddle.Destroy();
        currentRiddle = ScriptableObject.CreateInstance("R" + id.ToString("000")) as Riddle;
        description.text = currentRiddle.info.description;
        if (currentRiddle.info.autoSubmit)
            submitButton.gameObject.SetActive(false);
        else
            submitButton.gameObject.SetActive(true);
        if (currentRiddle.resultAreaImage != null)
            resultArea.SetImage(currentRiddle.resultAreaImage);
        else
            resultArea.SetStandardImage();
        RectTransform rectTransform = currentRiddle.interactiveArea.GetComponent<RectTransform>();
        rectTransform.sizeDelta = mainArea.GetComponent<RectTransform>().rect.size;
        rectTransform.anchorMin = new Vector2(0.5f, 0.5f);
        rectTransform.anchorMax = new Vector2(0.5f, 0.5f);
        rectTransform.position = Vector3.zero;
        currentRiddle.interactiveArea.transform.SetParent(mainArea.transform, false);
    }

    public void LoadNextRiddle() {
        RiddleManager.riddleId = currentRiddle.info.id + 1;
        LoadRiddle(currentRiddle.info.id + 1);
    }

    public void SubmitSolution() {
        if (currentRiddle.checkResult()) {
            ShowSolution();
            SolutionScene.success = true;
        } else {
            SolutionScene.success = false;
        }
        SceneManager.LoadScene("RiddleSolution", LoadSceneMode.Additive);
    }

    void ShowSolution() {
        solution.enabled = true;
        solutionText.text = currentRiddle.info.solution;
        solutionImage.sprite = currentRiddle.solutionSprite;
    }


    public void LoadMenu() {
        SceneManager.LoadScene("RiddleMenu");
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

