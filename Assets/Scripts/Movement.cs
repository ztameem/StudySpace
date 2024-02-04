using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 17f;
    public float jumpForce = 10f;
    public float gravityMultiplier = 1f;

    private Rigidbody rb;
    private CapsuleCollider capsuleCollider;
    private BoxCollider feetCollider;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.collisionDetectionMode = CollisionDetectionMode.Continuous;

        capsuleCollider = GetComponent<CapsuleCollider>();
        feetCollider = gameObject.AddComponent<BoxCollider>();
        feetCollider.size = new Vector3(capsuleCollider.radius * 2f, 0.1f, capsuleCollider.radius * 2f);
        feetCollider.center = new Vector3(0f, -capsuleCollider.height / 2f + 0.05f, 0f);
        rb.freezeRotation = true;
    }

    void Update()
    {
        Jump();
        ChangeGravity();
    }

    void Jump()
    {
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
        }
    }

    void ChangeGravity()
    {
        Physics.gravity = new Vector3(0, -9.8f, 0) * gravityMultiplier;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
