using UnityEngine;
using Vuforia;

public class StartParameters : MonoBehaviour, ITrackableEventHandler {

	private TrackableBehaviour mTrackableBehaviour;
	private StartGame _startGame;
    void ITrackableEventHandler.OnTrackableStateChanged(TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus)
    {
		if (!_startGame) _startGame = GetComponent<StartGame>();
        var a = mTrackableBehaviour.TrackableName;
        Debug.Log("New status: " + a);
        if (newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED ||
            newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {
            // Start to fill when target is found
			Debug.Log("Target is found");
            _startGame.StartToFill();
        }
        else
        {
            // Stop to fill when target is lost
            Debug.Log("Target is lost");
            _startGame.StopToFill();
        }
    }

    // Use this for initialization
    void Start () {
		mTrackableBehaviour = GetComponentInParent<TrackableBehaviour>();
        if (mTrackableBehaviour)
        {
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
        }
		_startGame = GetComponent<StartGame>();
        var a = mTrackableBehaviour.TrackableName;
        Debug.Log("New status: " + a);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
