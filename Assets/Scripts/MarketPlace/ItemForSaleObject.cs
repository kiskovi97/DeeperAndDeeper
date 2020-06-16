using System.Collections;
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

    public Image image;

    // Start is called before the first frame update
    void Start()
    {
        if (item == null) return;

        nameText.text = item.name;
        descriptionText.text = item.desciption;
        priceText.text = item.price.ToString();

        image.sprite = item.image;
    }
}
