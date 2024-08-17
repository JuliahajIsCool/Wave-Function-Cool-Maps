using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticData : MonoBehaviour
{
    //A class containig data which will be used across scenes and should remain how it is set


    public static int mapSize = 10; //Determins the map size
    public static bool water = false; //Determins if the map will include water tiles
    public static int value = 0; //Determins the the type of map 0 = Forest, 1 = Town, 3 = Grasslands
    public static int retry = 0; //The amount of times map generation has tried to generate, if 3 or more, the user will be promted
    public static bool mapSizeError = false; //A flag to check if a valid map size has been given
}
