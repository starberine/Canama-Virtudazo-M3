using UnityEngine;

public class JumpPad : MonoBehaviour
{
    public float jumpForce = 15f; // Adjust as needed

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Rigidbody playerRb = other.GetComponent<Rigidbody>();
            if (playerRb != null)
            {
                // Reset Y velocity to avoid stacking forces
                playerRb.velocity = new Vector3(playerRb.velocity.x, 0, playerRb.velocity.z);
                
                // Apply upward force
                playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }
        }
    }
}
