using System;

using DeeperAndDeeper.Main;

using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Character : MonoBehaviour
{
    private float startRadius;
    private float startOutRadius;
    public TextMeshProUGUI scoreText;

    public UnityEngine.Rendering.Universal.Light2D LightSource;
    public BackgroundLight bLight;
    public TextMeshProUGUI lightText;

    public bool Immortal = false;

    public static Character instance;

    public void StartLight()
    {
        bLight.StartTimer();
    }

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        startRadius = LightSource.pointLightInnerRadius;
        startOutRadius = LightSource.pointLightOuterRadius;
    }

    public void BatteryCharge()
    {
        LightSource.pointLightInnerRadius = startRadius;
        LightSource.pointLightOuterRadius = startOutRadius;
    }

    private void Update()
    {
        if (!Immortal)
        {
            if (LightSource.pointLightInnerRadius > Time.deltaTime * 0.1f)
            {
                LightSource.pointLightInnerRadius -= Time.deltaTime * 0.1f;
            }

            if (LightSource.pointLightOuterRadius > Time.deltaTime * 0.1f)
            {
                LightSource.pointLightOuterRadius -= Time.deltaTime * 0.1f;
            }
            else
            {
                ContinueWindow.ShowWindow();
                //TryReload();
            }
        }
        if (lightText != null)
            lightText.text = (int)(LightSource.pointLightOuterRadius * 10) + "";

        if (scoreText != null)
            scoreText.text = GameState.score.ToString();
    }

    private async void TryReload()
    {
        Time.timeScale = 0f;
        var ok = await AdsInitializer.LoadRewardAd();
        Time.timeScale = 1f;
        if (ok)
        {
            BatteryCharge();
        } else
        {
            GameState.GameOver();
        }
    }
}
