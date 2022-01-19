using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class MenuPickLevelAdvanced : MonoBehaviour
{

	//Buttons
	public Button back;
	public Button start;

	public List <Button> leftSideList = new List<Button>();
	private List<Button> rightSideList = new List<Button>();

	public GameObject buttonPref;
	public GameObject spawnerLeft;
	public GameObject spawnerRight;
	private GameObject spawnedObject;

	public Sprite[] quantitiesModes = new Sprite[2];
	public Sprite[] mathModes = new Sprite[4];
	public Sprite[] difficulty = new Sprite[3];

	public static int maxNumberStatic = 0;
	public static int lvlAmmountStatic = 0;
	public static int fourChoices = 0;
	public static int wallSize = 0;

	private int loadButtonsNumber = 0;
	private bool leftSide = false;
	private bool rightSide = false;

	private int setOptionLeft = 0;

	void Start()
	{
		loadButtonsNumber = MenuPickLevel.loadButtonsPrefab;
		back.onClick.AddListener(() => GoBack());
		start.onClick.AddListener(() => LoadGame());
		SpawnButtonsRight();
		if(loadButtonsNumber == 2 || loadButtonsNumber == 4){
			SpawnButtonsLeft();
		}
		else{
			leftSide = true;
		}
	}

	void Update(){
		if(!leftSide || !rightSide){
			start.interactable = false;
		}
		if(leftSide && rightSide){
			start.interactable = true;
		}
	}

	public void GoBack(){
		MenuPickLevel.loadButtonsPrefab = 0;
		SceneManager.LoadScene("MenuLearning");
	}


	public void LoadGame(){
		switch (loadButtonsNumber)
		{
			case 2:
				SceneManager.LoadScene("CompareQuantities");
				break;
			case 3:
				SceneManager.LoadScene("triangle");
				break;
			case 4:
				SceneManager.LoadScene("basicOperations");
				break;
			case 5:
				SceneManager.LoadScene("lightningView");
				break;
			case 6:
				SceneManager.LoadScene("finishPattern");
				break;
			case 7:
				SceneManager.LoadScene("MixedWords");
				break;
			default:
				break;
		}
	}

	public void SafeOptionsRight(int whichButton){
		for (int i = 0; i < rightSideList.Count; i++){
			if(i != whichButton){
				rightSideList[i].interactable = true;
				continue;
			}
			rightSide = true;
			rightSideList[i].interactable = false;
		}
		switch (whichButton)
		{
			case 0:
				lvlAmmountStatic = 10;
				maxNumberStatic = 10;
				wallSize = 3;
				break;
			case 1:
				lvlAmmountStatic = 15;
				maxNumberStatic = 15;
				wallSize = 4;
				break;
			case 2:
				lvlAmmountStatic = 20;
				maxNumberStatic = 20;
				wallSize = 5;
				break;
			default:
				break;
		}
	}

	public void SafeOptionsLeft(int whichButton){
		for (int i = 0; i < leftSideList.Count; i++){
			if(i != whichButton){
				leftSideList[i].interactable = true;
				continue;
			}
			leftSide = true;
			leftSideList[i].interactable = false;
		}
		if(loadButtonsNumber == 2){
			setQuantitiesOptions(whichButton);
		}
		else if(loadButtonsNumber == 4){
			setMathOptions(whichButton);
		}

	}

	public void setQuantitiesOptions(int whichButton){
		switch (whichButton)
		{
			case 0:
				fourChoices = 1;
				break;
			case 1:
				fourChoices = 2;
				break;
			default:
				break;
		}
	}

	public void setMathOptions(int whichButton){
		switch (whichButton)
		{
			case 0:
				fourChoices = 1;
				break;
			case 1:
				fourChoices = 2;
				break;
			case 2:
				fourChoices = 3;
				break;
			case 3:
				fourChoices = 4;
				break;
			default:
				break;
		}
	}

	public void SpawnButtonsLeft(){
		for (int i = 0; i < loadButtonsNumber; i++){
			int copy = i;
			spawnedObject = Instantiate(buttonPref, spawnerLeft.transform.position, Quaternion.identity);
			spawnedObject.name += i;
			spawnedObject.transform.SetParent(spawnerLeft.transform);
			leftSideList.Add(spawnedObject.GetComponent<Button>());
			leftSideList[i].onClick.AddListener(() => SafeOptionsLeft(copy));
			if(loadButtonsNumber == 2){
				leftSideList[i].GetComponentInChildren<Image>().sprite = quantitiesModes[i];
				continue;
			}
			else if(loadButtonsNumber == 4){
				leftSideList[i].GetComponentInChildren<Image>().sprite = mathModes[i];
			}
		}
	}

	public void SpawnButtonsRight(){
		for (int i = 0; i < 3; i++){
			int copy = i;
			spawnedObject = Instantiate(buttonPref, spawnerRight.transform.position, Quaternion.identity);
			spawnedObject.name += i;
			spawnedObject.transform.SetParent(spawnerRight.transform);
			rightSideList.Add(spawnedObject.GetComponent<Button>());
			rightSideList[i].onClick.AddListener(() => SafeOptionsRight(copy));
			rightSideList[i].GetComponentInChildren<Image>().sprite = difficulty[i];

		}
	}
}
