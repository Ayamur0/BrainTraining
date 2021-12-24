using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class triangle : MonoBehaviour
{

	public GameObject brick;

	//rows of the triangle
	public GameObject gameObject00;
	public GameObject gameObject01;
	public GameObject gameObject02;
	public GameObject gameObject03;
	public GameObject gameObject04;


	private GameObject spawnedObject;

	//0 = bottom 3 bricks, 1 = bottom 4 bricks, 2 = bottom 5 bricks
	private int triangleSize = 0;




	// Start is called before the first frame update
	void Start()
	{
		playGame(triangleSize);
	}


	public void playGame(int gameMode){
		if(gameMode == 0){
			spawnPyramid(3, gameObject02);
			spawnPyramid(2, gameObject03);
			spawnPyramid(1, gameObject04);
		}
		else if(gameMode == 1){
			spawnPyramid(4, gameObject01);
			spawnPyramid(3, gameObject02);
			spawnPyramid(2, gameObject03);
			spawnPyramid(1, gameObject04);
		}
		else if(gameMode == 2){
			spawnPyramid(5, gameObject00);
			spawnPyramid(4, gameObject01);
			spawnPyramid(3, gameObject02);
			spawnPyramid(2, gameObject03);
			spawnPyramid(1, gameObject04);
		}
	}

	public void spawnPyramid(int brickAmmount, GameObject row){
		for (int i = 0; i < brickAmmount; i++){
			spawnedObject = Instantiate(brick, row.transform.position, Quaternion.identity);
			spawnedObject.name += i;
			spawnedObject.transform.SetParent(row.transform.GetChild(i));
		}
	}

}
