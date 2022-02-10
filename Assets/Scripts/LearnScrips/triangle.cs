using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class Triangle : MonoBehaviour
{

	public GameObject brick;

	//rows of the triangle
	public GameObject triangleGameObject;

	public Text lvlText;


	private GameObject spawnedObject;

	public GameObject leftFirework;
	public GameObject rightFirework;

	public GameObject fireworkPrefab;

	//3 = bottom 3 bricks, 4 = bottom 4 bricks, 5 = bottom 5 bricks
	private int triangleSize = 3;

	private int[][] jaggedSolution = new int[5][];

	private InputField[][] jaggedInputs = new InputField[5][];

	private int[] bottomNumbers;

	public Button testSolution;
	public Button menu;

	private int lvlCounter = 0;
	private int wrongChoice = 0;
	private int lvlNumber = 10;
	private int maxNumber = 0;
	private Vector3 scaleSize = new Vector3 (1.0f, 1.0f, 1.0f);

	// Start is called before the first frame update
	void Start()
	{
		menu.onClick.AddListener(() => GoBack());
		maxNumber = MenuPickLevelAdvanced.maxNumberStatic;
		lvlNumber = MenuPickLevelAdvanced.lvlAmmountStatic;
		triangleSize = MenuPickLevelAdvanced.wallSize;
		testSolution.interactable = false;
		testSolution.onClick.AddListener(() => CheckSolution());
		jaggedInputs[0] = new InputField[1];
		jaggedInputs[1] = new InputField[2];
		jaggedSolution[0] = new int[1];
		jaggedSolution[1] = new int[2];
		GenerateSolutionArray();
		SpawnPyramidRows();
		PlayGame();
	}

	void Update(){
				bool enabel = false;
		for (int i = 0; i < triangleSize - 1; i++){
			for (int j = 0; j < jaggedInputs[i].Length; j++) {
				if(string.IsNullOrEmpty(jaggedInputs[i][j].text)){
					enabel = true;
					testSolution.interactable = false;

				}
			}
		}
		if(!enabel){
			testSolution.interactable = true;
		}
	}




	public void GoBack(){
		MenuPickLevelAdvanced.maxNumberStatic = 0;
		MenuPickLevelAdvanced.lvlAmmountStatic = 0;
		MenuPickLevelAdvanced.fourChoices = 0;
		SceneManager.LoadScene("MenuLearning");
	}

	public void GenerateSolutionArray(){
		if(triangleSize >= 3){
			jaggedSolution[2] = new int[3];
			jaggedInputs[2] = new InputField[3];
			if(triangleSize >= 4){
				jaggedSolution[3] = new int[4];
				jaggedInputs[3] = new InputField[4];
				if(triangleSize == 5){
					jaggedSolution[4] = new int[5];
					jaggedInputs[4] = new InputField[5];
				}
			}
		}
	}

	public void ShowBottomLineNumbers(){
		for (int i = 0; i < bottomNumbers.Length; i++){
			if(triangleSize == 3){
				jaggedSolution[2][i] = bottomNumbers[i];
				jaggedInputs[2][i].text = bottomNumbers[i].ToString();
				jaggedInputs[2][i].interactable = false;
			}
			else if(triangleSize == 4){
				jaggedSolution[3][i] = bottomNumbers[i];
				jaggedInputs[3][i].text = bottomNumbers[i].ToString();
				jaggedInputs[3][i].interactable = false;
			}
			else if(triangleSize == 5){
				jaggedSolution[4][i] = bottomNumbers[i];
				jaggedInputs[4][i].text = bottomNumbers[i].ToString();
				jaggedInputs[4][i].interactable = false;
			}
		}


	}

	public void FillSolutionArray(){
		for (int i = triangleSize - 2; i >= 0; i--){
			for (int j = 0; j < jaggedSolution[i].Length; j++){
				jaggedSolution[i][j] = jaggedSolution[i + 1][j] + jaggedSolution[i + 1][j + 1];
			}
		}
	}

	public void CheckSolution(){
		StartCoroutine(Waiter(1));
	}

	public void PlayGame(){
		lvlCounter++;
		if(lvlCounter > lvlNumber){
			PlayerPrefs.SetInt("wrongAnswers", wrongChoice);
			SceneManager.LoadScene("LearnFinishScreen");
			Debug.Log("Game Vorbei \n" + "Anzahl Fehler: " + wrongChoice);
		}
		if(lvlCounter != 1){
			Debug.Log("hier war ich");
			ClearArray();
		}
		if(lvlCounter <= lvlNumber)	lvlText.text = "Level: " + lvlCounter + "/" + lvlNumber;
		GenerateNumbers();
		ShowBottomLineNumbers();
		FillSolutionArray();
	}

	public void ClearArray(){
		for (int i = 0; i < triangleSize - 1; i++){
			for (int j = 0; j < jaggedInputs[i].Length; j++) {
				jaggedInputs[i][j].text = "";
				jaggedInputs[i][j].interactable = true;
			}
		}
	}

	public void SpawnPyramidRows(){
		for (int i = 0; i < triangleSize; i++){
			for (int j = 0; j < i + 1; j++){
				spawnedObject = Instantiate(brick, triangleGameObject.transform.position, Quaternion.identity);
				spawnedObject.name += i;
				spawnedObject.transform.SetParent(triangleGameObject.transform.GetChild(i));
				spawnedObject.transform.localScale = scaleSize;
				jaggedInputs[i][j] =spawnedObject.GetComponent<InputField>();
			}
		}

	}

	public void GenerateNumbers(){
		bottomNumbers = new int[triangleSize];
		for (int i = 0; i < bottomNumbers.Length; i++) {
			bottomNumbers[i] = UnityEngine.Random.Range(0, maxNumber);
			jaggedSolution[triangleSize - 1][i] = bottomNumbers[i];
		}
	}

	public void SpawnFirework(){
		spawnedObject = Instantiate(fireworkPrefab, leftFirework.transform.position, leftFirework.transform.rotation);
		spawnedObject.transform.SetParent(leftFirework.transform);
		spawnedObject.transform.localScale = scaleSize;
		spawnedObject = Instantiate(fireworkPrefab, rightFirework.transform.position, rightFirework.transform.rotation);
		spawnedObject.transform.SetParent(rightFirework.transform);
		spawnedObject.transform.localScale = scaleSize;
		Debug.Log("Firework");

	}

	public void DeleteFirework(){
		Destroy(leftFirework.transform.GetChild(0).gameObject);
		Destroy(rightFirework.transform.GetChild(0).gameObject);
	}


	IEnumerator Waiter(int sec){
		bool finished = false;
		if(lvlCounter <= lvlNumber){
			for (int i = triangleSize - 2; i >= 0; i--){
				for (int j = 0; j < jaggedSolution[i].Length; j++){
					if(jaggedSolution[i][j] == int.Parse(jaggedInputs[i][j].text)){
						jaggedInputs[i][j].interactable = false;
						continue;
					}
					else{
						jaggedInputs[i][j].text = "";
						wrongChoice++;
						finished = true;
					}
				}
			}
			if(!finished){
				SpawnFirework();
				yield return new WaitForSeconds(sec);
				DeleteFirework();
				PlayGame();
			}
		}
	}

}