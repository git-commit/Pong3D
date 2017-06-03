using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {

	public KeyCode upKey = KeyCode.W;
	public KeyCode downKey = KeyCode.S;
	public KeyCode lastKey;
	public float speed = 10f;

	public GameController gc;

	// Use this for initialization
	void Start () {
		gc = GameObject.FindWithTag ("GameController").GetComponent<GameController> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (upKey) && Input.GetKey (downKey)) {
			move (lastKey);
		}
		else if(Input.GetKey(upKey)) {
			lastKey = upKey;
			move(upKey);
		}
		else if(Input.GetKey(downKey)) {
			lastKey = downKey;
			move(downKey);	
		}
	}

	void move(KeyCode k) {
		if (k == upKey) {
			moveUp ();
		} else if (k == downKey) {
			moveDown ();
		}
	}

	void moveUp() {
		Vector3 newPos = transform.position + Vector3.up * speed * Time.deltaTime;
		if (Mathf.Abs (newPos.y) < gc.maxY)
			transform.position = newPos;
	}

	void moveDown() {
		Vector3 newPos = transform.position + Vector3.down * speed * Time.deltaTime;
		if (Mathf.Abs (transform.position.y) < gc.maxY)
			transform.position = newPos;
	}
		
}
