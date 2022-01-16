using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class MenuPickLevel : MonoBehaviour
{
	//Buttons
	public Button menu;
	public Button back;
	public Button quantities;
	public Button mathOperations;
	public Button triangle;
	public Button lightnigView;
	public Button pattern;
	public Button mixedWords;

	const int MENU = 0;
	const int BACK = 1;
	const int QUANTITIES = 2;
	const int TRIANGLE = 3;
	const int MATHOPERATIONS = 4;
	const int LIGHTNIGVIEW = 5;
	const int PATTER = 6;
	const int MIXEDWORDS = 7;


	public static int loadButtonsPrefab = 0;

	void Start()
	{
		menu.onClick.AddListener(() => loadAdvancedOptions(MENU));
		back.onClick.AddListener(() => loadAdvancedOptions(BACK));
		quantities.onClick.AddListener(() => loadAdvancedOptions(QUANTITIES));
		mathOperations.onClick.AddListener(() => loadAdvancedOptions(MATHOPERATIONS));
		triangle.onClick.AddListener(() => loadAdvancedOptions(TRIANGLE));
		lightnigView.onClick.AddListener(() => loadAdvancedOptions(LIGHTNIGVIEW));
		pattern.onClick.AddListener(() => loadAdvancedOptions(PATTER));
		mixedWords.onClick.AddListener(() => loadAdvancedOptions(MIXEDWORDS));
	}

	public void loadAdvancedOptions(int choice){
		switch (choice)
		{
			case MENU:
				loadButtonsPrefab = MENU;
				SceneManager.LoadScene("MenuLearingAdvancedOptions");
				break;
			case BACK:
				loadButtonsPrefab = BACK;
				SceneManager.LoadScene("MenuLearingAdvancedOptions");
				break;
			case QUANTITIES:
				loadButtonsPrefab = QUANTITIES;
				SceneManager.LoadScene("MenuLearingAdvancedOptions");
				break;
			case MATHOPERATIONS:
				loadButtonsPrefab = MATHOPERATIONS;
				SceneManager.LoadScene("MenuLearingAdvancedOptions");
				break;
			case TRIANGLE:
				loadButtonsPrefab = TRIANGLE;
				SceneManager.LoadScene("MenuLearingAdvancedOptions");
				break;
			case LIGHTNIGVIEW:
				loadButtonsPrefab = LIGHTNIGVIEW;
				SceneManager.LoadScene("MenuLearingAdvancedOptions");
				break;
			case PATTER:
				loadButtonsPrefab = PATTER;
				SceneManager.LoadScene("MenuLearingAdvancedOptions");
				break;
			case MIXEDWORDS:
				loadButtonsPrefab = MIXEDWORDS;
				SceneManager.LoadScene("MenuLearingAdvancedOptions");
				break;

			default:
				break;
		}
	}

}
