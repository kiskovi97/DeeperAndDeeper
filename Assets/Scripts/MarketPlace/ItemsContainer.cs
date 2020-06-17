using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public delegate void ItemsChangedDelegate();

public class ItemsContainer : MonoBehaviour
{
    private static ItemsContainer instance;

    [SerializeField]
    private List<ItemForSale> items;

    [SerializeField]
    private CharacterSkin defaultSkin;

    public static IEnumerable<ItemForSale> BuyableItems => instance.items.Where((x) => !x.bought);

    public static event ItemsChangedDelegate ItemsChanged;
    public static event ItemsChangedDelegate SelectionChanged;

    internal static void SelectSkin(CharacterSkin selected)
    {
        SelectedSkinId = selected.Id;
        SelectionChanged?.Invoke();
    }

    public static IEnumerable<CharacterSkin> Skins
    {
        get
        {
            if (instance == null) return new List<CharacterSkin> { instance.defaultSkin };
            return instance.items
                .Where((item) => item.bought && item is CharacterSkin)
                .Cast<CharacterSkin>()
                .Concat(new[] { instance.defaultSkin });
        }
    }

    private static string BoughtItems { get => PlayerPrefs.GetString("BoughtItems"); set { PlayerPrefs.SetString("BoughtItems", value); PlayerPrefs.Save(); } }

    private static int selectedSkinId = -1;

    public static int SelectedSkinId
    {
        get
        {

            if (selectedSkinId == -1)
            {
                selectedSkinId = PlayerPrefs.GetInt("SelectedSkinId");
            }
            return selectedSkinId;
        }
        private set
        {
            PlayerPrefs.SetInt("SelectedSkinId", value);
            selectedSkinId = value;
            PlayerPrefs.Save();
        }
    }

    public static GameObject Character
    {
        get
        {
            var item = Skins.Where((x) => x.Id == SelectedSkinId).FirstOrDefault();
            if (item == null)
            {
                return instance.defaultSkin.characterPrefab;
            }
            return item.characterPrefab;
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            Screen.sleepTimeout = (int)SleepTimeout.NeverSleep;
            GameObject[] objs = GameObject.FindGameObjectsWithTag("ItemsContainer");

            if (objs.Length > 1)
            {
                Destroy(this.gameObject);
            }
            else
            {
                DontDestroyOnLoad(this.gameObject);
                instance = this.gameObject.GetComponent<ItemsContainer>();
                instance.SetBoughtItems();
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

    internal static void Clear()
    {
        foreach (var item in instance.items)
        {
            item.bought = false;
        }

        BoughtItems = "";

        ItemsChanged?.Invoke();
    }

    public void SetBoughtItems()
    {
        var list = BoughtItems.Split(';').Where((item) => !item.Equals("")).Select((item) => int.Parse(item));
        foreach (var x in items)
        {
            x.bought = false;
        }
        foreach (var x in list)
        {
            var selected = items.Where((item) => item.Id == x).FirstOrDefault();
            if (selected != null)
                selected.bought = true;
        }
    }

    public static void Buy(ItemForSale item)
    {
        if (instance != null)
        {
            instance.BuyItem(item);
            ItemsChanged?.Invoke();
        }
    }

    void BuyItem(ItemForSale item)
    {
        var index = items.IndexOf(item);
        items[index].bought = true;

        BoughtItems += ";" + item.Id;
    }

}
