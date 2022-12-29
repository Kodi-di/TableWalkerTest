using UnityEngine;

[RequireComponent(typeof(Camera))]
public class DragHandler : MonoBehaviour
{
    private const string _tag = "Draggable";

    [SerializeField] private Camera _camera;
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private LayerMask _pieceMask;

    private Rigidbody _target = null;
    private Vector3 _screenPosition;
    private Vector3 _worldPosition;
    private Ray _ray;

    private void Start()
    {
        _camera = GetComponent<Camera>();
    }
    private void Update()
    {
        _screenPosition = Input.mousePosition;
        if (Input.GetMouseButtonDown(0))
        {
            _ray = _camera.ScreenPointToRay(_screenPosition);

            if(Physics.Raycast(_ray, out RaycastHit info, 100, _pieceMask))
            {
                if(info.transform.CompareTag(_tag))
                {
                    _target = info.rigidbody;
                }
            }
        }

        if((Input.GetMouseButton(0))&&(_target != null))
        {
            _ray = _camera.ScreenPointToRay(_screenPosition);

            if (Physics.Raycast(_ray, out RaycastHit info, 100, _layerMask))
            {
                _worldPosition = info.point;
            }
        }

        if(Input.GetMouseButtonUp(0))
        {
            _target = null;
        }
    }

    private void FixedUpdate()
    {
        if(_target != null)
        {
            _target.MovePosition(_worldPosition);
        }
    }

}
