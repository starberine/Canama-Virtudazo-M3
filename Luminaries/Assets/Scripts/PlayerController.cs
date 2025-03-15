using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 7f;
    public float groundDist = 0.6f;
    public LayerMask terrainLayer;

    private bool isGrounded;
    private Rigidbody rb;
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        rb.constraints = RigidbodyConstraints.FreezeRotation;
        terrainLayer = LayerMask.GetMask("Terrain");
    }

    void Update()
    {
        
        Vector3 castPos = transform.position + Vector3.up * 0.1f;
        bool wasGrounded = isGrounded;
        isGrounded = Physics.SphereCast(castPos, 0.3f, Vector3.down, out RaycastHit hit, groundDist + 0.5f, terrainLayer);

        animator.SetBool("isGrounded", isGrounded);
    
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
            animator.SetTrigger("Jump");
            AudioManager.instance.PlayJumpSFX();
        }
    }

    void FixedUpdate()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        Vector3 move = new Vector3(moveX * moveSpeed, rb.velocity.y, moveZ * moveSpeed);
        rb.velocity = new Vector3(move.x, rb.velocity.y, move.z);
        
        bool isWalking = moveX != 0 || moveZ != 0;
        animator.SetBool("isWalking", isWalking);
        
        if (moveX != 0)
        {
            transform.localScale = new Vector3(Mathf.Sign(moveX), 1, 1);
        }
    }
}
