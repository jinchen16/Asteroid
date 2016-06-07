using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UICtrl : MonoBehaviour {

	public Text scoreText;
	public Text scoreGameOverText;
	public Image [] lives;
	public GameObject uiPause, uiGameOver;

	public static UICtrl uiControl;
	private int scoreAux;
	// Use this for initialization
	void Start () {
		if (uiPause != null && uiGameOver != null) {
			ConditionState (false, uiPause, false);
			ConditionState (false, uiGameOver, false);
		}
		uiControl = this;
		scoreAux = 0;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Application.loadedLevelName == "Game") {
			if (!GameManager.gmControl.isPaused) {
				if (scoreAux >= GameManager.gmControl.score) {
					scoreText.text = GameManager.gmControl.score.ToString ();
				} else {
					scoreAux += 11;
					scoreText.text = scoreAux.ToString ();
				}
			}
		}
	}

	public void DropLive(){
		GameManager.gmControl.lives -= 1;
		lives [GameManager.gmControl.lives].gameObject.SetActive (false);

		if (GameManager.gmControl.lives == 0 && lives.Length > 0) {
			ConditionState (true, uiGameOver, true);
			scoreGameOverText.text = GameManager.gmControl.score.ToString ();
		}
	}

	public void Restart(){
		Application.LoadLevel (Application.loadedLevel);
	}

	public void PauseState(){
		ConditionState (true, uiPause, true);
	}

	public void GameState(GameObject uiElement){
		ConditionState (false, uiElement, false);
	}

	public void ConditionState(bool isPaused, GameObject uiElement, bool uiElementCond){
		GameManager.gmControl.isPaused = isPaused;
		uiElement.SetActive (uiElementCond);
	}

	public void PlayScene(string scene){
		Application.LoadLevel (scene);
	}
}
