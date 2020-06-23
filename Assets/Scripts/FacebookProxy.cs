using UnityEngine;
using Facebook.Unity;
using System.Collections;
using System.IO;

public class FacebookProxy : MonoBehaviour
{
    private void Awake()
    {
        if (!FB.IsInitialized)
        {
            FB.Init();
        }
        else
        {
            FB.ActivateApp();
        }
    }
    public void Share()
    {
        SocialShare();
    }

    public void FacebookShare()
    {
        FB.ShareLink(
             contentTitle: "Deeper and Deeper",
             contentDescription: "It's a fun game, when the player must go depper and deeper into the caves.",
             contentURL: new System.Uri("https://play.google.com/store/apps/details?id=com.igorodcavok.DeeperAndDeeper"),
             callback: Callback);
    }

    public void SocialShare()
    {
        new NativeShare().SetTitle("Deeper and Deeper Sharing").SetSubject("Deeper and Deeper Sharing")
           .SetText("I just layed with deeper and deeper! "
           +"My score was: "+GameState.score+" https://play.google.com/store/apps/details?id=com.igorodcavok.DeeperAndDeeper")
           .Share();
    }

    void Callback(IShareResult shareResult)
    {
        if (shareResult.Cancelled)
        {
            Debug.Log(shareResult.RawResult);
        }
    }
}
