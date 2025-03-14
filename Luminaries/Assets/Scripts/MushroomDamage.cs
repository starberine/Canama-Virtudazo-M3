using UnityEngine;

public class MushroomDamage : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ScoreManager.instance.LoseLife();
            Debug.Log("Player took damage from mushroom!");
        }
    }
}
