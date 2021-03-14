using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;

    private Transform _cameraTransform;

    private Vector3 _cameraOffset;

    private void Awake()
    {
        _cameraTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (_cameraTransform.position.y < playerTransform.position.y)
        {
            _cameraOffset = new Vector3(_cameraTransform.position.x, playerTransform.position.y, _cameraTransform.position.z);
            _cameraTransform.position = _cameraOffset;
        }
    }
}
