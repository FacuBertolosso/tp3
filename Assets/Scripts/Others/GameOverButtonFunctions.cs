using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverButtonFunctions : MonoBehaviour {

	public Button menuButton;
	public Button restartLastLevelButton;
	// Use this for initialization
	void Start () {
		menuButton.onClick.AddListener(goToMenu);
		restartLastLevelButton.onClick.AddListener(restartLastLevel);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void goToMenu() {
		SceneManager.LoadScene("Menu");
	}

	public void restartLastLevel() {
		SceneManager.LoadScene("Level1");
	}
}