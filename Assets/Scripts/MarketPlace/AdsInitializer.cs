using System;
using System.Collections.Generic;
using UnityEngine;

using Unity.Services.LevelPlay;

namespace DeeperAndDeeper.Main
{
    public class AdsInitializer : MonoBehaviour
    {
        private static AdsInitializer Instance { get; set; }

        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
                InitializeAds();
            }
            else
            {
                Destroy(gameObject);
            }
        }

        void OnDestroy()
        {
            if (Instance == this)
            {
                Instance = null;
            }
        }

        public void InitializeAds()
        {
            LevelPlay.OnInitSuccess += SdkInitializationCompletedEvent;
            LevelPlay.OnInitFailed += SdkInitializationFailedEvent;
            // SDK init
            //LevelPlay.Init("2369d95ed");
        }

        private void SdkInitializationFailedEvent(com.unity3d.mediation.LevelPlayInitError error)
        {
            Debug.LogError("SdkInitializationFailedEvent");
        }

        private void SdkInitializationCompletedEvent(com.unity3d.mediation.LevelPlayConfiguration configuration)
        {
            Debug.LogError("SdkInitializationCompletedEvent");
        }
    }
}
