using UnityEngine;
using System.Collections;

public class AsteroidMovement : MonoBehaviour {

	public float maxSpeed = 0.5f;
	public float turnSpeed = 15f;
	private int rotFactor, posFactorX, posFactorY;

	public float offset;

	// Use this for initialization
	void Start () {
		maxSpeed = Random.Range (0.2f, 0.8f);
		//Array with the values
		int[] values = new int[]{-1,1,-1,1};

		//Getting random value for controlling the movement
		rotFactor = values [Random.Range (0, 2)];
		posFactorX = values [Random.Range (0, 4)];
		posFactorY = values [Random.Range (0, 4)];

	}
	
	// Update is called once per frame
	void Update () {
		if (!GameManager.gmControl.isPaused) {
			//Keep asteroid rotation
			transform.Rotate (rotFactor * Vector3.forward * Time.deltaTime * turnSpeed);
		
			//Moving the asteroid
			Vector3 speed = new Vector3 (posFactorX * maxSpeed * Time.deltaTime, posFactorY * maxSpeed * Time.deltaTime, 0);
			transform.position += speed;
		}
	}

	//Method to create Asteroids
	public void createAsteroids(int quantity, GameObject obj, float offset){
		for(int i = 0; i < quantity; i++){
			GameObject prefab = (GameObject) Instantiate(obj, 
			                                             transform.position + new Vector3(i*offset,i*offset,0), 
			                                             transform.rotation);
			prefab.transform.SetParent(GameObject.Find("Asteroids").transform);
		}
	}
}
