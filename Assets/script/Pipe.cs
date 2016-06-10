using UnityEngine;
using System.Collections;

public class Pipe : MonoBehaviour {

	private GameObject up, down, left, right; 
	public Material successefullMaterial;
	public Material original;
	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider other) {
		if (other.tag == "pipe") {
			GameObject parent = transform.parent.parent.gameObject;
			parent.GetComponent<Renderer>().material = successefullMaterial;

			Debug.Log ("Collision");
		}

	}

	void OnTriggerExit(Collider other) {
		if (other.tag == "pipe") {
			GameObject parent = transform.parent.parent.gameObject;
			parent.GetComponent<Renderer>().material = original;

			Debug.Log ("Collision");
		}

	}
}
