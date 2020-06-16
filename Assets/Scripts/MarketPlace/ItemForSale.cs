using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item For Sale", menuName = "MarketPlace/ItemForSale")]
public class ItemForSale : ScriptableObject
{
    public string name;

    public int price;

    public Sprite image;

    public string desciption;
}
