using UnityEngine;

public class SkinList : MonoBehaviour
{
    private CharacterSkin[] skins;

    public GameObject skinObjectPrefab;

    private float width = 214;

    private bool changed = false;

    public void SetItemsForSale(CharacterSkin[] items)
    {
        skins = items;
        changed = true;
    }

    private void Update()
    {
        if (!changed) return;
        changed = false;
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject, 0.1f);
        }

        for (int i = 0; i < skins.Length; i++)
        {
            var obj = Instantiate(skinObjectPrefab, transform);
            var item = obj.GetComponent<SkinObject>();
            item.skin = skins[i];
        }
    }
}
