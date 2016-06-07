using UnityEngine;
using System.Collections;

public class SmallAsteroidBehaviour : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D col){
		//Condition when the bullet faces an asteroid
		if (col.tag == "bullet") {
			Destroy (gameObject);
	
			//Calculating the score
			GameManager.gmControl.score += 240;
						
			//Checking the asteroids' number when it is destroyed
			WaveController.wvCtrl.AsteroidReCount ();
		}
	}
}
