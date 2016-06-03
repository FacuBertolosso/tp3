using UnityEngine;
using System.Collections;

public class Pipe : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider other) {
		if (other.tag == "pipe") {
			Debug.Log ("Collision");
		}

		//Destroy(other.gameObject);
	}
}
