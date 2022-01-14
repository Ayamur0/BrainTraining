using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class lightningView : MonoBehaviour {

	public Text showLevel;

	public InputField solution;

	public Image imageColor;

	public GameObject spawnedObject;
	public GameObject spawner;
	public GameObject cover;
	private GameObject allObjects;

	public GameObject spawnerCoverLeft;

	public Button checkButton;

	private List<Vector2> allPositions = new List<Vector2>(10);

	//Variabln for lightningView
	private int numberLeft;
	private int counterRound = 1;
	private int wrongChoice = 0;
	private int lvlNumber = 10;
	private int lvlChoice = 1;
	private float minDistance = 18f;
	private bool hitPosition = false;

	// Start is called before the first frame update
	void Start() {
		checkButton.onClick.AddListener(() => buttonClick());
		playGame();
	}

	public void buttonClick(){
		foreach (Transform child in spawnerCoverLeft.transform) {
			Destroy(child.gameObject);
		}
		StartCoroutine(solutionWaiter(1));
	}

	public int randomNumber(){
		return UnityEngine.Random.Range(1, 10);
	}

	public void hideCircle(){
		StartCoroutine(waiter(1));
	}

	public void setObjects(){
		Debug.Log(numberLeft);
		for (int i = 0; i < numberLeft; i++) {
			allObjects = Instantiate(spawnedObject, spawner.transform.position, Quaternion.identity);
			allObjects.name += i;
			allObjects.transform.SetParent(spawner.transform);
			ChangePosition(i);
		}
	}

	public void ChangePosition(int firstNumber){
		RectTransform spawnRect = spawner.GetComponent<RectTransform>();
		float width = spawnRect.rect.width;
		float height = spawnRect.rect.height;
		float xPos = UnityEngine.Random.Range(((float)spawnRect.transform.position.x - (width - 39.3829f)/2), (float)spawnRect.transform.position.x + (width - 39.3829f)/2);
		float yPos = UnityEngine.Random.Range(((float)spawnRect.transform.position.x - (height - 39.3829f)/2), (float)spawnRect.transform.position.x + (height - 39.3829f)/2);
		Vector2 newPos = new Vector2(xPos, yPos);

		if(firstNumber == 0){
			allPositions.Add(newPos);
			allObjects.transform.position = newPos;
			return;
		}


		for (int i = 0; i < allPositions.Count; i++){
			float distance = Vector2.Distance(new Vector2(allPositions[i].x, allPositions[i].y), new Vector2(newPos.x, newPos.y));
			if(distance >= minDistance){
				hitPosition = true;
			}
			else{
				hitPosition = false;
				break;
			}

		}
		if(hitPosition){
			allPositions.Add(newPos);
			allObjects.transform.position = newPos;

		}
		else{
			ChangePosition(firstNumber);
		}

	}

	public void deletObjects(){
		foreach (Transform child in spawner.transform){
			Destroy(child.gameObject);
		}
	}

	public void playGame(){
		//change color to white
		imageColor.color = new Color32(255, 255, 255, 255);
		showLevel.text = "Level: " + counterRound + "/" + lvlNumber;
		numberLeft = randomNumber();
		Debug.Log(numberLeft);
		solution.text = "";
		setObjects();
		hideCircle();
	}

	IEnumerator waiter(int sec){
		yield return new WaitForSeconds(sec);
		GameObject hideCircles = Instantiate(cover, spawnerCoverLeft.transform.position, Quaternion.identity);
		hideCircles.transform.SetParent(spawnerCoverLeft.transform);
	}

	IEnumerator solutionWaiter(int sec){
		if(counterRound < lvlNumber){
			if(int.Parse(solution.text) == numberLeft){
				//change color green
				imageColor.color = new Color32(37, 250, 53, 255);
				yield return new WaitForSeconds(sec);
				deletObjects();
				counterRound++;
				playGame();

			}
			else{
				//change color red
				imageColor.color = new Color32(251, 37, 37, 255);
				yield return new WaitForSeconds(sec);
				wrongChoice++;
				//change color to white
				imageColor.color = new Color32(255, 255, 255, 255);
				solution.text = "";
				hideCircle();
			}
		}
		else{
			PlayerPrefs.SetInt("wrongAnswers", wrongChoice);
			SceneManager.LoadScene("LearnFinishScreen");
			Debug.Log("Game Vorbei \n" + "Anzahl Fehler: " + wrongChoice);
		}
	}
}