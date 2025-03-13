using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    public Transform respawnPoint; 
    public int playerHealth = 3; 

    private Rigidbody rb; 

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
        Debug.Log("Collided with: " + other.gameObject.name); 

        if (other.CompareTag("Water")) 
        {
            Debug.Log("Player hit water! Losing a heart...");
            ScoreManager.instance.LoseLife();

            if (playerHealth <= 0)
            {
                Debug.Log("Game Over!");
                
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
            rb.velocity = Vector3.zero; 
            rb.angularVelocity = Vector3.zero; 
            transform.position = respawnPoint.position; 
        }
        else
        {
            transform.position = respawnPoint.position;
        }

        Debug.Log("Player respawned at: " + respawnPoint.position);
    }
}
