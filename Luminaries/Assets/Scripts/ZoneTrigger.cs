using UnityEngine;
using TMPro; 
using System.Collections;

public class ZoneTrigger : MonoBehaviour
{
    public enum ZoneType { Meadowlands, Groves, Shroomville }
    public ZoneType zoneType;
    public AudioClip zoneBGM;
    public string zoneName;
    
    [Header("Zone UI")]
    public TMP_Text zoneText; 
    public float displayDuration = 2f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            AudioManager.instance.PlayBGM(zoneBGM);
            if (zoneText != null)
            {
                StopAllCoroutines();
                StartCoroutine(ShowZoneName(zoneName));
            }
        }
    }

    private IEnumerator ShowZoneName(string name)
    {
        zoneText.text = name;
        zoneText.gameObject.SetActive(true);
        zoneText.alpha = 1f;

        yield return new WaitForSeconds(displayDuration);
        
        float fadeDuration = 1f;
        float elapsedTime = 0f;
        
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            zoneText.alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);
            yield return null;
        }

        zoneText.gameObject.SetActive(false);
    }
}
