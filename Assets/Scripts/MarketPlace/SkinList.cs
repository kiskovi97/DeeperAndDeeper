using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinList : MonoBehaviour
{
    public CharacterSkin[] skins;

    public GameObject skinObjectPrefab;

    private RectTransform rectTransform;

    private float width = 214;

    private HorizontalLayoutGroup horizontalLayoutGroup;

    private bool changed = true;

    public void SetItemsForSale(CharacterSkin[] items)
    {
        skins = items;
        changed = true;
    }

    // Start is called before the first frame update
    void Awake()
    {
        horizontalLayoutGroup = GetComponent<HorizontalLayoutGroup>();
        rectTransform = GetComponent<RectTransform>();
    }

    private void Update()
    {
        if (!changed) return;
        changed = false;
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject, 0.1f);
        }

        for (int i = 0; i < skins.Length; i++)
        {
            var obj = Instantiate(skinObjectPrefab, transform);
            var item = obj.GetComponent<SkinObject>();
            item.skin = skins[i];

        }
    }
}
