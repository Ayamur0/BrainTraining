using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SolutionScene : MonoBehaviour {
    public Canvas BackgroundSuccess;
    public Canvas BackgroundFailure;

    public Text TotalPoints;
    public Text RemainingPoints;
    public Text EarnedPoints;

    public static bool success = true;

    // Start is called before the first frame update
    void Start() {
        BackgroundSuccess.enabled = false;
        BackgroundFailure.enabled = false;
        if (success) {
            TotalPoints.text = SaveDataManager.RiddleSaveData.TotalPoints.ToString();
            EarnedPoints.text = SaveDataManager.RiddleSaveData.GetRemainingPoints(RiddleManager.riddleId).ToString();
            SaveDataManager.RiddleSaveData.UpdateRemainingPoints(RiddleManager.riddleId, 0);
            AudioClip audio = Resources.Load<AudioClip>($"RiddleAssets/success") as AudioClip;
            BackgroundSuccess.GetComponent<AudioSource>().PlayOneShot(audio);
            StartCoroutine(ExecuteSuccess());
        } else {
            RemainingPoints.text = SaveDataManager.RiddleSaveData.GetRemainingPoints(RiddleManager.riddleId) + "/" + RiddleManager.currentRiddle.info.maxPoints;
            AudioClip audio = Resources.Load<AudioClip>($"RiddleAssets/failure") as AudioClip;
            BackgroundFailure.GetComponent<AudioSource>().PlayOneShot(audio);
            StartCoroutine(ExecuteFailure());
        }
    }

    // Update is called once per frame
    void Update() {

    }

    private IEnumerator ExecuteSuccess() {
        yield return new WaitForSeconds(2);
        BackgroundSuccess.enabled = true;
        yield return new WaitForSeconds(1);
        StartCoroutine(count(Int32.Parse(EarnedPoints.text), true, TotalPoints));
        StartCoroutine(count(Int32.Parse(EarnedPoints.text), false, EarnedPoints));
        yield return new WaitForSeconds(5);
        SaveDataManager.RiddleSaveData.UpdateTotalPoints(Int32.Parse(TotalPoints.text));
        SaveDataManager.RiddleSaveData.complete(RiddleManager.riddleId);
        SaveDataManager.SaveGame();
        // SceneManager.SetActiveScene(SceneManager.GetSceneByName("Riddle"));
        SceneManager.UnloadSceneAsync("RiddleSolution");
    }

    private IEnumerator ExecuteFailure() {
        yield return new WaitForSeconds(2);
        BackgroundFailure.enabled = true;
        yield return new WaitForSeconds(1);
        bool remainingAboveMin = Int32.Parse(RemainingPoints.text.Split('/')[0]) > RiddleManager.currentRiddle.info.minPoints;
        if (remainingAboveMin)
            StartCoroutine(countDownWithSlash(RiddleManager.currentRiddle.info.pointReduction, RemainingPoints));
        yield return new WaitForSeconds(5);
        if (remainingAboveMin) {
            int remaining = Int32.Parse(RemainingPoints.text.Split('/')[0]);
            SaveDataManager.RiddleSaveData.UpdateRemainingPoints(RiddleManager.riddleId, remaining);
            SaveDataManager.SaveGame();
        }
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("Riddle"));
        SceneManager.UnloadSceneAsync("RiddleSolution");
    }

    private IEnumerator count(int amount, bool up, Text toUpdate) {
        float interval = 2f / amount;
        for (int i = 0; i < amount; i++) {
            if (up)
                toUpdate.text = (Int32.Parse(toUpdate.text) + 1).ToString();
            else
                toUpdate.text = (Int32.Parse(toUpdate.text) - 1).ToString();
            yield return new WaitForSeconds(interval);
        }
    }

    private IEnumerator countDownWithSlash(int amount, Text toUpdate) {
        float interval = 2f / amount;
        for (int i = 0; i < amount; i++) {
            string[] split = toUpdate.text.Split('/');
            toUpdate.text = (Int32.Parse(split[0]) - 1) + "/" + split[1];
            yield return new WaitForSeconds(interval);
        }
    }
}
