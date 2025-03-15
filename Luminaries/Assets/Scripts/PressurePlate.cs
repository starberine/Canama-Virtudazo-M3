using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PressurePlate : MonoBehaviour
{
    public GameObject[] platforms; 
    private int objectsOnPlate = 0;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Pushable"))
        {
            objectsOnPlate++;
            if (objectsOnPlate == 1)
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
            objectsOnPlate--;
            if (objectsOnPlate == 0)
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
