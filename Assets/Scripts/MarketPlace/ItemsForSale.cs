using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(VerticalLayoutGroup))]
[RequireComponent(typeof(RectTransform))]
public class ItemsForSale : MonoBehaviour
{
    private RectTransform rectTransform;

    public ItemForSale[] itemsForSale;

    public float height = 100;

    public GameObject prefab;

    private VerticalLayoutGroup verticalLayout;

    // Start is called before the first frame update
    void Start()
    {
        verticalLayout = GetComponent<VerticalLayoutGroup>();
        rectTransform = GetComponent<RectTransform>();
        var size = rectTransform.sizeDelta;
        size.y = (float)verticalLayout.padding.top;
        for (int i=0; i< itemsForSale.Length; i++)
        {
            var obj = Instantiate(prefab, transform);
            var item = obj.GetComponent<ItemForSaleObject>();
            item.item = itemsForSale[i];
            size.y += verticalLayout.spacing + height;
        }
        size.y += verticalLayout.padding.bottom - verticalLayout.spacing;
        rectTransform.sizeDelta = size;
    }
}
