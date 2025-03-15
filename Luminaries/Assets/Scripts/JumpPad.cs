using UnityEngine;

public class JumpPad : MonoBehaviour
{
    public float jumpForce = 15f; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Rigidbody playerRb = other.GetComponent<Rigidbody>();
            if (playerRb != null)
            {
                
                playerRb.velocity = new Vector3(playerRb.velocity.x, 0, playerRb.velocity.z);
                
                
                playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }
        }
    }
}
