using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public Dropdown Dropdown;

    private void Awake()
    {
        Dropdown.value = GameState.RotationMovement ? 1 : 0;
        Dropdown.onValueChanged.AddListener(Save);
    }

    private void OnDestroy()
    {
        Dropdown.onValueChanged.RemoveListener(Save);
    }

    public void Save(int value)
    {
        var selected = value;
        GameState.RotationMovement = selected != 0;
        PlayerPrefs.SetInt("RotationMovement", selected);
        PlayerPrefs.Save();
    }
}
