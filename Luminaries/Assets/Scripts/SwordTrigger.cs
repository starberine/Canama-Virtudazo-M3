using UnityEngine;

public class SwordTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ScoreManager.instance.TrySubmitWisps();
        }
    }
}
