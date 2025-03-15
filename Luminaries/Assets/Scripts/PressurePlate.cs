using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PressurePlate : MonoBehaviour
{
    public GameObject[] platforms; // Assign all platforms in the Inspector
    private int objectsOnPlate = 0; // Count objects currently on the plate

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Pushable"))
        {
            objectsOnPlate++; // Increase count
            if (objectsOnPlate == 1) // First object activates
            {
                SetPlatformsState(true);
                Debug.Log("Pressure plate activated!");
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Pushable"))
        {
            objectsOnPlate--; // Decrease count
            if (objectsOnPlate == 0) // If nothing is on the plate, deactivate
            {
                SetPlatformsState(false);
                Debug.Log("Pressure plate deactivated!");
            }
        }
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
