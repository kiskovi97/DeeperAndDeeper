using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CinemachineShake : MonoBehaviour
{
    private CinemachineVirtualCamera virtualCamera;

    private float timer;
    private float maxTime;
    private float maxShake;

    private static CinemachineShake instance;

    private void Awake()
    {
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
        
        instance = this;
    }

    public static void ShakeCamera(float intensity, float time)
    {
        if (instance != null)
        {
            var perlin = instance.virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
            perlin.m_AmplitudeGain = intensity;
            instance.timer = time;
            instance.maxTime = time;
            instance.maxShake = intensity;
        }
    }

    private void Update()
    {
        var perlin = virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            
            //perlin.m_AmplitudeGain = Mathf.Lerp(maxShake, 0f, timer / maxTime);
        } else
        {
            perlin.m_AmplitudeGain = 0f;
        }
    }
}
