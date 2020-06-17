using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class MarketPlace : MonoBehaviour
{
    public ItemsForSale itemsLayout;

    private static MarketPlace instance;

    public TextMeshProUGUI priceText;

    // Start is called before the first frame update
    void Awake()
    {
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
        UpdateOutput();
    }

    internal static void Buy(ItemForSale item)
    {
        if (instance != null)
        {
            if (GameState.Currency < item.Price) return;

            GameState.Currency -= item.Price;

            ItemsContainer.Buy(item);
            instance.UpdateOutput();
        }
    }

    public void Clear()
    {
        GameState.Currency = 1000;

        ItemsContainer.Clear();
        
        UpdateOutput();
    }

    void UpdateOutput()
    {
        itemsLayout.SetItemsForSale(ItemsContainer.BuyableItems.ToArray());
        priceText.text = "Currency: " + GameState.Currency.ToString();
    }

}
