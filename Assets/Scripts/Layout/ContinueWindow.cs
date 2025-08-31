using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DeeperAndDeeper.Main;

using UnityEngine;
using UnityEngine.UI;

internal class ContinueWindow : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private GameObject windowRoot;
    [SerializeField] private Button continueButton;
    [SerializeField] private Button cancelButton;

    public static ContinueWindow Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            windowRoot.SetActive(false); // Hide on start
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        continueButton.onClick.AddListener(OnContinuePressed);
        cancelButton.onClick.AddListener(OnCancelPressed);
    }

    private void OnDestroy()
    {
        if (Instance == this)
            Instance = null;
    }

    public static void ShowWindow()
    {
        if (Instance != null)
        {
            Time.timeScale = 0f; // Pause gameplay
            Instance.windowRoot.SetActive(true);
        }
    }

    private async void OnContinuePressed()
    {
        windowRoot.SetActive(false);

        Debug.Log("Continue pressed → showing reward ad...");
        bool rewarded = await AdsInitializer.LoadRewardAd();

        Time.timeScale = 1f;

        if (rewarded && Character.instance != null)
        {
            Debug.Log("Reward successful → BatteryCharge()");
            Character.instance.BatteryCharge(); // assuming method is here
        }
        else
        {
            Debug.Log("Reward failed → GameOver()");
            GameState.GameOver();
        }
    }

    private void OnCancelPressed()
    {
        windowRoot.SetActive(false);

        Time.timeScale = 1f;
        Debug.Log("Cancel pressed → GameOver()");
        GameState.GameOver();
    }

}

