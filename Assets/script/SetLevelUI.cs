using UnityEngine;
using UnityEngine.UI;

public class SetLevelUI : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<Text>().text = LevelManager.Level.ToString();
	}
}
