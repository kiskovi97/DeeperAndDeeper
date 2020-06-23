using UnityEngine;
using Facebook.Unity;

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
        FB.ShareLink(
            contentTitle: "Deeper and Deeper",
            contentDescription: "It's a fun game, when the player must go depper and deeper into the caves.",
            contentURL: new System.Uri("https://play.google.com/store/apps/details?id=com.igorodcavok.DeeperAndDeeper"),
            callback: Callback);
    }

    void Callback(IShareResult shareResult)
    {
        if (shareResult.Cancelled)
        {
            Debug.Log(shareResult.RawResult);
        }
    }
}
