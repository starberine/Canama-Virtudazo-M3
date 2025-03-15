using UnityEngine;

public class BeeEnemy : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float detectionRange = 5f;
    private Transform player;
    private bool isChasing = false;
    private float groundY;
    private bool isDefeated = false;
    private Collider beeCollider;
    private Renderer beeRenderer;

    private void Start()
    {
        groundY = transform.position.y;
        beeCollider = GetComponent<Collider>();
        beeRenderer = GetComponentInChildren<Renderer>(); 
    }

    private void Update()
    {
        if (!isDefeated)
        {
            DetectPlayer();
            if (isChasing && player != null)
            {
                FollowPlayer();
            }
        }
    }

    private void DetectPlayer()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, detectionRange);
        foreach (var hit in hits)
        {
            if (hit.CompareTag("Player"))
            {
                player = hit.transform;
                isChasing = true;
                break;
            }
        }
    }

    private void FollowPlayer()
    {
        Vector3 targetPosition = new Vector3(player.position.x, groundY, player.position.z);
        Vector3 direction = (targetPosition - transform.position).normalized;
        transform.position += direction * moveSpeed * Time.deltaTime;

        if (direction != Vector3.zero)
        {
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (isDefeated) return;

        if (collision.gameObject.CompareTag("Player"))
        {
            DamagePlayer();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isDefeated) return;

        if (other.CompareTag("PlayerAttack")) 
        {
            Die();
        }
    }

    private void DamagePlayer()
    {
        ScoreManager.instance.LoseLife();
        Debug.Log("Player took damage from bee!");
    }

    private void Die()
    {
        isDefeated = true;
        AudioManager.instance.PlayEnemyDeathSFX();
        Destroy(gameObject); 
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRange);
    }
}
