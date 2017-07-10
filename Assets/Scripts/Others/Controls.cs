using UnityEngine;
using UnityEngine.SceneManagement;

public class Controls : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape)) { SceneManager.LoadScene ("Menu"); }
	}
}
