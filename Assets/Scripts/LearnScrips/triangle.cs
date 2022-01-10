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


	private GameObject spawnedObject;

	//3 = bottom 3 bricks, 4 = bottom 4 bricks, 5 = bottom 5 bricks
	private int triangleSize = 5;




	// Start is called before the first frame update
	void Start()
	{
		if(triangleSize == 3){
			playGame(triangleSize);
		}
		else if(triangleSize == 4){
			playGame(triangleSize);
		}
		else if(triangleSize == 5){
			playGame(triangleSize);
		}
	}


	public void playGame(int triangleSize){
		for (int i = triangleSize; i > 0; i--){
			spawnPyramidRow(i);
		}
	}

	public void spawnPyramidRow(int brickAmmount){
		for (int i = 0; i < brickAmmount; i++){
			spawnedObject = Instantiate(brick, triangleGameObject.transform.position, Quaternion.identity);
			spawnedObject.name += i;
			spawnedObject.transform.SetParent(triangleGameObject.transform.GetChild(brickAmmount - 1));
		}
	}

}
