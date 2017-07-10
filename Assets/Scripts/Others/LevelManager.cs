using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {
	public static string lastLevel;
	public static int Level;

	/// <summary>
	/// Awake is called when the script instance is being loaded.
	/// </summary>
	void Awake()
	{
		GameObject _closePipe = GameObject.FindGameObjectWithTag("ClosePipe");
		Level = PlayerPrefs.GetInt("Level", 1);
		switch(Level) {
			case 1:
				_closePipe.transform.localPosition = new Vector3(3.7f, 0, -4f);
				_closePipe.transform.localEulerAngles = new Vector3(0, 180f, 0);
				break;
			case 2:
				_closePipe.transform.localPosition = new Vector3(3.7f, 0, 0);
				_closePipe.transform.localEulerAngles = new Vector3(0, 90f, 0);
				break;
			case 3:
				_closePipe.transform.localPosition = new Vector3(3.7f, 0, 4f);
				_closePipe.transform.localEulerAngles = new Vector3(0, 180f, 0);
				break;
		}	
	}

    public static void NextLevel()
    {
        Level += 1;
		PlayerPrefs.SetInt("Level", Level);
    }

    // Use this for initialization
    void Start () {
		lastLevel = SceneManager.GetActiveScene().name;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

}
