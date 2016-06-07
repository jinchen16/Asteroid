using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float maxSpeed = 3f;
	public float speed = 2f;
	public float turnSpeed = 2f;
	public GameObject propeller, teleportPrefab;
	public ParticleSystem particleCtrl;

	private Rigidbody2D rBody;
	private bool isMoving, isTurningLeft, isTurningRight;
	private AudioSource audioSource;

	private bool isWrap;
	private float wrapCounter;
		
	// Use this for initialization
	void Start () {
		//Starting values
		//Iniciar valores
		wrapCounter = 0;
		isWrap = true;
		audioSource = propeller.GetComponent<AudioSource> ();
		isMoving = isTurningLeft = isTurningRight = false;

		//Getting the gameobject rigidbody
		//Obtener el rigidbody del gameobject
		rBody = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (!GameManager.gmControl.isPaused) {
			//Move the character
			//Mover el personaje
			if (Input.GetKey ("w") || isMoving) {
				//Play the moving sound
				//Iniciar el sonido de movimiento
				if(!audioSource.isPlaying){
					audioSource.Play();
					particleCtrl.Play();
				}
				rBody.AddForce (transform.up * speed * Time.deltaTime);
				LimitingSpeed ();
			}else{
				//Stop the moving sound
				//Parar el sonido de movimiento
				if(audioSource.isPlaying){
					audioSource.Stop();
					particleCtrl.Stop();
				}
			}

			//Turn left
			//Girar a la izquierda
			if (Input.GetKey ("a") || isTurningLeft) {
				transform.Rotate (Vector3.forward * Time.deltaTime * turnSpeed);
			}

			//Turn right
			//Girar a la derecha
			else if (Input.GetKey ("d") || isTurningRight) {
				transform.Rotate (-Vector3.forward * Time.deltaTime * turnSpeed);
			}

			//Wrap effect
			//Efecto de portal
			if(Input.GetKeyDown("s") && isWrap){
				isWrap = !isWrap;
				GameObject obj = Instantiate(teleportPrefab, transform.position, Quaternion.identity) as GameObject;
				Destroy(obj, 1f);
				float posX = Random.Range(transform.position.x-5f,transform.position.x+5f);
				float posY = Random.Range(transform.position.y-4f,transform.position.x+4f);
				transform.position = new Vector3(posX, posY, 0);
			}

			checkWrap();

		}
	}

	//Moving the ship with the button
	//Mover la nave con el boton
	public void advance(){
		isMoving = !isMoving;
	}

	//Turning the ship to the left with button
	//Girar la nave a la izquierda con el boton
	public void turnLeft(){
		isTurningLeft = !isTurningLeft;
	}

	//Turning the ship to the right with button
	//Girar la nave a la derecha con el boton
	public void turnRight(){
		isTurningRight = !isTurningRight;
	}

	//Wrap effect
	//Efecto de portal
	public void wrap(){
		if (isWrap) {
			isWrap = false;
			GameObject obj = Instantiate(teleportPrefab, transform.position, Quaternion.identity) as GameObject;
			Destroy(obj, 1f);
			float posX = Random.Range (transform.position.x - 5f, transform.position.x + 5f);
			float posY = Random.Range (transform.position.y - 4f, transform.position.x + 4f);
			transform.position = new Vector3 (posX, posY, 0);
		}
	}

	//Enable wrapping 
	//Activar portal
	void checkWrap(){
		if (!isWrap) {
			wrapCounter += Time.deltaTime;
			if(wrapCounter > 4f){
				isWrap = !isWrap;
				wrapCounter = 0;
			}
		}
	}

	//Method to prevent the infinite speed
	//Metodo para prevenir que la velocidd sea infinita
	void LimitingSpeed(){
		Vector2 speedRigid = rBody.velocity;

		if(rBody.velocity.x > maxSpeed){
			speedRigid.x = 3;
		}else if(rBody.velocity.x < -maxSpeed){
			speedRigid.x = -3;
		}
		if(rBody.velocity.y > maxSpeed){
			speedRigid.y = 3;
		}else if(rBody.velocity.y < -maxSpeed){
			speedRigid.y = -3;
		}
		rBody.velocity = speedRigid;
	}

	//Freeze the velocity
	//Metodo para congelar la velocidad
	public void StopMovement(){
		rBody.velocity = Vector2.zero;
	}
	
}
