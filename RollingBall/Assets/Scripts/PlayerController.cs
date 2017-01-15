using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
	public float speed = 10;
	public Text countText;
	private Rigidbody rigidBody;
	private int collectibleCount;
	// probably should live in some game manager object or something
	private int numberOfCollectibles;

	void Start () {
		rigidBody = GetComponent<Rigidbody> ();
		collectibleCount = 0;
		numberOfCollectibles = GameObject.FindGameObjectsWithTag ("Pick Up").Length;
		setCountText ();
	}
	
	void FixedUpdate () {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rigidBody.AddForce (movement * speed);
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag ("Pick Up"))
		{
			other.gameObject.SetActive (false);
			collectibleCount++;
			setCountText ();
			if (collectibleCount == numberOfCollectibles) {
				GameObject[] gameObjects = GameObject.FindGameObjectsWithTag ("Disappearing Wall");
				for (int i = 0; i < gameObjects.Length; i++) {
					GameObject disappearingWall = gameObjects [i];
					disappearingWall.SetActive (false);
				}

				//GameObject gameObject = GameObject.FindWithTag ("Disappearing Wall");
				//gameObject.SetActive (false);
			}
		}

		if (other.gameObject.CompareTag ("End Game")) {
			other.gameObject.SetActive (false);
			Text winTextObject = GameObject.FindWithTag ("Win Text").GetComponent<Text>();
			winTextObject.text = "You Win!!!";
		}

		if (other.gameObject.CompareTag ("Teleport")) {
			Teleport teleport = other.GetComponent<Teleport> ();
			transform.position = teleport.destinationObject.transform.position;
//			Vector3 teleportPosition = teleport.destinationObject.transform.position;
//			transform.Translate (teleportPosition);
		}
	}

	void setCountText() {
		countText.text = "Count: " + collectibleCount.ToString ();
	}
}
