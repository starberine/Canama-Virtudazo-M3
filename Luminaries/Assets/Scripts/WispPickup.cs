using UnityEngine;

public class WispPickup : MonoBehaviour
{
    public Light pointLight; // Assign in Inspector
    public float lightDuration = 10f; // Set the duration for the light

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Wisp collected!"); 
            ScoreManager.instance.GainWisp();

            if (pointLight != null)
            {
                Debug.Log("Activating light for " + lightDuration + " seconds.");
                ScoreManager.instance.ActivateLightForDuration(pointLight, lightDuration);
            }
            else
            {
                Debug.Log("Point Light is not assigned!");
            }

            Destroy(gameObject); // Safe to destroy now!
        }
    }
}
