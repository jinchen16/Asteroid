using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public static GameManager gmControl;
	public bool isPaused;

	public int score;

	public int lives = 3;

	void Awake(){
		gmControl = this;
		isPaused = false;
		lives = 3;
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}
}
