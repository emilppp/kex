using UnityEngine;
using Tobii.EyeTracking;

[RequireComponent(typeof(GazeAware))]
public class SpinOnGaze : MonoBehaviour
{
    private GazeAware _gazeAware;

    void Start()
    {
        _gazeAware = GetComponent<GazeAware>();
    }

    void Update()
    {
        if (_gazeAware.HasGazeFocus)
        {
			_gazeAware.
			transform.position = _gazeAware.gameObject.transform.position;
        }
    }
}