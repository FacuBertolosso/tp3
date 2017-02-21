using UnityEngine;

public class CollisionDetection : MonoBehaviour {

	public Material SuccessefullMaterial;
	public Material VoidMaterial;
	private Pipe _pipe;
//	public float deleteColliderTime = 1.0f;
	public float DelayClone = 3;
	private bool _clonable;
	private float _time;

	// Use this for initialization
    public void Start () {
       _pipe = gameObject.GetComponentInParent<Pipe>();
//        _pipe = pipe != null ? pipe : gameObject.GetComponent<Pipe>();
		_time = 0;
	}
	
	// Update is called once per frame
    public void Update () {
		if (_time < DelayClone)
			_time += Time.deltaTime;
		else if (!_clonable)
			_clonable = true;
//		if (time < deleteColliderTime) {
//			time += TimeText.deltaTime;
//		} else if (!GetComponent<BoxCollider> ().enabled && !pipe.isFixed	) {
//			changeSateCollider (true);
//		}
	}

	void OnTriggerEnter(Collider other) {
		if (_pipe == null || _pipe.HasNextPipe()) return;
	    if ((other.transform.parent.position - transform.parent.position).magnitude < 0.3)
			return;
	    if (_clonable && other.CompareTag("pipe")) {
			ChangeMaterial (SuccessefullMaterial);
		    if (_pipe.isFixed) {
		        GameObject nextPipeGo = other.transform.parent.gameObject;
		        enabled = false;
		        other.GetComponent<CollisionDetection>().enabled = false;
		        _pipe.AddNextPipe(nextPipeGo, other.gameObject.name);
			}
		}
		if (_pipe.HasNextPipe ()) {
			_pipe.FixChild ();
		}
	}

	void OnTriggerExit(Collider other) {
		if (_pipe == null || _pipe.HasNextPipe()) return;
	    if (!other.CompareTag("pipe")) return;
	    _pipe.ChangeMaterial (VoidMaterial);
//	    if (_pipe.IsFixed) other.transform.parent = other.transform
	}

	private void ChangeMaterial(Material material){
		_pipe.ChangeMaterial (material);
	}

//	public void ChangeSateCollider(bool state) {
//		GetComponent<Collider> ().enabled = state;
//		GetComponent<Rigidbody> ().isKinematic = state;
//	}
}
