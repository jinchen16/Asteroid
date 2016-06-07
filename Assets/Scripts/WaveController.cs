using UnityEngine;
using System.Collections;

public class WaveController : MonoBehaviour {

	public static WaveController wvCtrl;
	private int asteroidCount;

	public float spawnWait = 0.5f;
	public float waveWait = 1f;
	public float startWait = 3f;

	public int level = 0;

	public GameObject asteroidPrefab;
	 
	void Awake(){
		wvCtrl = this;
	}

	// Use this for initialization
	void Start () {
		asteroidCount = transform.childCount;
		StartCoroutine (spawnWaves ());
	}
	
	// Update is called once per frame
	void FixedUpdate () {

	}

	IEnumerator spawnWaves(){
		yield return new WaitForSeconds (startWait);
		while (true) {
			if (!GameManager.gmControl.isPaused) {
				if (asteroidCount == 0) {
					for(int i = 0; i < level; i++){
						GameObject obj = Instantiate(asteroidPrefab, transform.position, Quaternion.identity) 
							as GameObject;
						obj.transform.SetParent(this.transform);
					}
					asteroidCount = transform.childCount;

					yield return new WaitForSeconds (spawnWait);

					level++;
				}
			}
			yield return new WaitForSeconds (waveWait);
		}
	}

	public void AsteroidReCount(){
		asteroidCount = transform.childCount - 1;
	}
}
