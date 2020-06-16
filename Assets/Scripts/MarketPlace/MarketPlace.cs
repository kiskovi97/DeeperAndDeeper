using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class MarketPlace : MonoBehaviour
{
    public ItemsForSale itemsLayout;

    public List<ItemForSale> items;

    public string boughtItems;

    private static MarketPlace instance;

    public TextMeshProUGUI priceText;

    // Start is called before the first frame update
    void Awake()
    {
        boughtItems = PlayerPrefs.GetString("BoughtItems");

        var list = boughtItems.Split(';').Where((item) => !item.Equals("")).Select((item) => int.Parse(item));

        foreach (var x in list)
        {
            var selected = items.Where((item) => item.Id == x).FirstOrDefault();
            selected.bought = true;
        }

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

        var index = items.IndexOf(item);
        items[index].bought = true;

        boughtItems += ";" + item.Id;

        UpdateOutput();
    }

    public void Clear()
    {
        boughtItems = "";

        GameState.Currency = 1000;

        foreach (var item in items)
        {
            item.bought = false;
        }
        UpdateOutput();
    }

    void UpdateOutput()
    {
        PlayerPrefs.SetString("BoughtItems", boughtItems);

        var tmp = items.Where((x) => !x.bought).ToArray();
        itemsLayout.SetItemsForSale(tmp);

        priceText.text = GameState.Currency.ToString();
    }
}
