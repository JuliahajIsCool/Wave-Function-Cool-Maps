using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPressed : MonoBehaviour
{
    public Camera mainCamera;
    public Camera menuCamera;
    public bool isInMenu;

    private void Start()
    {
        menuCamera.enabled = false;
    }
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {

            if(isInMenu == false)
            {
                isInMenu = true;
                mainCamera.enabled = false;
                menuCamera.enabled = true;
            }
            else
            {
                isInMenu = false;
                mainCamera.enabled = true;
                menuCamera.enabled = false;
            }
        }
    }
}
