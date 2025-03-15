using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    public Transform meadowlandsRespawn;
    public Transform grovesRespawn;
    public Transform shroomvilleRespawn;

    private Transform currentRespawnPoint;
    private Rigidbody rb;
    public int playerHealth = 3;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentRespawnPoint = meadowlandsRespawn;
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collided with: " + other.gameObject.name);

        
        if (other.CompareTag("Meadowlands"))
            currentRespawnPoint = meadowlandsRespawn;
        else if (other.CompareTag("Groves"))
            currentRespawnPoint = grovesRespawn;
        else if (other.CompareTag("Shroomville"))
            currentRespawnPoint = shroomvilleRespawn;

        
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
            transform.position = currentRespawnPoint.position;
        }
        else
        {
            transform.position = currentRespawnPoint.position;
        }

        Debug.Log("Player respawned at: " + currentRespawnPoint.position);
    }
}
