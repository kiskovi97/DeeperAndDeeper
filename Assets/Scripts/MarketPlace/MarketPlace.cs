using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class MarketPlace : MonoBehaviour
{
    public ItemsForSale itemsLayout;

    public ItemForSale[] items;

    // Start is called before the first frame update
    void Awake()
    {
        itemsLayout.SetItemsForSale(items.Where((item) => !item.bought).ToArray());
    }

}
