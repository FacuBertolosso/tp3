using UnityEngine;
using System.Collections;

public class Pipe : MonoBehaviour {

	public Material void_pipe;
	public Material watered_pipe;
	public float fillingTime=5;
	private float frequency = 0.5f;

	private float currentTime,lastTime;
	public Material successefullMaterial;
	private Material currentMaterial;
	private bool filling = true;
	private bool filled = false;

	// Use this for initialization
	void Start () {
		currentMaterial =void_pipe;
		currentTime = 0;
		lastTime = frequency+1;
	}

	// Update is called once per frame
	void Update () {
		if (filling) {
			currentTime += Time.deltaTime;
			if ((currentTime<fillingTime)&&((currentTime-lastTime)>frequency)) {
				lastTime = currentTime;
				swapMaterial ();
			}
		}
		if (!filled && (currentTime > fillingTime)) {
			filled = true;
			filling = false;
		}
		if (filled &&(currentMaterial.Equals(void_pipe))){
			swapMaterial ();
		}
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
			parent.GetComponent<Renderer>().material = currentMaterial;

			Debug.Log ("Collision");
		}

	}
	private void swapMaterial(){
		if (currentMaterial.Equals (void_pipe)) {
			currentMaterial = watered_pipe;
		} else {
			currentMaterial = void_pipe;
		}
		foreach (Transform child in transform)
		{
			//if (child.GetComponent<Renderer>()!=null)
				child.GetComponent<Renderer>().material = currentMaterial;
		}
	}
}
