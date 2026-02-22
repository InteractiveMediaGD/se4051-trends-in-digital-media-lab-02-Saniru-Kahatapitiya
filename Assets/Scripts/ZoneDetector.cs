using UnityEngine;

public class ZoneDetector : MonoBehaviour
{
    [Header("References")]
    public Light alertLight;
    public AudioSource alertAudio;

    [Header("Light Colors")]
    public Color normalColor = Color.white;
    public Color alertColor = Color.red;

    [Header("Debug")]
    public bool enableDebug = true;

    void Start()
    {
        if (alertLight != null)
        {
            alertLight.color = normalColor;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        if (enableDebug) Debug.Log("Player entered DetectionZone");

        if (alertLight != null)
        {
            alertLight.color = alertColor;
        }

        if (alertAudio != null)
        {
            if (!alertAudio.isPlaying)
                alertAudio.Play();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        if (enableDebug) Debug.Log("Player exited DetectionZone");

        if (alertLight != null)
        {
            alertLight.color = normalColor;
        }

        if (alertAudio != null)
        {
            if (alertAudio.isPlaying)
                alertAudio.Stop();
        }
    }
}