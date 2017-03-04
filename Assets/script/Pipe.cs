using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Pipe : MonoBehaviour
{
    public Material voidPipe;
    public Material wateredPipe;
    private Material _currentMaterial;
    public float fillingTime = 5;
    public float frequency = 0.5f;

    private float _currentTime, _lastTime;
    private bool _filling;
    private bool _filled;
    public bool isFixed;
    public bool isApertura;
    public bool isClose;

    private GameObject _nextPipe;
    public Text TimeText;

    // Use this for initialization
    public void Start()
    {
        _currentTime = 0;
        _lastTime = frequency + 1;
        _currentMaterial = voidPipe;
        if (isApertura) isFixed = true;
    }

    // Update is called once per frame
    public void Update()
    {
        if (_filling)
        {
            _currentTime += Time.deltaTime;
            if ((_currentTime < fillingTime) && ((_currentTime - _lastTime) > frequency))
            {
                _lastTime = _currentTime;
                SwapMaterial();
            }
            if (TimeText != null) TimeText.text = ((int) _lastTime).ToString();
        }
        if (!_filled && (_currentTime > fillingTime))
        {
            _filled = true;
            _filling = false;
            FillNext();
        }
        if (_filled && _currentMaterial.Equals(voidPipe))
        {
            SwapMaterial();
        }

    }

    private void SwapMaterial()
    {
        _currentMaterial = _currentMaterial.Equals(voidPipe) ? wateredPipe : voidPipe;
        ChangeMaterial(_currentMaterial);
    }

    public void ChangeMaterial(Material material)
    {
        ChangeMaterial(transform, material);
    }

    private void ChangeMaterial(Transform trfrom, Material material)
    {
        if (trfrom.GetComponent<Renderer>() != null)
            trfrom.GetComponent<Renderer>().material = material;
        foreach (Transform child in trfrom)
        {
            if (child.GetComponent<Renderer>() != null)
                ChangeMaterial(child, material);
        }
    }

    public void Fill()
    {
        _filling = true;
        Debug.Log("Filling: " + _filling);
    }

    public GameObject GetNextPipe()
    {
        return _nextPipe;
    }

    public void AddNextPipe(GameObject pipe, string colliderName)
    {
        GameObject nextPipe = (GameObject) Instantiate(pipe, Vector3.zero, pipe.transform.rotation);
        ChangeMaterial(voidPipe);
        _nextPipe = nextPipe;
        _nextPipe.transform.parent = transform;
        Vector3 rotation = _nextPipe.transform.localEulerAngles;
        float closestAngle = GetClosestAngle(rotation.y);
        Vector3 childPosition =
            CalcChildPosition(pipe.tag, pipe.GetComponentInChildren<Renderer>().bounds.size, closestAngle);

        _nextPipe.GetComponent<Pipe>().isFixed = true;
        _nextPipe.transform.localPosition = childPosition;
        _nextPipe.transform.localRotation = Quaternion.Euler(0f, closestAngle, 0f);
    }

    public void FillNext()
    {
        if (_nextPipe != null)
        {
            _nextPipe.GetComponent<Pipe>().Fill();
        }
        else if (isClose)
        {
            Debug.Log("You WIN!!");
            SceneManager.LoadScene("win_Game");
        }
//		else {
//			GushWater ();
//		}
    }

    private void GushWater()
    {
		//ativar particle sistem
        Debug.Log("Chorooooo!!");
        SceneManager.LoadScene("lose_game");
    }

    public bool HasNextPipe()
    {
        return _nextPipe != null;
    }

    public void FixChild()
    {
        _nextPipe.GetComponent<Pipe>().isFixed = true;
    }

    private Vector3 CalcChildPosition(string pipeTag, Vector3 childSize, float closestAngle)
    {
        float childSizeX = childSize.x;
//        float childSizeZ = childSize.z;
        Vector3 boundsSize = gameObject.GetComponentInChildren<Renderer>().bounds.size;
        float parentSizeX = boundsSize.x;
//        float parentSizeZ = boundsSize.z;
        float x = childSizeX / 2 + parentSizeX / 2;
//        float z = childSizeZ/ 2 + parentSizeZ / 2;
        print("parent: " + boundsSize);
        print("child: " + childSize);
        Vector3 childPosition = new Vector3(x, 0, 0);
//        switch (pipeTag)
//        {
//            case "ClosePipe":
//                break;
//            case "LinePipe":
//                childPosition.x += 0.28f;
//                if (gameObject.CompareTag("LinePipe")) childPosition.x += 0.1f;
//                else childPosition.y -= 0.1f;
//                break;
//            case "ElbowPipe":
//                float multiplier = 1;
//                if (Math.Abs(closestAngle - 90) < 2) multiplier = -1;
//                else if (Math.Abs(closestAngle - 270) < 2) multiplier = 1;
//
//                if (gameObject.CompareTag("ElbowPipe"))
//                {
//                    childPosition.x = .98f;
//                    childPosition.z = .62f;
//                }
//                else if (gameObject.CompareTag("LinePipe"))
//                {
//                    childPosition.x = 1.08f;
//                    childPosition.z = multiplier * .28f;
//                }
//                else if (gameObject.CompareTag("OpenPipe"))
//                {
//                    childPosition.z = multiplier * .21f;
//                    childPosition.x = 1.18f;
//                    childPosition.y = -0.1f;
//                }
//                break;
//            default:
//                break;
//        }


        return childPosition;
    }

    private float GetClosestAngle(float angle)
    {
        float current = angle;
        foreach (float ang in Angles)
        {
            if (Mathf.Abs(angle - ang) < Mathf.Abs(current - ang)) current = ang;
        }
        return current;
    }

    public static readonly float[] Angles = { 0f, 90f, 180f, 270f, 360f};
}