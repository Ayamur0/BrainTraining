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
	private int lvlNumber = 10;
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
	public Button menu;


	public InputField[] arrayInputs = new InputField[5];
	public Text[] arrayTextFields = new Text[5];


	// Start is called before the first frame update
	void Start() {
		menu.onClick.AddListener(() => GoBack());
		lvlNumber = MenuPickLevelAdvanced.lvlAmmountStatic;
		maxNumbers = MenuPickLevelAdvanced.maxNumberStatic;
		checkSolution.onClick.AddListener(() => clickButton());
		arrayInputs[0] = inputNumberOne;
		arrayInputs[1] = inputNumberTwo;
		arrayInputs[2] = inputNumberThree;
		arrayInputs[3] = inputNumberFour;
		arrayInputs[4] = inputNumberFive;
		arrayTextFields[0] = firstNumber;
		arrayTextFields[1] = secondNumber;
		arrayTextFields[2] = thirdNumber;
		arrayTextFields[3] = forthNumber;
		arrayTextFields[4] = fifthNumber;
		PlayGame();
	}

	void Update() {
		if (string.IsNullOrEmpty(inputNumberOne.text) || string.IsNullOrEmpty(inputNumberTwo.text) || string.IsNullOrEmpty(inputNumberThree.text) || string.IsNullOrEmpty(inputNumberFour.text) || string.IsNullOrEmpty(inputNumberFive.text)) {
			checkSolution.interactable = false;
		} else {
			checkSolution.interactable = true;
		}
	}

	public void GoBack(){
		MenuPickLevelAdvanced.maxNumberStatic = 0;
		MenuPickLevelAdvanced.lvlAmmountStatic = 0;
		MenuPickLevelAdvanced.fourChoices = 0;
		SceneManager.LoadScene("MenuLearning");
	}

	public void clickButton() {
		Solution();
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
		for (int i = 0; i < arrayInputs.Length; i++){
			arrayTextFields[i].text = patternNumbers[i].ToString();
		}
	}

	public void Solution(){
		bool skip = false;
		if (lvlCounter < lvlNumber) {
			inputNumbersArray[0] = int.Parse(inputNumberOne.text);
			inputNumbersArray[1] = int.Parse(inputNumberTwo.text);
			inputNumbersArray[2] = int.Parse(inputNumberThree.text);
			inputNumbersArray[3] = int.Parse(inputNumberFour.text);
			inputNumbersArray[4] = int.Parse(inputNumberFive.text);
			for (int i = 0; i < 5; i++) {
				if (solutionsNumbers[i] == int.Parse(arrayInputs[i].text)) {
					arrayInputs[i].interactable = false;
					continue;
				}
				else{
					skip = true;
					wrongAnswers++;
					arrayInputs[i].text = "";
				}
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
		lvlText.text = "Level: " + lvlCounter + "/" + lvlNumber;
	}

	public void ResetInputFields(){
		for (int i = 0; i < arrayInputs.Length; i++){
			arrayInputs[i].text = "";
			arrayInputs[i].interactable = true;
		}
	}
}
