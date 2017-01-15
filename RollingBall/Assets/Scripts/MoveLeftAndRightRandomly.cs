using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeftAndRightRandomly : MonoBehaviour {
	public float distanceToMove = 100;
	public float speed = 1;

	private float distanceMoved;
	private float target;
	private float xTranslate;
	private float yTranslate;
	private float zTranslate;
	// Use this for initialization
	void Start () {
		distanceMoved = 0;
		target = distanceToMove;
		xTranslate = speed;
		yTranslate = 0;
		zTranslate = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (distanceMoved <= 0) {
			target = distanceToMove;
		}

		if(distanceMoved >= distanceToMove){
			target = 0;
		}

		Vector3 distanceToTranslate;
		if (target == 0) {
			distanceToTranslate = new Vector3 (-xTranslate, -yTranslate, -zTranslate) * Time.deltaTime;
			transform.Translate (distanceToTranslate);
			distanceMoved += distanceToTranslate.x;

		}

		if (target == distanceToMove) {
			distanceToTranslate = new Vector3 (xTranslate, yTranslate, zTranslate) * Time.deltaTime;
			transform.Translate (distanceToTranslate);
			distanceMoved += distanceToTranslate.x;
		}

	}
}
