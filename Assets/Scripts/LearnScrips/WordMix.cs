using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;


public class WordMix : MonoBehaviour
{

	public Text wordLeft;
	public Text lvlNumber;

	public InputField solutionChild;

	// Start is called before the first frame update
	private string mixedWord;
	private string solution;
	public Image imageColor;

	private int lvlCount = 1;
	private int lvlAmount = 10;
	private int wrongChoices = 0;
	private int randomNumber = 0;

	//json file
	public TextAsset textJson;
	public WordList list = new WordList();

	//button
	public Button testWord;

	void Start()
	{
		testWord.onClick.AddListener(() => ButtonClicked());
		ReadJsonFile();
		PlayGame();

	}


	IEnumerator waiter(int sec){
		if(lvlCount < lvlAmount){
			if(solution.Equals(solutionChild.text)){
				//change color green
				imageColor.color = new Color32(37, 250, 53, 255);
				yield return new WaitForSeconds(sec);
				lvlCount++;
				solutionChild.text = "";
				PlayGame();
			}
			else{
				//change color red
				imageColor.color = new Color32(251, 37, 37, 255);
				yield return new WaitForSeconds(sec);
				//change color to white
				imageColor.color = new Color32(255, 255, 255, 255);
				solutionChild.text = "";
				wrongChoices++;
			}
		}
		else{
			PlayerPrefs.SetInt("wrongAnswers", wrongChoices);
			SceneManager.LoadScene("LearnFinishScreen");
			Debug.Log("Game Vorbei \n" + "Anzahl Fehler: " + wrongChoices);
		}
	}

	public void PlayGame(){
		//change color to white
		imageColor.color = new Color32(255, 255, 255, 255);
		lvlNumber.text = "Level: " + lvlCount + "/" + lvlAmount;
		GetWord();
		wordLeft.text = mixedWord;
	}

	public void GetWord(){
		randomNumber = GetRandomNumbers();
		Debug.Log("random Number: " + randomNumber);
		Debug.Log("lenght list: " + list.words.Length);
		copyArray();
		solution = list.words.GetValue(randomNumber).ToString();
		mixedWord = mixWord(solution);
		Debug.Log(mixedWord);
		Debug.Log("Soltion: " + solution);
	}

	public string mixWord(string word){
		string finishedMixing = "";
		System.Random rnd = new System.Random();
		SortedList<int,char> list = new SortedList<int,char>();
		foreach(char c in word)
			list.Add(rnd.Next(), c);
		foreach(var x in list){
			finishedMixing += x.Value.ToString();
		}
		return finishedMixing;
	}

	public int GetRandomNumbers(){
		if (list.words.Length != 0) {
			return UnityEngine.Random.Range(0, list.words.Length);
		}
		else{
			return -1;
		}
	}

	public void ReadJsonFile(){
		list = JsonUtility.FromJson<WordList>(textJson.text);
	}


	public void copyArray(){
		for (int i = 0; i < list.words.Length; i++){

		}
	}

	public void ButtonClicked(){
		StartCoroutine(waiter(1));
	}

}

// [System.Serializable]
// public class Words
// {
// 	public string germanWord;
// }

[System.Serializable]
public class WordList
{
	public string[] words;
}
