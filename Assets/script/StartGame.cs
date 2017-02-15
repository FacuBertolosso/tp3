using UnityEngine;

public class StartGame : MonoBehaviour {
	public float StartDelayTime = 10f;
	private float _currentTime;
	private bool _running;


	// Use this for initialization
	public void Start () {
		
	}
	
	// Update is called once per frame
	public void Update () {
		if (_currentTime < StartDelayTime) {
			_currentTime += Time.deltaTime;
		} else if (!_running) {
			StartToFill ();
			_running = true;
		}
	}

	private void StartToFill() {
		Pipe pipe = gameObject.GetComponent<Pipe>(); 
		pipe.Fill ();
	}
}
