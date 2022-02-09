using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class FinishScreen : MonoBehaviour
{

	private GameQuantities game;
	public Text TextfieldMistakes;
	public Text head;
	private GameObject spawnedStarLeft;
	private GameObject spawnedStarCenter;
	private GameObject spawnedStarRight;
	public GameObject LeftStarSpawn;
	public GameObject CenterStarSpawn;
	public GameObject RightStarSpawn;
	public GameObject star;
	private int mistakes;

	public Button menu;

	// Start is called before the first frame update
	void Start()
	{
		menu.onClick.AddListener(() => GoMenu());
		mistakes = PlayerPrefs.GetInt("wrongAnswers");
		Debug.Log(mistakes);
		SpawnStars();
	}

	public void GoMenu(){
		MenuPickLevelAdvanced.maxNumberStatic = 0;
		MenuPickLevelAdvanced.lvlAmmountStatic = 0;
		MenuPickLevelAdvanced.fourChoices = 0;
		SceneManager.LoadScene("MenuLearning");
	}

	public void SpawnStars(){
		Debug.Log("Bin in der Funktion");
		head.text = ("Schade!");
		TextfieldMistakes.text = ("Nächstes mal klappts!!!");
		if(mistakes <= 4){
			SaveDataManager.RiddleSaveData.stars++;
			Debug.Log("Erste IF");
			spawnedStarLeft = Instantiate(star, LeftStarSpawn.transform.position, Quaternion.identity);
			spawnedStarLeft.transform.SetParent(LeftStarSpawn.transform);
			head.text = ("Glückwunsch!");
			TextfieldMistakes.text = ("Nur " + mistakes + " Fehler");
			if(mistakes <= 2){
				SaveDataManager.RiddleSaveData.stars++;
				Debug.Log("Zweite IF");
				spawnedStarCenter = Instantiate(star, CenterStarSpawn.transform.position, Quaternion.identity);
				spawnedStarCenter.transform.SetParent(CenterStarSpawn.transform);
				head.text = ("Glückwunsch!");
				TextfieldMistakes.text = ("Nur " + mistakes + " Fehler");
				if(mistakes == 0){
					SaveDataManager.RiddleSaveData.stars++;
					Debug.Log("Dritte IF");
					spawnedStarRight = Instantiate(star, RightStarSpawn.transform.position, Quaternion.identity);
					spawnedStarRight.transform.SetParent(RightStarSpawn.transform);
					head.text = ("Glückwunsch!");
					TextfieldMistakes.text = ("Super alles Richtig!!!");
				}
			}
		}
		SaveDataManager.SaveGame();
	}

}