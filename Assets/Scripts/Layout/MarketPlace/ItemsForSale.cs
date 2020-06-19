using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ItemsForSale : MonoBehaviour
{
    private ItemForSale[] itemsForSale;

    public float height = 100;

    public GameObject prefab;

    private bool changed = false;

    private readonly List<GameObject> objectPool = new List<GameObject>();

    public void SetItemsForSale(ItemForSale[] items)
    {
        itemsForSale = items;
        changed = true;
    }

    private void Update()
    {
        if (!changed) return;
        changed = false;
        while (objectPool.Count > itemsForSale.Length)
        {
            var obj = objectPool[objectPool.Count - 1];
            objectPool.RemoveAt(objectPool.Count - 1);
            Destroy(obj);
        }

        for (int i = 0; i < itemsForSale.Length; i++)
        {
            GameObject obj;
            if (i < objectPool.Count)
            {
                obj = objectPool[i];
            } else
            {
                obj = Instantiate(prefab, transform);
                objectPool.Add(obj);
            }

            var item = obj.GetComponent<ItemForSaleObject>();
            item.item = itemsForSale[i];
            item.UpdateLayout();
        }
    }
}
