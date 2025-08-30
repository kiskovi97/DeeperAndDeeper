using System.Collections;
using System.Collections.Generic;

using Unity.Cinemachine;

using UnityEngine;

public class CinemachineShake : MonoBehaviour
{
    public CinemachineBasicMultiChannelPerlin perlin;

    private float timer;
    private float maxTime;
    private float maxShake;

    private static CinemachineShake instance;

    private void Awake()
    {
        instance = this;
    }

    public static void ShakeCamera(float intensity, float time)
    {
        if (instance != null)
        {
            var perlin = instance.perlin;
            perlin.AmplitudeGain = intensity;
            instance.timer = time;
            instance.maxTime = time;
            instance.maxShake = intensity;
        }
    }

    private void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            var perlin = instance.perlin;
            perlin.AmplitudeGain = 0f;
        }
    }
}
