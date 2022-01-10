using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class FinishPattern : MonoBehaviour {

	//Number text fields
	public Text firstNumber;
	public Text secondNumber;
	public Text thirdNumber;
	public Text forthNumber;
	public Text fifthNumber;
	public Text lvlText;

	//Input fields
	public InputField inputNumberOne;
	public InputField inputNumberTwo;
	public InputField inputNumberThree;
	public InputField inputNumberFour;
	public InputField inputNumberFive;

	//random Numbers
	private int randomNumber;
	private int FirstRandomNumber;
	private int SecondRandomNumber;

	//lvl variabls
	private int lvlAmount = 10;
	private int wrongAnswers;
	private int lvlCounter = 1;
	private int maxNumbers = 20;

	//int start start pattern
	private int[] patternNumbers = new int[5];

	//int solutions
	private int[] solutionsNumbers = new int[5];

	//int inputNumbers
	private int[] inputNumbersArray = new int[5];


	//Button test
	public Button checkSolution;

	// public Image imageColor;

	// public GameObject inputs;


	// Start is called before the first frame update
	void Start() {
		checkSolution.onClick.AddListener(() => clickButton());
		PlayGame();
	}

	void Update() {
		if (string.IsNullOrEmpty(inputNumberOne.text) || string.IsNullOrEmpty(inputNumberTwo.text) || string.IsNullOrEmpty(inputNumberThree.text) || string.IsNullOrEmpty(inputNumberFour.text) || string.IsNullOrEmpty(inputNumberFive.text)) {
			checkSolution.interactable = false;
		} else {
			checkSolution.interactable = true;
		}
	}

	public void clickButton() {
		Debug.Log(int.Parse(inputNumberOne.text));
		Debug.Log(int.Parse(inputNumberTwo.text));
		Debug.Log(int.Parse(inputNumberThree.text));
		Debug.Log(int.Parse(inputNumberFour.text));
		Debug.Log(int.Parse(inputNumberFive.text));
		StartCoroutine(waiter(1));
	}

	public int RandomBeginningNumber(int maxNumbers) {
		return UnityEngine.Random.Range(0, maxNumbers);
	}

	public int RandomPatternNumbers() {
		return UnityEngine.Random.Range(1, 5);
	}

	public void PlayGame() {
		ResetInputFields();
		SetLvlText();
		randomNumber = RandomBeginningNumber(maxNumbers);
		FirstRandomNumber = RandomPatternNumbers();
		SecondRandomNumber = RandomPatternNumbers();
		SetStartPattern();
		SetSolution();
		SetPattern();
	}

	public void SetStartPattern() {
		patternNumbers[0] = randomNumber;
		patternNumbers[1] = patternNumbers[0] + FirstRandomNumber;
		patternNumbers[2] = patternNumbers[1] + SecondRandomNumber;
		patternNumbers[3] = patternNumbers[2] + FirstRandomNumber;
		patternNumbers[4] = patternNumbers[3] + SecondRandomNumber;
	}

	public void SetSolution() {
		solutionsNumbers[0] = patternNumbers[4] + FirstRandomNumber;
		solutionsNumbers[1] = solutionsNumbers[0] + SecondRandomNumber;
		solutionsNumbers[2] = solutionsNumbers[1] + FirstRandomNumber;
		solutionsNumbers[3] = solutionsNumbers[2] + SecondRandomNumber;
		solutionsNumbers[4] = solutionsNumbers[3] + FirstRandomNumber;
	}

	public void SetPattern() {

		firstNumber.text = patternNumbers[0].ToString();
		secondNumber.text = patternNumbers[1].ToString();
		thirdNumber.text = patternNumbers[2].ToString();
		forthNumber.text = patternNumbers[3].ToString();
		fifthNumber.text = patternNumbers[4].ToString();
	}


	IEnumerator waiter(int sec) {
		bool skip = false;
		if (lvlCounter < lvlAmount) {
			inputNumbersArray[0] = int.Parse(inputNumberOne.text);
			inputNumbersArray[1] = int.Parse(inputNumberTwo.text);
			inputNumbersArray[2] = int.Parse(inputNumberThree.text);
			inputNumbersArray[3] = int.Parse(inputNumberFour.text);
			inputNumbersArray[4] = int.Parse(inputNumberFive.text);
			for (int i = 0; i < 5; i++) {
				if (solutionsNumbers[i] == inputNumbersArray[i]) {
					//change color green
					// imageColor.color = new Color32(37, 250, 53, 255);
					yield return new WaitForSeconds(sec);
					continue;
				}
				switch (i) {
					case 0:
						inputNumberOne.text = "";
						break;
					case 1:
						inputNumberTwo.text = "";
						break;
					case 2:
						inputNumberThree.text = "";
						break;
					case 3:
						inputNumberFour.text = "";
						break;
					case 4:
						inputNumberFive.text = "";
						break;
					default:
						Debug.Log("Fehler Brudi");
						break;
				}
				skip = true;
				wrongAnswers++;
			}
			if (!skip) {
				lvlCounter++;
				PlayGame();
			}
		} else {
			PlayerPrefs.SetInt("wrongAnswers", wrongAnswers);
			SceneManager.LoadScene("LearnFinishScreen");
			Debug.Log("Game Vorbei \n" + "Anzahl Fehler: " + wrongAnswers);
		}
	}


	public void SetLvlText(){
		lvlText.text = "Level: " + lvlCounter + "/" + lvlAmount;
	}

	public void ResetInputFields(){
		inputNumberOne.text = "";
		inputNumberTwo.text = "";
		inputNumberThree.text = "";
		inputNumberFour.text = "";
		inputNumberFive.text = "";
	}
}
