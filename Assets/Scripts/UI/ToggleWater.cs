using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleWater : MonoBehaviour
{
    public Toggle toggle;

    public void valueChanged()
    {
        if (toggle.isOn == true)
        {
            StaticData.water = true;
        }
        else
        {
            StaticData.water = false;
        }
    }
}
