using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RiddleSelection : MonoBehaviour {
    public Transform contentContainer;
    public GameObject listElement;
    // Start is called before the first frame update
    void Start() {
        for (int i = 1; i <= RiddleInfo.RiddleAmount; i++) {
            RiddleInfo.SimpleRiddleInfo info = RiddleInfo.loadSimpleInfoFromXML(i);
            GameObject temp = Instantiate(listElement);
            temp.GetComponent<Button>().onClick.AddListener(() => loadRiddleScene(info.id));
            temp.transform.GetChild(0).GetComponent<Text>().text = info.id.ToString("000");
            temp.transform.GetChild(1).GetComponent<Text>().text = info.title;
            temp.transform.GetChild(2).GetComponent<Text>().text = info.points + "/" + info.maxPoints;
            temp.transform.GetChild(3).GetComponent<Image>().enabled = info.completed;
            temp.transform.SetParent(contentContainer);
            temp.transform.localScale = Vector2.one;
        }
    }

    void loadRiddleScene(int riddleId) {
        RiddleManager.riddleId = riddleId;
        SceneManager.LoadScene("Riddle");
    }

    public void loadMainMenuScene() {
        SceneManager.LoadScene("MainMenu");
    }
}
