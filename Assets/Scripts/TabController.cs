using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabController : MonoBehaviour
{

    public GameObject[] Windows;

    public void Change(int i)
    {
        if (i > Windows.Length - 1) return;
        if (Windows[i].activeSelf)
        {
            Windows[i].SetActive(false);
        }
        else
        {
            Windows[i].SetActive(true);
            for (int j = 0; j < Windows.Length; j++)
            {
                if (i != j)
                    Windows[j].SetActive(false);
            }
        }
    }
}
