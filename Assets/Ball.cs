using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	public GameController gc;


	// Use this for initialization
	void Start () {
		gc = GameObject.FindWithTag ("GameController").GetComponent<GameController> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space) && !gc.running) {
			GetComponent<Rigidbody>().AddForce(Vector3.right * gc.initialBallSpeed);
			gc.running = true;
		}
	}
}
