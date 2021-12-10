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
	private List<Bounds> alleQuantitiesObjects = new List<Bounds>(40);

	//variables for compare Quantities
	private int numberLeft = 0;
	private int numberRight = 0;
	private int randomNumber = 0;
	private int counterRound = 0;
	private int counterWrongChoice = 0;
	private int lvlNumber = 10;
	private int lvlChoice = 1;
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
		Debug.Log("Number Left" + number);
		for (int i = 0; i < 20; i++) {
			spawnedObject = Instantiate(side, spawner.transform.position, Quaternion.identity);
			spawnedObject.name += i;
			spawnedObject.transform.SetParent(spawner.transform);
			ChangePosition(spawnedObject, spawner);
			SafePosition(spawnedObject);
		}
	}

	public void SafePosition(GameObject cache) {
		RectTransform rectTransformSpawner = cache.GetComponent<RectTransform>();
		float widthSpawner = rectTransformSpawner.sizeDelta.x;
		float heightSpawner = rectTransformSpawner.sizeDelta.y;
		Vector2 centerObject = rectTransformSpawner.transform.TransformPoint(rectTransformSpawner.rect.center);

		Debug.Log($"Name: {cache.name}, Width:{widthSpawner}, height: {heightSpawner}, center: {centerObject}");

		alleQuantitiesObjects.Add(new Bounds(centerObject, new Vector2(widthSpawner, heightSpawner)));
	}

	//interesect googln
	public void ChangePosition(GameObject cache, GameObject spawner) {
		Bounds colliderBounds = GetSideOfCollider(spawner);


		RectTransform rectTransformSpawner = spawner.GetComponent<RectTransform>();
		float widthSpawner = rectTransformSpawner.sizeDelta.x / 2;
		float heightSpawner = rectTransformSpawner.sizeDelta.y / 2;


		Vector2 min = (new Vector2(rectTransformSpawner.rect.xMin, rectTransformSpawner.rect.yMin));
		Vector2 max = (new Vector2(rectTransformSpawner.rect.xMax, rectTransformSpawner.rect.yMax));

		float xCoordinates = UnityEngine.Random.Range(min.x, max.x);
		float yCoordinates = UnityEngine.Random.Range(min.y, max.y);

		RectTransform rectTransform = cache.GetComponent<RectTransform>();
		float width = rectTransform.sizeDelta.x;
		float height = rectTransform.sizeDelta.y;

		//target in bounds ändern
		target = new Bounds(new Vector2(xCoordinates, yCoordinates), new Vector2(width, height));

		bool intersects = false;
		foreach (var b in alleQuantitiesObjects)
		{
			Debug.Log($"Bound B: {b}, targer: {target}, Vergleich: {b.Intersects(target)}");
			if(b.Intersects(target)){
				intersects = true;
				break;
			}
		}
		if(!intersects){
			cache.transform.position += target.center;
		}
		else{
			ChangePosition(cache, spawner);
		}
	}

	public Bounds GetSideOfCollider(GameObject spawner) {
		if (spawner.Equals(spawnerLeft)) {
			return spawnerLeftCollider.bounds;

		}
		return spawnerRightCollider.bounds;
	}


	public void DeleteObjects(GameObject gameObject, int number) {
		foreach (Transform child in gameObject.transform) {
			Destroy(child.gameObject);
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
			if (solutionNumber == 60) {
				if (numberLeft < numberRight) {
					Debug.Log("Richtig");
					DeleteObjects(spawnerLeft, numberLeft);
					DeleteObjects(spawnerRight, numberRight);
					PlayGame();
				} else {
					counterWrongChoice++;
					Debug.Log("Nicht richtig");
				}
			}
			if (solutionNumber == 61) {
				if (numberLeft == numberRight) {
					Debug.Log("Richtig");
					DeleteObjects(spawnerLeft, numberLeft);
					DeleteObjects(spawnerRight, numberRight);
					PlayGame();
				} else {
					counterWrongChoice++;
					Debug.Log("Nicht richtig");
				}
			}
			if (solutionNumber == 62) {
				if (numberLeft > numberRight) {
					Debug.Log("Richtig");
					DeleteObjects(spawnerLeft, numberLeft);
					DeleteObjects(spawnerRight, numberRight);
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
