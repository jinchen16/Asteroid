using UnityEngine;
using System.Collections;

public class AudioControl : MonoBehaviour {

	public static AudioControl audioCtrl;

	private AudioSource audioSource;

	// Use this for initialization
	void Start () {
		audioCtrl = this;
		audioSource = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//Condition when an asteroid is destroyed
	//Condicion cuando un asteroide es destruido
	public void playSound(){
		audioSource.Play ();
	}
}
