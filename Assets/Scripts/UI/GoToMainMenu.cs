using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GoToMainMenu : MonoBehaviour
{
    //Changes scene to main menu and sets the map values to default

    public string sceneName;
    public void LoadScene()
    {
        StaticData.value = 0;
        StaticData.mapSize = 10;
        StaticData.water = false;
        SceneManager.LoadScene(sceneName);
    }
}
