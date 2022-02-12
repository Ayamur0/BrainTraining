using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;



public class MenuPickLevel : MonoBehaviour
{
	//Buttons
	// public Button back;
	// public Button quantities;
	// public Button mathOperations;
	// public Button triangle;
	// public Button lightnigView;
	// public Button pattern;
	// public Button mixedWords;
	public Button[] buttonsMenu = new Button[7];

	public enum LvlType{
		BACK = 1,
		QUANTITIES = 2,
		MATHOPERATIONS = 3,
		TRIANGLE = 4,
		LIGHTNIGVIEW = 5,
		PATTER = 6,
		MIXEDWORDS = 7
	}
	//const int BACK = 1;
	//const int QUANTITIES = 2;
	//const int TRIANGLE = 3;
	//const int MATHOPERATIONS = 4;
	//const int LIGHTNIGVIEW = 5;
	//const int PATTER = 6;
	//const int MIXEDWORDS = 7;

	public static int loadButtonsPrefab = 0;

	void Start()
	{
		Debug.Log(buttonsMenu.Length);
		for (int i = 0; i < buttonsMenu.Length; i++){
			int temp = i;
			buttonsMenu[temp].onClick.AddListener(() => loadAdvancedOptions((LvlType)temp + 1));
		}

		// back.onClick.AddListener(() => loadAdvancedOptions(BACK));
		// quantities.onClick.AddListener(() => loadAdvancedOptions(QUANTITIES));
		// mathOperations.onClick.AddListener(() => loadAdvancedOptions(MATHOPERATIONS));
		// triangle.onClick.AddListener(() => loadAdvancedOptions(TRIANGLE));
		// lightnigView.onClick.AddListener(() => loadAdvancedOptions(LIGHTNIGVIEW));
		// pattern.onClick.AddListener(() => loadAdvancedOptions(PATTER));
		// mixedWords.onClick.AddListener(() => loadAdvancedOptions(MIXEDWORDS));
	}

	public void loadAdvancedOptions(LvlType choice){
		switch (choice)
		{
			case LvlType.BACK:
				loadButtonsPrefab = (int)LvlType.BACK;
				SceneManager.LoadScene("MainMenu");
				break;
			case LvlType.QUANTITIES:
				loadButtonsPrefab = (int)LvlType.QUANTITIES;
				SceneManager.LoadScene("MenuLearingAdvancedOptions");
				break;
			case LvlType.MATHOPERATIONS:
				loadButtonsPrefab = (int)LvlType.MATHOPERATIONS;
				SceneManager.LoadScene("MenuLearingAdvancedOptions");
				break;
			case LvlType.TRIANGLE:
				loadButtonsPrefab = (int)LvlType.TRIANGLE;
				SceneManager.LoadScene("MenuLearingAdvancedOptions");
				break;
			case LvlType.LIGHTNIGVIEW:
				loadButtonsPrefab = (int)LvlType.LIGHTNIGVIEW;
				SceneManager.LoadScene("MenuLearingAdvancedOptions");
				break;
			case LvlType.PATTER:
				loadButtonsPrefab = (int)LvlType.PATTER;
				SceneManager.LoadScene("MenuLearingAdvancedOptions");
				break;
			case LvlType.MIXEDWORDS:
				loadButtonsPrefab = (int)LvlType.MIXEDWORDS;
				SceneManager.LoadScene("MenuLearingAdvancedOptions");
				break;

			default:
				break;
		}
	}

}
