using UnityEngine;
using System.Collections;

public class CollisionDetection : MonoBehaviour {

	public Material successefullMaterial;
	public Material voidMaterial;
	private Pipe pipe;
//	public float deleteColliderTime = 1.0f;
	public float delayClone=3;
	private bool clonable =false;
	private float time;
	// Use this for initialization
	void Start () {
		Debug.Log (transform.parent);
		pipe = gameObject.GetComponentInParent<Pipe>();
		//if (!pipe.isFixed) changeSateCollider (false);
		time = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (time < delayClone)
			time += Time.deltaTime;
		else if (!clonable)
			clonable = true;
//		if (time < deleteColliderTime) {
//			time += Time.deltaTime;
//		} else if (!GetComponent<BoxCollider> ().enabled && !pipe.isFixed	) {
//			changeSateCollider (true);
//		}
	}

	void OnTriggerEnter(Collider other) {
		Debug.Log ("distance" + (other.transform.parent.position - transform.parent.position).magnitude);
		if ((other.transform.parent.position - transform.parent.position).magnitude < 0.3)
			return;
		if (pipe.hasNextPipe()) 
			return;
		
		if (clonable && other.tag == "pipe") {
			changeMaterial (successefullMaterial);
			if (pipe.isFixed) {
				Debug.Log ("Enter");
				GameObject nextPipeGO = other.transform.parent.gameObject;
				changeSateCollider (false);
				pipe.addNextPipe (nextPipeGO);
			}
			Debug.Log ("Collision enter");
		}
		if (pipe.hasNextPipe ()) {
			pipe.fixChild ();

		}
	}

	void OnTriggerExit(Collider other) {
		if (pipe.hasNextPipe()) 
			return;
		if (other.tag == "pipe") {
			pipe.changeMaterial (voidMaterial);
		}
		/*
		if (other.tag == "pipe") {
			changeMaterial (voidMaterial);
			Pipe pipe = gameObject.GetComponentInParent<Pipe>();
			if (pipe.GetNextPipe() != null)
				pipe.setNextPipe (null);
			if (pipe.isFixed && !pipe.isApertura)
				pipe.isFixed = false;
			Debug.Log ("Collision exit");
		}
		*/

	}

	private void changeMaterial(Material material){
		
		//Pipe pipe = gameObject.GetComponentInParent<Pipe> ();
		pipe.changeMaterial (material);
		Transform pipeTransform = gameObject.GetComponentInParent<Transform> ();
		//pipe.addNextPipe (pipeTransform.parent);
	}

	public void changeSateCollider(bool state) {
		GetComponent<BoxCollider> ().enabled = state;
		GetComponent<Rigidbody> ().isKinematic = state;
	}
}
