using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
	public float maxY = 5;

	public float maxX = 10;

	public bool running = false;

	public float initialBallSpeed = 5f;

	public int winPoints = 10;

	public int points1 = 0;

	public int points2 = 0;

	private Ball ball;

	// Use this for initialization
	void Start () {
		ball = ball ?? GameObject.FindWithTag ("Ball").GetComponent<Ball>();
		newGame ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space) && running) {
			newGame ();
		}
	}

	public void player1Win() {
		Debug.Log ("Player 1 Win");
		points1++;
		newGame ();
	}

	public void player2Win() {
		Debug.Log ("Player 2 Win");
		points2++;
		newGame ();
	}

	void newGame() {
		ball.transform.position = Vector3.zero;
		ball.GetComponent<Rigidbody> ().velocity = Vector3.zero;
		foreach (GameObject player in GameObject.FindGameObjectsWithTag("Player")) {
			player.GetComponent<Controller> ().reset ();
		}
		updateScore ();
		running = false;
	}

	void updateScore() {
		GameObject.Find ("Score1").GetComponent<TextMesh> ().text = points1.ToString();
		GameObject.Find ("Score2").GetComponent<TextMesh> ().text = points2.ToString();
	}
}
