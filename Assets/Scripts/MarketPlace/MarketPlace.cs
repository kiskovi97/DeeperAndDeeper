using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class MarketPlace : MonoBehaviour
{
    public ItemsForSale itemsLayout;

    public List<ItemForSale> items;

    private static MarketPlace instance;

    public TextMeshProUGUI priceText;

    // Start is called before the first frame update
    void Awake()
    {
        itemsLayout.SetItemsForSale(items.Where((item) => !item.bought).ToArray());

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        priceText.text = GameState.Currency.ToString();
    }

    internal static void Buy(ItemForSale item)
    {
        if (instance != null)
        {
            instance.BuyItem(item);
        }
    }

    void BuyItem(ItemForSale item)
    {
        if (GameState.Currency < item.Price) return;

        GameState.Currency -= item.Price;
        
        priceText.text = GameState.Currency.ToString();

        items.Remove(item);

        itemsLayout.SetItemsForSale(items.Where((x) => !x.bought).ToArray());
    }
}
