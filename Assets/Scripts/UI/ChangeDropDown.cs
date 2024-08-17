using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChangeDropDown : MonoBehaviour
{
    //The results of changing the drop down for map type

    [SerializeField] private TMP_Dropdown dropdown;
    public Toggle wt;
    public GameObject waterToggle;
    public void Change()
    {
        switch (dropdown.value)
        {
            case 0: waterToggle.SetActive(true);
                break;
            case 1:
                wt.isOn = false;
                waterToggle.SetActive(false);
                break;
            case 2:
                waterToggle.SetActive(true);
                break;

        }
        StaticData.value = dropdown.value;
    }
}
