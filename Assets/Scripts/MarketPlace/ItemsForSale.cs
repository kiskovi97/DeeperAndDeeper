using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(VerticalLayoutGroup))]
[RequireComponent(typeof(RectTransform))]
public class ItemsForSale : MonoBehaviour
{
    private RectTransform rectTransform;

    private ItemForSale[] itemsForSale;

    public float height = 100;

    public GameObject prefab;

    private VerticalLayoutGroup verticalLayout;

    private bool changed = false;

    public void SetItemsForSale(ItemForSale[] items)
    {
        itemsForSale = items;
        changed = true;
    }

    // Start is called before the first frame update
    void Awake()
    {
        verticalLayout = GetComponent<VerticalLayoutGroup>();
        rectTransform = GetComponent<RectTransform>();
    }

    private void Update()
    {
        if (!changed) return;
        changed = false;
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject, 0.1f);
        }

        var size = rectTransform.sizeDelta;
        size.y = (float)verticalLayout.padding.top;
        for (int i = 0; i < itemsForSale.Length; i++)
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
