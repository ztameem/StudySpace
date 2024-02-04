using UnityEngine;
using TMPro; 

public class Coin : MonoBehaviour
{
    public static int coinCount = 0;
    public TextMeshPro coinCounterText;

    public float bounceHeight = 1f; 
    public float bounceSpeed = 2f; 
    public float rotationSpeed = 10f;

    void Start()
    {
        if (coinCounterText == null)
        {
            Debug.LogError("not assigned");
        }

        UpdateCoinCounter();
    }

    void Update()
    {
        float bounce = Mathf.Sin(Time.time * bounceSpeed) * bounceHeight;
        transform.Translate(Vector3.up * bounce * Time.deltaTime);
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
            coinCount++;
            UpdateCoinCounter();
        }
    }

    void UpdateCoinCounter()
    {
        if (coinCounterText == null)
        {
            Debug.LogError("not assigned 2");
        }
        else
        {
            coinCounterText.text = coinCount.ToString();
            Debug.Log("updated " + coinCount);
        }
    }
}
