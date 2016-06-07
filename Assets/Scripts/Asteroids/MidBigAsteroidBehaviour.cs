using UnityEngine;
using System.Collections;

public class MidBigAsteroidBehaviour : MonoBehaviour {

	public GameObject smallAsteroidPrefab, midAsteroidPrefab;

	private AsteroidMovement asteroidBeh;

	// Use this for initialization
	void Start () {
		asteroidBeh = GetComponent<AsteroidMovement> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D col){
		//Condition when the bullet faces an asteroid
		if (col.tag == "bullet") {
			Destroy(gameObject);

			//Getting the shootPower
			float shootPower = col.gameObject.GetComponent<BulletBehaviour>().shootPower;
			
			if(shootPower >= 0 && shootPower < 50){
				//Calculating the score
				GameManager.gmControl.score += 62;

				//Creating the asteroids
				asteroidBeh.createAsteroids(3, midAsteroidPrefab, 0.2f);
			}else if(shootPower >= 50 && shootPower < 101){
				//Calculating the score
				GameManager.gmControl.score += ((2*135) + 62);

				//Creating the asteroids
				asteroidBeh.createAsteroids(6, smallAsteroidPrefab, 0.2f);
				asteroidBeh.createAsteroids(1, midAsteroidPrefab, 0.2f);
			}
			
			//Checking the asteroids' number when it is destroyed
			WaveController.wvCtrl.AsteroidReCount();
		}		
	}
}
