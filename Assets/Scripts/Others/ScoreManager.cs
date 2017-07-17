using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	private Text _scoreText;
	private int _score;
	private static int _pointsByPipe = 100;
	// Use this for initialization
	void Start () {
		_scoreText = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void IncrementScore() {
		_score += _pointsByPipe;
		Debug.Log("Score: " + _score);
		_scoreText.text = _score.ToString();
	}
}
