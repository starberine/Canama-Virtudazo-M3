using UnityEngine;
using System.Collections;

public class PlatformActivator : MonoBehaviour
{
    public GameObject[] platforms; // Assign all platforms in the Inspector
    public float appearDuration = 10f; // Time before they disappear

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
        SetPlatformsState(true); // Make platforms appear
        yield return new WaitForSeconds(appearDuration);
        SetPlatformsState(false); // Make platforms disappear
    }

    void SetPlatformsState(bool state)
    {
        foreach (GameObject platform in platforms)
        {
            if (platform != null)
            {
                platform.SetActive(state); // Show or hide platform
            }
        }
    }
}
