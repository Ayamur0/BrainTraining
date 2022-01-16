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
	private GameObject spawnedStarLeft;
	private GameObject spawnedStarCenter;
	private GameObject spawnedStarRight;
	public GameObject LeftStarSpawn;
	public GameObject CenterStarSpawn;
	public GameObject RightStarSpawn;
	public GameObject star;
	private int mistakes;

	public Button lvlChoice;
	public Button menu;


	// Start is called before the first frame update
	void Start()
	{
		lvlChoice.onClick.AddListener(() => GoLvlChoice());
		menu.onClick.AddListener(() => GoMenu());
		mistakes = PlayerPrefs.GetInt("wrongAnswers");
		Debug.Log(mistakes);
		SpawnStars();
	}

	public void GoMenu(){
		MenuPickLevelAdvanced.maxNumberStatic = 0;
		MenuPickLevelAdvanced.lvlAmmountStatic = 0;
		MenuPickLevelAdvanced.fourChoices = 0;
	}

	public void GoLvlChoice(){
		MenuPickLevelAdvanced.maxNumberStatic = 0;
		MenuPickLevelAdvanced.lvlAmmountStatic = 0;
		MenuPickLevelAdvanced.fourChoices = 0;
		SceneManager.LoadScene("MenuLearning");
	}

	public void SpawnStars(){
		Debug.Log("Bin in der Funktion");
		if(mistakes <= 4){
			Debug.Log("Erste IF");
			spawnedStarLeft = Instantiate(star, LeftStarSpawn.transform.position, Quaternion.identity);
			spawnedStarLeft.transform.SetParent(LeftStarSpawn.transform);
			if(mistakes <= 2){
				Debug.Log("Zweite IF");
				spawnedStarCenter = Instantiate(star, CenterStarSpawn.transform.position, Quaternion.identity);
				spawnedStarCenter.transform.SetParent(CenterStarSpawn.transform);
				if(mistakes == 0){
					Debug.Log("Dritte IF");
					spawnedStarRight = Instantiate(star, RightStarSpawn.transform.position, Quaternion.identity);
					spawnedStarRight.transform.SetParent(RightStarSpawn.transform);
				}
			}
		}
		TextfieldMistakes.text = ("Falsche Antworten: " + mistakes);
	}

}
