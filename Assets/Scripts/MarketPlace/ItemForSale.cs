using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item For Sale", menuName = "MarketPlace/ItemForSale")]
public class ItemForSale : ScriptableObject
{
    public bool bought = false;

    public string Name;

    public int Price;

    public Sprite Image;

    public string Desciption;
}
