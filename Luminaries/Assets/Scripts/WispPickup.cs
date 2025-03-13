using UnityEngine;

public class WispPickup : MonoBehaviour
{
    public Light pointLight; // Assign in Inspector

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Wisp collected!"); 

            if (pointLight != null)
            {
                Debug.Log("Turning on light!");
                pointLight.enabled = true;
                pointLight.gameObject.SetActive(true); // Force enable
            }
            else
            {
                Debug.Log("Point Light is not assigned!");
            }

            Destroy(gameObject);
        }
    }
}
