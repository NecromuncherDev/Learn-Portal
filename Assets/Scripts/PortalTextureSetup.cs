using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTextureSetup : MonoBehaviour
{
    [SerializeField] private Camera cameraB;
    [SerializeField] private Material cameraMatB;
    [SerializeField] private Camera cameraA;
    [SerializeField] private Material cameraMatA;


    void Start()
    {
        InitPortalCam(cameraA, cameraMatA);
        InitPortalCam(cameraB, cameraMatB);
    }

    private void InitPortalCam(Camera cam, Material mat)
    {
        if (cam.targetTexture != null)
            cam.targetTexture.Release();

        cam.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        mat.mainTexture = cam.targetTexture;
    }
}
