using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using System;

public class ExportMap : MonoBehaviour
{
    //Script to expot the map the png

    public GameObject savedMessage;
    public HideExportMessage hideExportMessage;

    private RenderTexture renderTexture;
    private Camera renderCamera;
    private Vector4 bounds;

    //sets the resolution of the image based of each tile resoltion and the map size
    private int resolution = 160*StaticData.mapSize;
    private float cameraDistance = -2.0f;

    public void SaveMap()
    {
        Debug.Log("Initializing camera and stuff...");

        gameObject.AddComponent(typeof(Camera));

        renderCamera = GetComponent<Camera>();
        renderCamera.enabled = true;
        renderCamera.cameraType = CameraType.Game;
        renderCamera.forceIntoRenderTexture = true;
        renderCamera.orthographic = true;
        renderCamera.orthographicSize = 5;
        renderCamera.aspect = 1.0f;
        renderCamera.targetDisplay = 2;

        //Creates a camera and a render texure
        renderTexture = new RenderTexture(resolution, resolution, 24);

        renderCamera.targetTexture = renderTexture;

        bounds = new Vector4();

        Debug.Log("Initialized successfully!");
        Debug.Log("Computing level boundaries...");

        //Creates the bounds of the level to be turned into a png
        object[] gameObjects = FindObjectsOfType(typeof(GameObject));

        foreach (object gameObj in gameObjects)
        {
            GameObject levelElement = (GameObject)gameObj;
            Bounds boundaries = new Bounds();

            if (levelElement.GetComponentInChildren<Renderer>() != null)
            {
                boundaries = levelElement.GetComponentInChildren<Renderer>().bounds;
            }
            else if (levelElement.GetComponentInChildren<Collider2D>() != null)
            {
                boundaries = levelElement.GetComponentInChildren<Collider2D>().bounds;
            }
            else
            {
                continue;
            }

            if (boundaries != null)
            {
                bounds.w = Mathf.Min(bounds.w, boundaries.min.x);
                bounds.x = Mathf.Max(bounds.x, boundaries.max.x);
                bounds.y = Mathf.Min(bounds.y, boundaries.min.y);
                bounds.z = Mathf.Max(bounds.z, boundaries.max.y);
            }
        }

        Debug.Log("Boundaries computed successfuly! The computed boundaries are " + bounds);
        Debug.Log("Computing target image resolution and final setup...");

        int xRes = Mathf.RoundToInt(resolution * ((bounds.x - bounds.w) / (renderCamera.aspect * renderCamera.orthographicSize * 2 * renderCamera.aspect)));
        int yRes = Mathf.RoundToInt(resolution * ((bounds.z - bounds.y) / (renderCamera.aspect * renderCamera.orthographicSize * 2 / renderCamera.aspect)));

        Texture2D virtualPhoto = new Texture2D(xRes, yRes, TextureFormat.RGB24, false);
        RenderTexture.active = renderTexture;

        Debug.Log("Success! Everything seems ready to render!");

        //The camera is moved along hte bounds and stitches together an image until the whole map is captured
        for (float i = bounds.w, xPos = 0; i < bounds.x; i += renderCamera.aspect * renderCamera.orthographicSize * 2, xPos++)
        {
            for (float j = bounds.y, yPos = 0; j < bounds.z; j += renderCamera.aspect * renderCamera.orthographicSize * 2, yPos++)
            {
                gameObject.transform.position = new Vector3(i + renderCamera.aspect * renderCamera.orthographicSize, j + renderCamera.aspect * renderCamera.orthographicSize, cameraDistance);

                renderCamera.Render();

                virtualPhoto.ReadPixels(new Rect(0, 0, resolution, resolution), (int)xPos * resolution, (int)yPos * resolution);

                Debug.Log("Rendered and copied chunk " + (xPos + 1) + ":" + (yPos + 1));
            }
        }


        RenderTexture.active = null;
        renderCamera.targetTexture = null;

        byte[] bytes = virtualPhoto.EncodeToPNG();

        //Saves the map image
        System.IO.File.WriteAllBytes(@"SavedMaps\ScreenShotTaken" + DateTime.Now.ToString("dd_MM_yyyy_hh_mm_ss") + ".png", bytes);

        //Displays a message notifing the user the map has been saved
        hideExportMessage.startTime = Time.time;
        savedMessage.SetActive(true);
        

    }
}
