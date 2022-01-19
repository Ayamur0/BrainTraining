using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
    public Canvas Popup;
    public Text RiddlePoints;
    public Text Stars;

    void Start() {
        SaveDataManager.LoadGame();
        SetTexts();
    }

    void SetTexts() {
        RiddlePoints.text = SaveDataManager.RiddleSaveData.TotalPoints + "/950";
        Stars.text = SaveDataManager.RiddleSaveData.stars.ToString();
    }

    public void OpenPopup() {
        Popup.enabled = true;
    }

    public void ClosePopup() {
        Popup.enabled = false;
    }

    public void DeleteSaveData() {
        SaveDataManager.ResetData();
        SetTexts();
        ClosePopup();
    }

    public void SwitchToRiddleScene() {
        SceneManager.LoadScene("RiddleMenu");
    }

    public void SwitchToLearnScrene() {
        SceneManager.LoadScene("MenuLearning");
    }

    public void CloseGame() {
        SaveDataManager.SaveGame();
        Application.Quit();
    }
}
