using UnityEngine;
using System.Collections;

public class Pipe : MonoBehaviour {

	public Material void_pipe;
	public Material watered_pipe;
	private Material currentMaterial;
	public float fillingTime=5;
	public float frequency = 0.5f;

	private float currentTime,lastTime;
	private bool filling = false;
	private bool filled = false;
	public bool isFixed;
	public bool isApertura = false;

	private GameObject nextPipe;

	// Use this for initialization
	void Start () {
		currentTime = 0;
		lastTime = frequency+1;
		currentMaterial = void_pipe;
		if (isApertura) isFixed = true;
	}

	// Update is called once per frame
	void Update () {
		if (filling) {
			currentTime += Time.deltaTime;
			if ((currentTime < fillingTime) && ((currentTime - lastTime) > frequency)) {
				lastTime = currentTime;
				swapMaterial ();
			}
		}
		if (!filled && (currentTime > fillingTime)) {
			filled = true;
			filling = false;
			fillNext ();
		}
		if (filled &&(currentMaterial.Equals(void_pipe))){
			swapMaterial ();
		}

	}

	private void swapMaterial(){
		if (currentMaterial.Equals(void_pipe)) {
			currentMaterial = watered_pipe;
		} else {
			currentMaterial = void_pipe;
		}
		changeMaterial (currentMaterial);
	}

	private void changeMaterial(Material material){
		foreach (Transform child in transform) {
			if (child.GetComponent<Renderer>()!=null)
				child.GetComponent<Renderer> ().material = material;
		}
	}

	public void fill() {
		filling = true;
		Debug.Log ("Filling: " + filling);
	}

	public void setNextPipe(GameObject pipe){
		this.nextPipe = pipe;
	}

	public GameObject GetNextPipe() {
		return nextPipe;
	}

	public void fillNext() {
		if (nextPipe != null) {
			nextPipe.GetComponent<Pipe> ().fill ();
		} else {
			gushWater ();
		}
	}

	private void gushWater(){
		Debug.Log ("Chorooooo!!");
	}
}
