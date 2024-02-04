using UnityEngine;

public class CameraOrbit : MonoBehaviour
{
    public Transform target;  
    public float rotationSpeed = 5f;
    public float cameraDistance = 5f;
    public LayerMask terrainLayer;  
    public float movementSpeed = 12f;

    private float mouseX, mouseY;

    void Start()
    {
        if (target == null)
        {
            Debug.LogError("not assinged");
            enabled = false;
        }

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        mouseX += Input.GetAxis("Mouse X") * rotationSpeed;
        mouseY -= Input.GetAxis("Mouse Y") * rotationSpeed;
        mouseY = Mathf.Clamp(mouseY, -90f, 90f);
        Quaternion rotation = Quaternion.Euler(mouseY, mouseX, 0);
        transform.rotation = rotation;

        Vector3 flatForward = transform.forward;
        flatForward.y = 0;
        flatForward.Normalize();

        Vector3 negDistance = new Vector3(0.0f, 0.0f, -cameraDistance);
        Vector3 position = rotation * negDistance + target.position;

        RaycastHit hit;
        if (Physics.Raycast(target.position, Vector3.down, out hit, Mathf.Infinity, terrainLayer))
        {
            position.y = Mathf.Max(position.y, hit.point.y + 1f); 
        }

        transform.position = position;

        target.forward = flatForward;

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 moveDirection = flatForward * vertical + transform.right * horizontal;
        target.Translate(moveDirection * movementSpeed * Time.deltaTime, Space.World);

        if (Input.GetButtonDown("Jump"))
        {
            Cursor.lockState = CursorLockMode.None;
        }

        if (Input.GetButtonUp("Jump"))
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}
