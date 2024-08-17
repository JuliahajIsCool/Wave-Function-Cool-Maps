using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    
    public string sceneName;
    public int mapType = 0;
    public void LoadScene()
    {
        if(StaticData.mapSizeError == false)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
