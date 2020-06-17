using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SkinSelector : MonoBehaviour
{
    public SkinList skinList;

    private void Awake()
    {
        skinList.SetItemsForSale(ItemsContainer.Skins.ToArray());
        ItemsContainer.ItemsChanged += ItemsContainer_ItemsChanged;
    }

    private void ItemsContainer_ItemsChanged()
    {
        skinList.SetItemsForSale(ItemsContainer.Skins.ToArray());
    }

    public static void SelectSkin()
    {
        ItemsContainer.SelectSkin();
    }
}
