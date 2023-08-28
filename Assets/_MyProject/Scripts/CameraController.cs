using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float gap = 3;
    [SerializeField] private float minVertAngel;
    [SerializeField] private float maxVertAngle;
    [SerializeField] private float rotSpeed;
    [SerializeField] private Vector3 focusPosition;
    [SerializeField] private bool invertX;
    [SerializeField] private bool invertY;

    private float rotX;
    private float rotY;
    private float invertRotX;
    private float invertRotY;
    
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

        invertRotX = invertX ? -1 : 1;
        invertRotY = invertY ? -1 : 1;
    }
    
    private void LateUpdate()
    {
        rotX += Input.GetAxis("Mouse Y") * invertRotY * rotSpeed;
        rotX = Mathf.Clamp(rotX, minVertAngel, maxVertAngle);
        rotY += Input.GetAxis("Mouse X") * invertRotX * rotSpeed;
        
        var targetRotation = Quaternion.Euler(rotX, rotY, 0);
        var camTransform = transform;
        camTransform.position = target.position + focusPosition - targetRotation * new Vector3(0, 0, gap);
        camTransform.rotation = targetRotation;
    }
}
