using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraController : MonoBehaviour
{

    [SerializeField] private List<Transform> _points;
    [SerializeField] private Transform _startPoint;

    private Camera _camera;
    private int _itter = 1;

    private void Start()
    {
        _camera = GetComponent<Camera>();
    }

    void Update()
    {
        if(Input.GetButtonDown("Jump"))
        {
            if(_camera.transform.position != _startPoint.position)
            {
                _camera.transform.position = _points[_itter].position;
                _camera.transform.rotation = _points[_itter].rotation;

                _itter = _itter != _points.Count - 1 ? _itter + 1 : 0;
            }
        }
    }
}
