using UnityEngine;
using System.Collections;
using System.IO;

public class FacebookProxy : MonoBehaviour
{
    public void Share()
    {
        SocialShare();
    }

    public void SocialShare()
    {
        new NativeShare().SetTitle("Deeper and Deeper Sharing").SetSubject("Deeper and Deeper Sharing")
           .SetText("I just played with deeper and deeper! "
           +"My score was: "+GameState.score+" https://play.google.com/store/apps/details?id=com.igorodcavok.DeeperAndDeeper")
           .Share();
    }
}
