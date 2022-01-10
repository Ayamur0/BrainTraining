using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class GameQuantities : MonoBehaviour {
	//the Textfields I fill
	public Text TextfieldLeft;
	public Text TextfieldRight;
	public Text TextfieldLevel;
	public Text Symbol;

	//collider for Objects
	public Collider2D spawnerLeftCollider;
	public Collider2D spawnerRightCollider;

	//my Gameobjects to compare Quantities
	public GameObject objectLeft;
	public GameObject objectRight;
	public GameObject spawnerLeft;
	public GameObject spawnerRight;
	private GameObject spawnedObject;

	//array with gameObjects
	private List<GameObject> alleQuantitiesObjects = new List<GameObject>(40);

	public Image imageColor;

	//Buttons
	public Button lessBtn;
	public Button equalsBtn;
	public Button greaterBtn;

	//variables for compare Quantities
	private int numberLeft = 0;
	private int numberRight = 0;
	private int randomNumber = 0;
	private int counterRound = 0;
	private int counterWrongChoice = 0;
	private int lvlNumber = 10;
	private int lvlChoice = 2;

	void Start() {
		lessBtn.onClick.AddListener(() => setSymbol('<'));
		equalsBtn.onClick.AddListener(() => setSymbol('='));
		greaterBtn.onClick.AddListener(() => setSymbol('>'));
		PlayGame();
		SetLevelText();
	}

	public void setSymbol(char symbol){
		Symbol.text = symbol.ToString();
		StartCoroutine(waiter(1, symbol));

	}

	public void PlayGame() {
		//change color to white
		imageColor.color = new Color32(255, 255, 255, 255);
		Symbol.text = "";
		numberLeft = GenerateNumber();
		numberRight = GenerateNumber();
		if (lvlChoice == 1) {
			SetTextLeftAndRight(numberLeft, numberRight);
		} else if (lvlChoice == 2) {
			SpawnQuantitiesObjects(numberLeft, spawnerLeft, objectLeft);
			SpawnQuantitiesObjects(numberRight, spawnerRight, objectRight);
		}
		++counterRound;
	}

	public void SpawnQuantitiesObjects(int number, GameObject spawner, GameObject side) {
		for (int i = 0; i < number; i++) {
			spawnedObject = Instantiate(side, spawner.transform.position, Quaternion.identity);
			spawnedObject.name += i;
			spawnedObject.transform.SetParent(spawner.transform.GetChild(i / 4));
			alleQuantitiesObjects.Add(spawnedObject);
		}
	}

	public void DeleteObjects() {
		foreach (GameObject child in alleQuantitiesObjects) {
			Destroy(child);
		}
	}

	//show which lvl we Play
	public void SetLevelText() {
		TextfieldLevel.text = "Level: " + counterRound + "/" + lvlNumber;
	}

	//Random Number generated
	public int GenerateNumber() {
		return randomNumber = UnityEngine.Random.Range(1, 10);
	}

	//setFields
	public void SetTextLeftAndRight(int firstNumber, int secondNumber) {
		TextfieldLeft.text = firstNumber.ToString();
		TextfieldRight.text = secondNumber.ToString();
	}

	public int getAndSetCounterRound {
		get {
			return counterRound;
		}

		set {
			counterRound = value;
		}
	}

	public int getAndSetWrongChoice {
		get {
			return counterWrongChoice;
		}
		set {
			counterWrongChoice = value;
		}
	}

	public int getAndSetLvlNumber{
		get {
			return lvlNumber;
		}
		set {
			lvlNumber = value;
		}
	}

	IEnumerator waiter(int sec, char symbol){
		if(counterRound < lvlNumber){
			if(symbol.Equals('<')){
				Symbol.text = '<'.ToString();
				if (numberLeft < numberRight) {
					Debug.Log("Richtig");
					//change color green
					imageColor.color = new Color32(37, 250, 53, 255);
					yield return new WaitForSeconds(sec);
					DeleteObjects();
					PlayGame();
				} else {
					yield return new WaitForSeconds(sec);
					counterWrongChoice++;
					//change color red
					imageColor.color = new Color32(251, 37, 37, 255);
					yield return new WaitForSeconds(sec);
					imageColor.color = new Color32(255, 255, 255, 255);
					Symbol.text = "";
					Debug.Log("Nicht richtig");
				}
			}
			if(symbol.Equals('=')){
				Symbol.text = '='.ToString();
				if (numberLeft == numberRight) {
					Debug.Log("Richtig");
					//change color green
					imageColor.color = new Color32(37, 250, 53, 255);
					yield return new WaitForSeconds(sec);
					DeleteObjects();
					PlayGame();
				} else {
					counterWrongChoice++;
					//change color red
					imageColor.color = new Color32(251, 37, 37, 255);
					yield return new WaitForSeconds(sec);
					imageColor.color = new Color32(255, 255, 255, 255);
					Symbol.text = "";
					Debug.Log("Nicht richtig");
				}
			}
			if(symbol.Equals('>')){
				Symbol.text = '>'.ToString();
				if (numberLeft > numberRight) {
					Debug.Log("Richtig");
					//change color green
					imageColor.color = new Color32(37, 250, 53, 255);
					yield return new WaitForSeconds(sec);
					DeleteObjects();
					PlayGame();
				} else {
					counterWrongChoice++;
					//change color red
					imageColor.color = new Color32(251, 37, 37, 255);
					yield return new WaitForSeconds(sec);
					imageColor.color = new Color32(255, 255, 255, 255);
					Symbol.text = "";
					Debug.Log("Nicht richtig");
				}
			}
		}
		else {
			PlayerPrefs.SetInt("wrongAnswers", counterWrongChoice);
			SceneManager.LoadScene("LearnFinishScreen");
			Debug.Log("Game Vorbei \n" + "Anzahl Fehler: " + counterWrongChoice);
		}
	}

}