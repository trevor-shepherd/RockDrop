using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class GameManager : MonoBehaviour {

	static public float currentScore;
	static public float highScore;
	static public bool missedGate;
    static public bool offScreen;
	public Text currentScoreText;
	public Text continueText;
	public Text endScoreText;

	private MovingObstacle playerMovement;
	private Spawner spawner;
	private Spawner gateSpawner;
	private RockDrop rockDrop;
    private GameObject player;
	private bool gameStarted;
	private bool charSelect;
	private Vector3 startPos = new Vector3 (0,28,0);
	private Vector3 floatPos = new Vector3 (0,12,0);


	// Use this for initialization
	void Awake () {

		spawner = GameObject.Find ("Spawner").GetComponent<Spawner> ();
		gateSpawner = GameObject.Find ("GateSpawner").GetComponent<Spawner> ();
		rockDrop = GameObject.Find ("Main Camera").GetComponent<RockDrop> ();
        playerMovement = GameObject.Find("Player 1").GetComponent<MovingObstacle>();
        player = GameObject.Find("Player 1");
	}
	
	void Start () {

		gameStarted = false;
        player.SetActive(false);
		spawner.active = false;
		gateSpawner.active = false;
		rockDrop.enabled = false;
        playerMovement.enabled = false;
        charSelect = true;
        offScreen = false;


		Time.timeScale = 1;

		continueText.canvasRenderer.SetAlpha (0);
		currentScoreText.canvasRenderer.SetAlpha (0);
		endScoreText.canvasRenderer.SetAlpha (0);
	}

	void Update () {
		
		if (!gameStarted && !charSelect) {

			if (Input.anyKeyDown) {
				
				ResetGame ();
			}

		}

		currentScoreText.text = (currentScore.ToString());

	
		if (missedGate || offScreen) {

			OnPlayerKill ();
		}

	}

	void OnPlayerKill () {

		spawner.active = false;
		gateSpawner.active = false;
		rockDrop.enabled = false;
        

        gameStarted = false;
		missedGate = false;
        offScreen = false;

		StartCoroutine (WashAway());

		continueText.text = "CLICK TO START";

		if (currentScore > highScore) {

			highScore = currentScore;
			PlayerPrefs.SetFloat ("HighScore", highScore);
		}


		endScoreText.text = "Score: " + currentScore + "\nBest Score: " + highScore;
		endScoreText.canvasRenderer.SetAlpha (255);
		continueText.canvasRenderer.SetAlpha (255);
		currentScoreText.canvasRenderer.SetAlpha (0);

	}
		
	private IEnumerator WashAway()
	{
		yield return new WaitForSeconds (1f);
		Time.timeScale = 6;
        playerMovement.enabled = true;

        yield return StartCoroutine(CoroutineUtil.WaitForRealSeconds(2));

		Time.timeScale = 1;
	}

	public void ResetGame () {

        player.active = true;
        spawner.active = true;
		gateSpawner.active = true;
		rockDrop.enabled = true;
        playerMovement.enabled = false;
        charSelect = false;

		currentScore = 0;

		gameStarted = true;

		continueText.canvasRenderer.SetAlpha (0);
		endScoreText.canvasRenderer.SetAlpha (0);
		currentScoreText.canvasRenderer.SetAlpha (255);
	}

}
