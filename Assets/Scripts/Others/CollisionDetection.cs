﻿using UnityEngine;

public class CollisionDetection : MonoBehaviour {
    private const string PipeTag = "pipe";
    private const string ClosePipeTag = "ClosePipeFace";

    public Material SuccessefullMaterial;
	public Material VoidMaterial;
	private Pipe _pipe;
	public float DelayClone = 3;
	private bool _clonable;
	private float _time;

	// Use this for initialization
    public void Start () {
        _pipe = gameObject.GetComponentInParent<Pipe>();
        _time = 0;
	}
	
	// Update is called once per frame
    public void Update () {
		if (_time < DelayClone)
			_time += Time.deltaTime;
		else if (!_clonable)
			_clonable = true;
	}

	void OnTriggerEnter(Collider other) {
		if (_pipe == null || _pipe.HasNextPipe()) return;
	    if ((other.transform.parent.position - transform.parent.position).magnitude < 0.3)
			return;
	    if (_clonable && other.CompareTag(PipeTag)) {
		    if (_pipe.IsFixed) {
		        GameObject nextPipe = other.transform.parent.gameObject;
		        nextPipe.GetComponent<Pipe>().ChangeMaterial (SuccessefullMaterial);
				enabled = false;
		        other.GetComponent<CollisionDetection>().enabled = false;
		        _pipe.AddNextPipe(nextPipe);
			}
		}
		if (_pipe.HasNextPipe ()) {
			_pipe.FixChild ();
		}
	}

	void OnTriggerExit(Collider other) {
		if (_pipe == null || _pipe.HasNextPipe() || _pipe.IsFixed) return;
	    if (!other.CompareTag(PipeTag)) return;
	    _pipe.ChangeMaterial (VoidMaterial);
	}

	void OnTriggerStay(Collider other) {
       if (other.CompareTag(ClosePipeTag) && !_pipe.HasNextPipe()) {
		    if (!_pipe.IsFixed) return;
			GameObject nextPipe = other.transform.parent.gameObject;
			enabled = false;
			_pipe.NextPipe = nextPipe;
		} 
    }

	private void ChangeMaterial(Material material){
		_pipe.ChangeMaterial (material);
	}

}
