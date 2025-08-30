using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundLight : MonoBehaviour
{
    private UnityEngine.Rendering.Universal.Light2D OutSideLightSource;

    float prevLight;

    // Start is called before the first frame update
    void Start()
    {
        OutSideLightSource = GetComponent<UnityEngine.Rendering.Universal.Light2D>();
        prevLight = OutSideLightSource.intensity;
    }
    
    public void StartTimer()
    {
        time = 5f;
    }

    float time = 0;

    public float Intensity = 10f;

    // Update is called once per frame
    void Update()
    {
        if (time <= 0)
        {
            OutSideLightSource.intensity = prevLight;
        } else
        {
            time -= Time.deltaTime;
            OutSideLightSource.intensity = Intensity;
        }
    }
}
