using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonsBehaviour : MonoBehaviour
{
	public GameObject dummy;
	private GameQuantities game;
	private FinishScreen finish;
	private int solutionSymbol = 0;
	public Text Textfield;

	void Start(){
		game = dummy.GetComponent<GameQuantities>();
	}

	//enum machen
	enum solution {Less = '<', Equals = '=', Greater = '>'};
	public void ShowSolution(int solutionNumber){
		game.Solution(solutionNumber);
		Debug.Log((char)solutionNumber);
		solutionSymbol = solutionNumber;
		Textfield.text = ((char)solutionNumber).ToString();
		if(game.getAndSetCounterRound <= game.getAndSetLvlNumber){
			game.SetLevelText();
		}
	}


}