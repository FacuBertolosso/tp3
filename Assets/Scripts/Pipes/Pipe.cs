using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pipe : MonoBehaviour
{
    public Material VoidPipeMaterial;
    public Material WateredPipeMaterial;
    private Material _currentMaterial;
    public float FillingTime = 5;
    public float Frequency = 0.5f;
    private float _currentTime, _lastTime;
	private FillingState _fillingState;
    public bool IsFixed;
    public float TotalAngle;
    private GameObject _nextPipe;
    private ScoreManager _scoreManager = null;


    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    public void Awake()
    {
        _currentTime = 0;
        _lastTime = Frequency + 1;
        _currentMaterial = VoidPipeMaterial;
        _fillingState = NoFill.Instance;
    }
    // Use this for initialization
    public virtual void Start()
    {
        
    }

    public FillingState FillingState
    {
        get { return _fillingState; }
        set { _fillingState = value; }
    }

    // Update is called once per frame
    public void Update()
    {
		_fillingState.Update(this);
    }

    public void SwapMaterial()
    {
        _currentMaterial = _currentMaterial.Equals(VoidPipeMaterial) ? WateredPipeMaterial : VoidPipeMaterial;
        ChangeMaterial(_currentMaterial);
    }

    public void ChangeMaterial(Material material)
    {
        ChangeMaterial(transform, material);
    }

    private void ChangeMaterial(Transform transform, Material material)
    {
        if (transform.GetComponent<Renderer>() != null)
            transform.GetComponent<Renderer>().material = material;
        foreach (Transform child in transform)
        {
            if (child.GetComponent<Renderer>() != null)
                ChangeMaterial(child, material);
        }
    }

    public void Fill()
    {
		_fillingState = Filling.Instance;
    }

    public GameObject GetNextPipe()
    {
        return _nextPipe;
    }

    public virtual void AddNextPipe(GameObject pipe)
    {
        _nextPipe = CreateNextPipe(pipe);
        SetNextPipeRotation();
        SetNexPipePosition();
        GetScoreManager().IncrementScore();
    }

    private GameObject CreateNextPipe(GameObject pipe)
    {
        GameObject nextPipe = (GameObject) Instantiate(pipe, pipe.transform.position, pipe.transform.rotation);
        nextPipe.transform.parent = transform;
        Pipe component = nextPipe.GetComponent<Pipe>();
        component.IsFixed = true;
        float anlge = GetClosestAngle(transform.localEulerAngles.y);
        component.TotalAngle = TotalAngle + anlge;
        component.ChangeMaterial(VoidPipeMaterial);
        return nextPipe;
    }

    private void SetNexPipePosition()
    {
        Vector3 boundsSize = _nextPipe.transform.FindChild("default").GetComponentInChildren<Renderer>().bounds.size;
        Vector3 childPosition = CalcChildPosition(boundsSize);
        _nextPipe.transform.localPosition = childPosition;
    }

    private void SetNextPipeRotation()
    {
        float rotationAngleY = GetClosestAngle(_nextPipe.transform.localEulerAngles.y);
        _nextPipe.transform.localRotation = Quaternion.Euler(0f, rotationAngleY, 0f);
    }

    public virtual void FillNext()
    {
        if (_nextPipe != null)
        {
            _nextPipe.GetComponent<Pipe>().Fill();
        }
		else {
			GameOver ();
		}
    }

    private void GameOver()
    {
        Debug.Log("You loose the game!!");
		//activate particle system
        foreach(CollisionDetection collisionDetection in GetComponentsInChildren<CollisionDetection>()){
            if (collisionDetection.isActiveAndEnabled) {
                var face = collisionDetection.gameObject;
                Debug.Log("Face: " + face);
                var water_fountain = face.transform.GetChild(0).gameObject;
                Debug.Log("water_fountain: " + water_fountain);
                water_fountain.SetActive(true);
            }
        }
        // SceneManager.LoadScene("lose_game");
    }

    public bool HasNextPipe()
    {
        return _nextPipe != null;
    }

    public void FixChild()
    {
        _nextPipe.GetComponent<Pipe>().IsFixed = true;
    }

    private Vector3 CalcChildPosition(Vector3 childSize)
    {
        float childSizeX = childSize.x;
        Vector3 boundsSize = gameObject.transform.FindChild("default").GetComponent<Renderer>().bounds.size;
        // Vector3 boundsSize = gameObject.GetComponentInChildren<Renderer>().bounds.size;
        float parentSizeX = boundsSize.x;
        float distance = childSizeX / 2 + parentSizeX / 2;

        Vector3 oldPostion = _nextPipe.transform.localPosition;
        float xAbs = Mathf.Abs(oldPostion.x);
        float yAbs = Mathf.Abs(oldPostion.y);
        float max = Mathf.Max(xAbs, yAbs);
        Vector3 childPosition;
        if (Math.Abs(max - xAbs) < .01f)
        {
            float pos = distance * Mathf.Sign(oldPostion.x);
            childPosition = new Vector3(pos, 0, 0);
        }
        else
        {
            float pos = distance * Mathf.Sign(oldPostion.z);
            childPosition = new Vector3(0, 0, pos);
        }
        Debug.Log("Child Position = " + childPosition);
        return childPosition;
    }

    private float GetClosestAngle(float angle)
    {
        float alpha = angle < 0 ? 360 + angle : angle;
        float current = 0;
        foreach (float ang in Angles)
        {
            if (Mathf.Abs(alpha - ang) <= Mathf.Abs(current - alpha)) current = ang;
            else break;
        }
        return current;
    }

    public static readonly float[] Angles = { 0f, 90f, 180f, 270f, 360f};
	public void SetFilligState(FillingState state)
	{
		_fillingState = state;
	}
	public void IncrementCurentTime()
	{
		_currentTime += Time.deltaTime;
	}
	public float GetCurrentTime()
	{
		return _currentTime;
	}
	public float GetLastTime()
	{
		return _lastTime;
	}
	public void UpdateLastTime()
	{
		_lastTime=_currentTime;
	}
	public bool HasVoidPipeMaterial()
	{
		return _currentMaterial == VoidPipeMaterial;
	}

    public void UpdateProgressBar() {
        float value = _currentTime/FillingTime * 100;
        GetComponentInChildren<ProgressBar.ProgressRadialBehaviour>().SetFillerSizeAsPercentage(value);
    }

    public GameObject NextPipe {
        get {return _nextPipe;}
        set {_nextPipe = value;}
    }

    private ScoreManager GetScoreManager() {
        if (!_scoreManager){
            _scoreManager = FindObjectOfType<ScoreManager>();   
        }
        Debug.Log("Score manager: ", _scoreManager);
        return _scoreManager;
    }
}