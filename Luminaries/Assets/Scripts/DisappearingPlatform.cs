using UnityEngine;
using System.Collections;

public class PlatformActivator : MonoBehaviour
{
    public GameObject[] platforms; 
    public float appearDuration = 10f; 

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Button pressed! Platforms appearing!");
            StartCoroutine(ActivatePlatforms());
        }
    }

    IEnumerator ActivatePlatforms()
    {
        SetPlatformsState(true); 
        yield return new WaitForSeconds(appearDuration);
        SetPlatformsState(false); 
    }

    void SetPlatformsState(bool state)
    {
        foreach (GameObject platform in platforms)
        {
            if (platform != null)
            {
                platform.SetActive(state); 
            }
        }
    }
}
