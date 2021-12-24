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

	//variables for compare Quantities
	private int numberLeft = 0;
	private int numberRight = 0;
	private int randomNumber = 0;
	private int counterRound = 0;
	private int counterWrongChoice = 0;
	private int lvlNumber = 10;
	private int lvlChoice = 1;

	private int xCoordinates;
	private int yCoordinates;
	private int counterObjectsPosition = 0;
	//Vector for my target
	Bounds target;

	void Start() {
		PlayGame();
		SetLevelText();
	}

	public void PlayGame() {

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
		xCoordinates = -100;
		yCoordinates = 100;
		counterObjectsPosition = 0;
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

	//check solution
	public void Solution(int solutionNumber) {

		if (counterRound < lvlNumber) {
			if (solutionNumber == 0) {
				Debug.Log("Noch nichts ausgewählt");
			}
			if (solutionNumber == '<') {
				if (numberLeft < numberRight) {
					Debug.Log("Richtig");
					DeleteObjects();
					PlayGame();
				} else {
					counterWrongChoice++;
					Debug.Log("Nicht richtig");
				}
			}
			if (solutionNumber == '=') {
				if (numberLeft == numberRight) {
					Debug.Log("Richtig");
					DeleteObjects();
					PlayGame();
				} else {
					counterWrongChoice++;
					Debug.Log("Nicht richtig");
				}
			}
			if (solutionNumber == '>') {
				if (numberLeft > numberRight) {
					Debug.Log("Richtig");
					DeleteObjects();
					PlayGame();
				} else {
					counterWrongChoice++;
					Debug.Log("Nicht richtig");
				}
			}
		} else {
			PlayerPrefs.SetInt("wrongAnswers", counterWrongChoice);
			SceneManager.LoadScene("LearnFinishScreen");
			Debug.Log("Game Vorbei \n" + "Anzahl Fehler: " + counterWrongChoice);
		}
	}

	//Random Number generated
	public int GenerateNumber() {
		return randomNumber = UnityEngine.Random.Range(0, 10);
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

}