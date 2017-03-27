using UnityEngine;

public class StartGame : MonoBehaviour {
	public float StartDelayTime = 10f;
	private float _currentTime;
    public Pipe OpenPipe;
	private ProgressBar.ProgressRadialBehaviour _progressBar;
    private bool _startToFill;
    private bool _running;

	// Use this for initialization
	public void Start () {
		 _progressBar = GetComponentInChildren<ProgressBar.ProgressRadialBehaviour>();
		 _startToFill = false;
		 _currentTime = 0;
	}
	
	// Update is called once per frame
	public void Update () {
		if (_startToFill && _currentTime < StartDelayTime) {
			_currentTime += Time.deltaTime;
			float value = _currentTime / StartDelayTime * 100;
			_progressBar.SetFillerSizeAsPercentage(value);
		} else if (_currentTime >= StartDelayTime && !_running) {
			_running = !_running;
			StartToFillOpenPipe ();
		}
	}

	private void StartToFillOpenPipe() {
		OpenPipe.Fill ();
	}

	public void StartToFill() {
		_startToFill = true;
	}

	public void StopToFill() {
		_startToFill = false;
	}

}
