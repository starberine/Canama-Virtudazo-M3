using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    public Transform respawnPoint; // Assign in Inspector
    public int playerHealth = 3; // Player's health

    private Rigidbody rb; // Rigidbody reference

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        if (respawnPoint == null)
        {
            Debug.LogError("RespawnPoint is not assigned! Assign it in the Inspector.");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collided with: " + other.gameObject.name); // Debugging the collision

        if (other.CompareTag("Water")) // Check if object has "Water" tag
        {
            Debug.Log("Player hit water! Losing a heart...");
            playerHealth--;

            if (playerHealth <= 0)
            {
                Debug.Log("Game Over!");
                // Add Game Over logic (like showing UI or reloading the scene)
                return;
            }

            Debug.Log("Respawning player...");
            Respawn();
        }
    }

    void Respawn()
    {
        if (rb != null)
        {
            rb.velocity = Vector3.zero; // Stop all movement
            rb.angularVelocity = Vector3.zero; // Stop any rotation forces
            transform.position = respawnPoint.position; // Move player
        }
        else
        {
            transform.position = respawnPoint.position;
        }

        Debug.Log("Player respawned at: " + respawnPoint.position);
    }
}
