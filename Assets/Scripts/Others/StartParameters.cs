using UnityEngine;
using Vuforia;

public class StartParameters : MonoBehaviour, ITrackableEventHandler {

	private TrackableBehaviour mTrackableBehaviour;
	private StartGame _startGame;
    void ITrackableEventHandler.OnTrackableStateChanged(TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus)
    {
		if (!_startGame) _startGame = GetComponentInChildren<StartGame>();
        if (newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED ||
            newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {
            // Start to fill when target is found
			_startGame.StartToFill();
        }
        else
        {
            // Stop to fill when target is lost
            _startGame.StopToFill();
        }
    }

    // Use this for initialization
    void Start () {
		mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
        {
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
        }
		_startGame = GetComponentInChildren<StartGame>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
