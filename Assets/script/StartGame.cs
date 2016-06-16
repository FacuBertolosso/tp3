using UnityEngine;
using System.Collections;

public class StartGame : MonoBehaviour {
	public float startDelayTime=10f;
	private float currentTime;
	private bool running;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (currentTime < startDelayTime) {
			currentTime += Time.deltaTime;	
		} else if (!running) {
			StartToFill ();
			running = true;
		}

	}

	private void StartToFill() {
		Pipe pipe = gameObject.GetComponentInChildren<Pipe>(); 
		pipe.fill ();
	}
}
