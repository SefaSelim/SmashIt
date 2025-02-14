using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShake : MonoBehaviour
{
public static ScreenShake Instance { get; private set; }
    
    private CinemachineVirtualCamera virtualCamera;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
    }


    public void Shake(float duration, float magnitude)
    {
        virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = magnitude;
        StartCoroutine(Shaking(duration));
    }

    IEnumerator Shaking(float duration)
    {
        float elapsed = 0f;
        CinemachineBasicMultiChannelPerlin noise = virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        float initialMagnitude = noise.m_AmplitudeGain;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            noise.m_AmplitudeGain = Mathf.Lerp(initialMagnitude, 0f, elapsed / duration);
            yield return null;
        }

        noise.m_AmplitudeGain = 0f;
    }
}
