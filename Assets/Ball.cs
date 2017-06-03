using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	public GameController gc;

	private Rigidbody rb;


	// Use this for initialization
	void Start () {
		gc = gc ?? GameObject.FindWithTag ("GameController").GetComponent<GameController> ();
		rb = rb ?? GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space) && !gc.running) {
			int upDownForce = Random.Range (-2, 2);

			rb.velocity = (Vector3.right * gc.initialBallSpeed + Vector3.up * (((float) upDownForce) / 5.0f) * gc.initialBallSpeed);
			gc.running = true;
		}

		// Check position to reflect on upper and lower bound
		if (Mathf.Abs(transform.position.y) >= gc.maxY) {
			rb.velocity = new Vector3(rb.velocity.x, -rb.velocity.y, 0);
		}

		// Check if someone has won
		if (Mathf.Abs (transform.position.x) > gc.maxX) {
			// Player 2 wins
			if (transform.position.x < gc.maxX) {
				gc.player2Win ();
			}

			// Player 1 wins
			if (transform.position.x > gc.maxX) {
				gc.player1Win ();
			}
		}
	}
		
	void OnTriggerEnter(Collider other) {
		if (other.tag == "Player") {
			float displacement = other.GetComponent<Controller> ().curSpeed;
			rb.velocity = new Vector3 (-rb.velocity.x, rb.velocity.y + displacement * 20, 0);
		}
	}

}
