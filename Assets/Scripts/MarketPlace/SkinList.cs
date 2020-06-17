using UnityEngine;
using UnityEngine.UI;

public class SkinList : MonoBehaviour
{
    private CharacterSkin[] skins;

    public GameObject skinObjectPrefab;

    private bool changed = false;

    private int selectedId;

    public void SetItemsForSale(CharacterSkin[] skins, int selectedId)
    {
        this.skins = skins;
        this.selectedId = selectedId;
        changed = true;
    }

    public void SetSelection(int selectedId)
    {
        this.selectedId = selectedId;

        Debug.Log("Selected skin: " + selectedId);

        foreach (Transform child in transform)
        {
            var item = child.GetComponent<SkinObject>();
            var button = item.GetComponent<Button>();

            item.SetSelection(item.skin.Id == selectedId);
        }
    }

    private void Update()
    {
        if (!changed) return;
        changed = false;
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }

        Debug.Log("Selected skin: " + selectedId);

        for (int i = 0; i < skins.Length; i++)
        {
            var obj = Instantiate(skinObjectPrefab, transform);
            var item = obj.GetComponent<SkinObject>();
            item.skin = skins[i];

            item.SetSelection(item.skin.Id == selectedId);
            
        }
    }
}
