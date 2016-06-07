using UnityEngine;
using System.Collections;

public class PlayerBehaviour : MonoBehaviour {

	public GameObject bullet, shootPos, megaBullet;
	private Vector3 posIni;
	private Quaternion rotIni;
	private PlayerMovement playerMovement;

	public AudioClip shootClip, deathClip;

	private AudioSource audioSource;
	private bool megaShoot;
	private float shootPower;
	private Vector3 megaBulletIni;

	// Use this for initialization
	void Start () {
		megaBulletIni = megaBullet.transform.localScale;
		megaShoot = false;
		audioSource = GetComponent<AudioSource> ();
		playerMovement = GetComponent<PlayerMovement> ();
		posIni = transform.position;
		rotIni = transform.rotation;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetKey ("space") || megaShoot) {
			calculateShootPower();
		} else if (Input.GetKeyUp ("space")) {
			megaShoot = false;
			shoot();
		}

		if (megaBullet.transform.localScale.x > megaBulletIni.x + 1f) {
			megaBullet.transform.localScale = megaBulletIni;
		}
	}

	//Shooting 
	public void shoot(){
		megaBullet.SetActive (false);

		playSound (shootClip);

		GameObject bulletObj = (GameObject)Instantiate (bullet, shootPos.transform.position, transform.rotation);
		bulletObj.transform.localScale = megaBullet.transform.localScale;
		if (shootPower > 100) {
			shootPower = 0;
		}
		bulletObj.GetComponent<BulletBehaviour> ().shootPower = shootPower;

		megaBullet.transform.localScale = megaBulletIni;
		shootPower = 0;

		Destroy (bulletObj, 3);		
	}

	public void calculateShootPower(){
		megaBullet.SetActive (true);

		shootPower += 25 * Time.deltaTime;
		megaBullet.transform.localScale = new Vector3 (megaBulletIni.x + shootPower * 0.01f, 
		                                               megaBulletIni.y + shootPower * 0.01f, 
		                                               megaBulletIni.z + shootPower * 0.01f);
	}

	//Play sound by adding the audio clip
	public void playSound(AudioClip audioClip){
		audioSource.clip = audioClip;
		audioSource.Play ();
	}

	public void activateMegaShoot(){
		megaShoot = true;
	}

	public void releaseMegaShoot(){
		megaShoot = false;
		shoot ();
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.tag == "enemy") {
			playSound (deathClip);
			transform.position = posIni;
			transform.rotation = rotIni;
			playerMovement.StopMovement();
			UICtrl.uiControl.DropLive();
		}
	}
}
