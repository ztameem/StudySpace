using UnityEngine;

public class RocketArc : MonoBehaviour
{
    public Transform startPoint;
    public Transform endPoint;
    public float flightTimeInMinutes = 5f;
    public float rotationSpeed = 360f; 
    private float timer = 0f;
    
    private void Update()
    {
        timer += Time.deltaTime;

        if (timer <= flightTimeInMinutes * 60f)
        {
            float t = timer / (flightTimeInMinutes * 60f); 
            Vector3 archPosition = CalculateArchPosition(t);
            transform.position = Vector3.Lerp(startPoint.position, endPoint.position, t) + archPosition;
            RotateRocketHead(archPosition);
        }
    }

    private Vector3 CalculateArchPosition(float t)
    {
        float archHeight = 2f;
        return new Vector3(0f, Mathf.Sin(t * Mathf.PI) * archHeight, 0f);
    }

    private void RotateRocketHead(Vector3 direction)
    {
    float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
    float tiltAngle = 45f;
    Quaternion targetRotation = Quaternion.Euler(0f, 0f, angle - 90f); 
    targetRotation *= Quaternion.Euler(tiltAngle, 0f, 0f); 
    transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}
