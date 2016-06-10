using UnityEngine;
using System.Collections;

public class Pipe : MonoBehaviour {

	public Material void_pipe;
	public Material watered_pipe;
	public float fillingTime=5;
	private float frequency = 0.5f;

	private float currentTime,lastTime;
	private GameObject up, down, left, right; 
	private bool filling = true;
	private bool filled = false;

	private Material currentMaterial;
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
