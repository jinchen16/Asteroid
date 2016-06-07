﻿using UnityEngine;
using System.Collections;

public class BigAsteroidBehaviour : MonoBehaviour {

	public GameObject bigmidAsteroidPrefab, midAsteroidPrefab, smallAsteroidPrefab;

	private int posFactorX, posFactorY;
	private AsteroidMovement asteroidBeh;

	// Use this for initialization
	void Start () {
		//Initializing the big asteroid
		//Array with the values
		int[] values = new int[]{-1,1};

		//Getting the AsteroidMovement component
		asteroidBeh = GetComponent<AsteroidMovement> ();

		//Getting random value for controlling the movement
		posFactorX = values [Random.Range (0, 2)];
		posFactorY = values [Random.Range (0, 2)];

		//Random position in the screen for the big asteroid
		transform.position = new Vector3 (posFactorX*Random.Range (3, 7), posFactorY * Random.Range (2, 3.5f), 0);
	}
	
	// Update is called once per frame
	void FixedUpdate () {

	}

	void OnTriggerEnter2D(Collider2D col){
		//Condition when the bullet faces an asteroid
		if (col.tag == "bullet") {
			Destroy(gameObject);

			//Getting the shootPower
			float shootPower = col.gameObject.GetComponent<BulletBehaviour>().shootPower;

			if(shootPower >= 0 && shootPower < 50){
				GameManager.gmControl.score += 25;
				//Getting the method from AsteroidBehaviour
				asteroidBeh.createAsteroids(3, bigmidAsteroidPrefab, 0.2f);

			}else if(shootPower >= 50 && shootPower < 101){
				//Calculating the score
				GameManager.gmControl.score += ((6*135) + (2*62) + 25);

				//Creating the asteroids
				asteroidBeh.createAsteroids(9, smallAsteroidPrefab, 0.02f);
				asteroidBeh.createAsteroids(3, midAsteroidPrefab, 0.1f);
				asteroidBeh.createAsteroids(1, bigmidAsteroidPrefab, 0.3f);
			}

			//Checking the asteroids' number when it is destroyed
			WaveController.wvCtrl.AsteroidReCount();
		}

	}
}

