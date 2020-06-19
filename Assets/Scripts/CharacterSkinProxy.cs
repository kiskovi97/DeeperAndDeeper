using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSkinProxy : MonoBehaviour
{
    public SpriteRenderer image;

    // Update is called once per frame
    void Update()
    {
        image.sprite = ItemsContainer.CharacterSprite;
    }
}
