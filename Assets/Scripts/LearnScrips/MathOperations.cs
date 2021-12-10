using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class MathOperations : MonoBehaviour
{

	public Text TextNumberLeft;
	public Text TextNumberRight;
	public Text operatorSymbole;
	public Text showLevelNumber;

	public InputField solutionNumber;

	public Button checkButton;

	private int leftNumber;
	private int rightNumber;
	private int solution;
	private int maxRandomNumber = 10;
	private int minRandomNumber = 0;
	private int lvlNumber = 10;
	private int countLvl = 0;
	//add = 1, sub = 2, mult = 3, div = 4
	private int gameMode = 4;
	private int wrongSolution = 0;

	// Start is called before the first frame update
	void Start()
	{
		checkButton.onClick.AddListener(() => buttonClick());
		PlayGame(gameMode);
	}

	void Update(){
	}

	public void PlayGame(int gameMode){
		showLevelNumber.text = "Level: " + countLvl + "/" + lvlNumber;
		solutionNumber.text = "";
		if(gameMode == 4){
			operatorSymbole.text = "/";
			minRandomNumber = 1;
			leftNumber = RandomNumbers(minRandomNumber, maxRandomNumber);
			rightNumber = RandomNumbers(minRandomNumber, maxRandomNumber);
			solution = leftNumber * rightNumber;
			SetNumbersLeftAndRight(solution, rightNumber);
			return;
		}
		else if(gameMode == 2){
			minRandomNumber = 0;
			leftNumber = RandomNumbers(minRandomNumber, maxRandomNumber);
			rightNumber = RandomNumbers(minRandomNumber, maxRandomNumber);
			if(leftNumber < rightNumber){
				Debug.Log(" leftNumber: " + leftNumber + " rightNumber: " + rightNumber + "zweite If");
				SetNumbersLeftAndRight(rightNumber, leftNumber);
				solution = rightNumber - leftNumber;
			}
			else{
				Debug.Log(" leftNumber: " + leftNumber + " rightNumber: " + rightNumber + "zweite If");
				SetNumbersLeftAndRight(leftNumber, rightNumber);
				solution = leftNumber - rightNumber;
			}
			operatorSymbole.text = "-";
			return;
		}
		else{
			minRandomNumber = 0;
			leftNumber = RandomNumbers(minRandomNumber, maxRandomNumber);
			rightNumber = RandomNumbers(minRandomNumber, maxRandomNumber);
			SetNumbersLeftAndRight(leftNumber, rightNumber);
			if(gameMode == 1){
				operatorSymbole.text = "+";
				solution = leftNumber + rightNumber;
			}
			else{
				operatorSymbole.text = "*";
				solution = leftNumber * rightNumber;
			}
			return;
		}
	}

	public int RandomNumbers(int minRandomNumber, int maxRandomNumber){
		return UnityEngine.Random.Range(minRandomNumber, maxRandomNumber);
	}


	public void SetNumbersLeftAndRight(int left, int right){
			TextNumberLeft.text = left.ToString();
			TextNumberRight.text = right.ToString();

	}

	public void CheckSolutionDiv(){
		if(countLvl < lvlNumber){
			if(int.Parse(solutionNumber.text) == leftNumber){
				countLvl++;
				PlayGame(gameMode);
			}
			else{
				wrongSolution++;
				solutionNumber.text = "";
			}
		}
		else{
			PlayerPrefs.SetInt("wrongAnswers", wrongSolution);
			SceneManager.LoadScene("LearnFinishScreen");
			Debug.Log("Game Vorbei \n" + "Anzahl Fehler: " + wrongSolution);
		}
	}

	public void CheckSolution(){
		if(countLvl < lvlNumber){
			if(int.Parse(solutionNumber.text) == solution){
				countLvl++;
				PlayGame(gameMode);
			}
			else{
				wrongSolution++;
				solutionNumber.text = "";
			}
		}
		else{
			PlayerPrefs.SetInt("wrongAnswers", wrongSolution);
			SceneManager.LoadScene("LearnFinishScreen");
			Debug.Log("Game Vorbei \n" + "Anzahl Fehler: " + wrongSolution);
		}
	}

	public void buttonClick(){
		if(gameMode == 4){
			CheckSolutionDiv();
		}
		else{
			CheckSolution();
		}
	}
}
