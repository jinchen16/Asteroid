using UnityEngine;
using System.Collections;

public class BulletBehaviour : MonoBehaviour {

	public float maxSpeed = 5f;
	public float shootPower;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (!GameManager.gmControl.isPaused) {
			Vector3 pos = transform.position;
			Vector3 speed = new Vector3 (0, maxSpeed * Time.deltaTime, 0);
			pos += transform.rotation * speed;
			transform.position = pos;
		}
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.tag == "enemy") {
			AudioControl.audioCtrl.playSound();
			Destroy(gameObject);
		}
	}
}
