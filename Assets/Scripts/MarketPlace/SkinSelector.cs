using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SkinSelector : MonoBehaviour
{
    public SkinList skinList;

    private void Awake()
    {
        skinList.SetItemsForSale(ItemsContainer.Skins.ToArray(), ItemsContainer.SelectedSkinId);
        ItemsContainer.ItemsChanged += ItemsContainer_ItemsChanged;
        ItemsContainer.SelectionChanged += ItemsContainer_SelectionChanged;
    }

    private void ItemsContainer_SelectionChanged()
    {
        skinList.SetSelection(ItemsContainer.SelectedSkinId);
    }

    private void ItemsContainer_ItemsChanged()
    {
        skinList.SetItemsForSale(ItemsContainer.Skins.ToArray(), ItemsContainer.SelectedSkinId);
    }

    

    public static void SelectSkin(CharacterSkin skin)
    {
        ItemsContainer.SelectSkin(skin);
    }
}
