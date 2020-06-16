using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinObject : MonoBehaviour
{
    public CharacterSkin skin;

    public Image image;

    // Start is called before the first frame update
    void Update()
    {
        if (skin != null)
            image.sprite = skin.Image;


        var rect = GetComponent<RectTransform>();
        
        rect.sizeDelta = new Vector2(rect.rect.height, rect.rect.height);
    }
}
