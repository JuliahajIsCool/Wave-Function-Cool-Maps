using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class MapSize : MonoBehaviour
{
    //A script for checking if an input map size is valid and setting the map size

    public TMP_InputField inputField;
    public GameObject errorMessage;

    public void textChange()
    {
        if (inputField.text != "")
        {
            if(Convert.ToInt32 (inputField.text) <= 30)
            {
                StaticData.mapSize = Convert.ToInt32(inputField.text);
                StaticData.mapSizeError = false;
            }
            else
            {
                errorMessage.SetActive(true);
                StaticData.mapSizeError = true;
            }

        }
        else
        { 
            StaticData.mapSize = 10; 
        }
        
        
    }
}
