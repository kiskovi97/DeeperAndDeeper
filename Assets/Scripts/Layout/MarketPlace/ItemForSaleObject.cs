﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemForSaleObject : MonoBehaviour
{
    public ItemForSale item;

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI descriptionText;
    public TextMeshProUGUI priceText;

    public Button button;

    public Image image;

    // Start is called before the first frame update
    void Start()
    {
        if (item == null) return;

        nameText.text = item.Name;
        descriptionText.text = item.Desciption;
        priceText.text = item.Price.ToString();

        image.sprite = item.Image;
        button.interactable = item.Price <= GameState.Currency;
    }

    public void UpdateLayout()
    {
        if (item == null) return;

        nameText.text = item.Name;
        descriptionText.text = item.Desciption;
        priceText.text = item.Price.ToString();

        image.sprite = item.Image;
        button.interactable = item.Price <= GameState.Currency;
    }

    public void OnClick()
    {
        MarketPlace.Buy(item);
    }
}
