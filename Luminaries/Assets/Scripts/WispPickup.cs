using UnityEngine;

public class WispPickup : MonoBehaviour
{
    public Light pointLight; 
    public float lightDuration = 10f; 

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ScoreManager.instance.GainWisp();
            AudioManager.instance.PlayCollectSFX();

            if (pointLight != null)
            {
                ScoreManager.instance.ActivateLightForDuration(pointLight, lightDuration);
            }
            else
            {
                Debug.Log("Point Light is not assigned!");
            }

            Destroy(gameObject); 
        }
    }
}
