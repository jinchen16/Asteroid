using UnityEngine;
using System.Collections;

public class MidAsteroidBehaviour : MonoBehaviour {

	public GameObject smallAsteroidPrefab;
	
	private AsteroidMovement asteroidBeh;

	// Use this for initialization
	void Start () {
		//Getting the AsteroidMovement component
		//Obtener el componente AsteroidMovement
		asteroidBeh = GetComponent<AsteroidMovement> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D col){
		//Condition when the bullet faces an asteroid
		//Condicion cuando la bala enfrenta un asteroide
		if (col.tag == "bullet") {
			Destroy(gameObject);

			//Getting the shootPower
			//Obtener el shootPower
			float shootPower = col.gameObject.GetComponent<BulletBehaviour>().shootPower;
			
			if(shootPower >= 0 && shootPower < 50){
				//Calculating the score
				//Calcular el puntaje
				GameManager.gmControl.score += 135;

				//Creating the asteroids
				//Crear los asterides
				asteroidBeh.createAsteroids(3, smallAsteroidPrefab, 0.02f);
			}else if(shootPower >= 50 && shootPower < 75){
				//Calculating the score
				//Calcular el puntaje
				GameManager.gmControl.score += (135 + 240);

				//Creating the asteroids
				//Crear los asterides
				asteroidBeh.createAsteroids(2, smallAsteroidPrefab, 0.02f);
			}else if(shootPower >= 75 && shootPower < 101){
				//Calculating the score
				//Calcular el puntaje
				GameManager.gmControl.score += ((135) + (2*240));

				//Creating the asteroids
				//Crear los asterides
				asteroidBeh.createAsteroids(1, smallAsteroidPrefab, 0.02f);
			}
			
			//Checking the asteroids' number when it is destroyed
			//Analisis del numero de asteroides cuando es destruido
			WaveController.wvCtrl.AsteroidReCount();
		}
	}
}
