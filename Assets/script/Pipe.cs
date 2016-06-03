using UnityEngine;
using System.Collections;

public class Pipe : MonoBehaviour {

	private GameObject up, down, left, right; 

	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider other) {
		if (other.tag == "pipe") {
			Vector3 myDirection = this.gameObject.transform.forward;
			Vector3 otherDirection = other.gameObject.transform.forward;

			float angle = Vector3.Angle(otherDirection, myDirection);

			if (angle < 90) {
				Debug.Log ("up");	
			} else if (angle >= 90) {
				Debug.Log ("right");	
			} else if (angle > 180) {
				Debug.Log ("left");	
			} else if (angle > 270) {
				Debug.Log ("down");	
			}

			Debug.Log ("Collision");
		}

		//Destroy(other.gameObject);
	}
}
