using UnityEngine;
using System.Collections;

public class CollisionDetection : MonoBehaviour {

	public Material successefullMaterial;
	public Material voidMaterial;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == "pipe") {
			changeMaterial (successefullMaterial);
			Pipe pipe = gameObject.GetComponentInParent<Pipe>(); 
			if (pipe.isFixed) {
				Debug.Log ("Enter");
				GameObject nextPipeGO = other.transform.parent.gameObject;
				nextPipeGO.GetComponentInParent<Pipe> ().isFixed = true;
				pipe.setNextPipe (nextPipeGO);
			}
			Debug.Log ("Collision enter");
		}

	}

	void OnTriggerExit(Collider other) {
		if (other.tag == "pipe") {
			changeMaterial (voidMaterial);
			Pipe pipe = gameObject.GetComponentInParent<Pipe>();
			if (pipe.GetNextPipe() != null)
				pipe.setNextPipe (null);
			if (pipe.isFixed && !pipe.isApertura)
				pipe.isFixed = false;
			Debug.Log ("Collision exit");
		}

	}

	private void changeMaterial(Material material){
		
		foreach (Renderer render in GetComponentsInParent<Renderer>()) {
			if (render != null)
				render.material = material;
		}
	}
}
