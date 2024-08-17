using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideExportMessage : MonoBehaviour
{
    //after a certain amount of time being displayed hides the saved map message

    public GameObject message;
    public float startTime;

    void Update()
    {
        if (Time.time - startTime >= 0.77)
        {
            message.SetActive(false);
        }
    }
}
