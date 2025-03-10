using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 7f;
    public float groundDist = 0.6f;
    public LayerMask terrainLayer;  // Assign the ground layer in the Inspector

    private bool isGrounded;
    private float groundCheckDelay = 0.1f;
    private float groundCheckTimer;
    private Rigidbody rb;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotation;
        terrainLayer = LayerMask.GetMask("Terrain");  // Set the layer mask in Start()  // Prevents tipping over
    }

    void FixedUpdate()
    {
        // Raycast to check if grounded
        RaycastHit hit;
        Vector3 castPos = transform.position;
        castPos.y += 0.1f;  // Start raycast slightly above the character

        Debug.DrawRay(castPos, -transform.up * (groundDist + 0.8f), Color.red);
        Debug.DrawRay(castPos + Vector3.left * 0.3f, -transform.up * (groundDist + 0.5f), Color.green);  // Visualize left ray
        Debug.DrawRay(castPos + Vector3.right * 0.3f, -transform.up * (groundDist + 0.5f), Color.blue);  // Visualize right ray  // Visualize the raycast

        if (Physics.SphereCast(castPos, 0.3f, -transform.up, out hit, groundDist + 0.5f, terrainLayer))
        {
            if (hit.collider != null)
            {
                isGrounded = true;
                groundCheckTimer = groundCheckDelay;  // Reset timer when grounded
            }
        }
        else if (groundCheckTimer > 0)
        {
            groundCheckTimer -= Time.deltaTime;
        }
        else
        {
            isGrounded = false;
        }

        Debug.Log("isGrounded: " + isGrounded);  // Debug to check if grounded

        // Horizontal (A/D) and Vertical (W/S) movement
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        Vector3 move = new Vector3(moveX * moveSpeed, rb.velocity.y, moveZ * moveSpeed);
        rb.velocity = new Vector3(move.x, rb.velocity.y, move.z);  // Preserve Y-axis velocity

        // Flip sprite based on horizontal direction only
        if (moveX != 0)
        {
            transform.localScale = new Vector3(Mathf.Sign(moveX), 1, 1);
        }

        // Jumping
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);  // Apply jump force
        }
    }
}
