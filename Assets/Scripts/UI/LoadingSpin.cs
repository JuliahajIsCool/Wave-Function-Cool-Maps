using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class LoadingSpin : MonoBehaviour
{
    public RectTransform loadingIcon;
    public float timeStep;
    public float oneStepAngle;

    float startTime;

    void Start()
    {
        startTime = Time.time;
    }

    //Roteates the loading spin by an angle equal to oneStepAngle every timeframe equal to timeStep
    void Update()
    {
        if(Time.time - startTime >= timeStep)
        {
            Vector3 iconAngle = loadingIcon.localEulerAngles;
            iconAngle.z = iconAngle.z + oneStepAngle;

            loadingIcon.localEulerAngles = iconAngle;

            startTime = Time.time;
        }
    }
}
