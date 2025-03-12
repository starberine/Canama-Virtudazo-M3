using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class WallStickJump : MonoBehaviour
{
    public float bounceForce = 7f;
    public float wallCheckDistance = 0.5f;
    public float wallJumpAngle = 45f;
    public LayerMask wallLayer;

    private Rigidbody rb;
    private bool isTouchingWall;
    private Vector3 lastWallNormal;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        CheckWallContact();

        if (isTouchingWall && Input.GetButtonDown("Jump"))
        {
            if (lastWallNormal != Vector3.zero)
            {
                Vector3 perpendicular = Vector3.Cross(lastWallNormal, Vector3.up).normalized;
                Vector3 bounceDir = perpendicular + Vector3.up;
                rb.velocity = bounceDir.normalized * bounceForce;
            }
        }
    }

    private void CheckWallContact()
    {
        RaycastHit hit;
        Vector3[] directions = { transform.forward, -transform.right, transform.right };

        isTouchingWall = false;
        foreach (var dir in directions)
        {
            if (Physics.Raycast(transform.position, dir, out hit, wallCheckDistance, wallLayer))
            {
                isTouchingWall = true;
                lastWallNormal = hit.normal;
                break;
            }
        }
    }
} 
