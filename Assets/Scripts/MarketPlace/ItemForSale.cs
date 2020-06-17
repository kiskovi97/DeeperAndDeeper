using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item For Sale", menuName = "MarketPlace/ItemForSale")]
public class ItemForSale : ScriptableObject
{
    public int Id = 0;

    public bool bought = false;

    public string Name;

    public int Price;

    public Sprite Image;

    public string Desciption;

    public override bool Equals(object other)
    {
        if (other is ItemForSale item)
        {
            return item.Id == Id;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return Id;
    }
}
