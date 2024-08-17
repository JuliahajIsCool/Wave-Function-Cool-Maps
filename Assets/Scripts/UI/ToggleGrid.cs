using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleGrid : MonoBehaviour
{
    //Turns the grid overlay on or off

    public Toggle toggle;

    public void valueChanged()
    {
        if (toggle.isOn == true)
        {
            GameObject[] grids = GameObject.FindGameObjectsWithTag("Grid");

            foreach (GameObject grid in grids)
            {
                grid.transform.position = new Vector3(grid.transform.position.x, grid.transform.position.y,-1);
            }
        }
        else
        {
            GameObject[] grids = GameObject.FindGameObjectsWithTag("Grid");

            foreach (GameObject grid in grids)
            {
                grid.transform.position = new Vector3(grid.transform.position.x, grid.transform.position.y, 1);
            }
        }
    }
}
