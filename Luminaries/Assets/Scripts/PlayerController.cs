using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 7f;
    public float groundDist = 0.6f;
    public float maxZMovement = 2f; // Limit Z movement
    public LayerMask terrainLayer;

    private bool isGrounded;
    private Rigidbody rb;
    private Animator anim;
    private float startZ;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotation;
        anim = GetComponent<Animator>();
        startZ = transform.position.z; // Store the starting Z position
    }

    void FixedUpdate()
    {
        // 🔥 FIXED: PROPER GROUND DETECTION 🔥
        Vector3 boxSize = new Vector3(0.6f, 0.2f, 0.6f); // Adjust size for accurate detection
        isGrounded = Physics.CheckBox(transform.position + Vector3.down * 0.5f, boxSize / 2, Quaternion.identity, terrainLayer);

        Debug.Log("🔥 isGrounded: " + isGrounded);

        // Get movement input
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical") * 0.5f;

        // Apply movement
        Vector3 move = new Vector3(moveX * moveSpeed, rb.velocity.y, moveZ * moveSpeed);
        rb.velocity = move;

        // Limit movement along the Z-axis
        float clampedZ = Mathf.Clamp(transform.position.z, startZ - maxZMovement, startZ + maxZMovement);
        transform.position = new Vector3(transform.position.x, transform.position.y, clampedZ);

        // Walking animation (ONLY if moving and on ground)
        anim.SetBool("isRunning", (moveX != 0 || moveZ != 0) && isGrounded);

        // Flip sprite based on X movement
        if (moveX != 0)
        {
            transform.localScale = new Vector3(Mathf.Sign(moveX), 1, 1);
        }
    }

    void Update()
    {
        // 🔥 FIX: JUMP ONLY WHEN PRESSING SPACEBAR & ON GROUND 🔥
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Debug.Log("🔥 JUMP PRESSED! 🔥");
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
            anim.SetTrigger("Jump");
        }

        // 🔥 FIX: RESET JUMP ANIMATION WHEN LANDING 🔥
        if (isGrounded && anim.GetCurrentAnimatorStateInfo(0).IsName("Jump"))
        {
            Debug.Log("🔥 LANDED! RESET JUMP 🔥");
            anim.ResetTrigger("Jump");
        }
    }
}
