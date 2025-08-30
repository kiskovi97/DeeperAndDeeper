using System;
using System.Collections.Generic;
using UnityEngine;

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
        }

        private void RequestBanner()
        {
#if UNITY_ANDROID
            string adUnitId = "ca-app-pub-5964647989848848/1815719323";
#elif UNITY_IPHONE
            string adUnitId = "ca-app-pub-5964647989848848/1815719323";
#else
            string adUnitId = "unexpected_platform";
#endif

#if !UNITY_EDITOR
            // Create a 320x50 banner at the top of the screen.
            this.bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Top);
            // Called when an ad request has successfully loaded.
            this.bannerView.OnAdLoaded += this.HandleOnAdLoaded;
            // Called when an ad request failed to load.
            this.bannerView.OnAdFailedToLoad += this.HandleOnAdFailedToLoad;
            // Called when an ad is clicked.
            this.bannerView.OnAdOpening += this.HandleOnAdOpened;
            // Called when the user returned from the app after an ad click.
            this.bannerView.OnAdClosed += this.HandleOnAdClosed;


            AdRequest request = new AdRequest.Builder().Build();

            // Load the banner with the request.
            this.bannerView.LoadAd(request);
#endif

        }
    }
}
