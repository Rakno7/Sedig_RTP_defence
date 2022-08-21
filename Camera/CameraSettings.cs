using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSettings : MonoBehaviour
{
    private Camera cam;
   
    public List<Light> Gamelights;
     public List<Light> MinimapLights;
    void Start()
    {
        cam = GetComponent<Camera>();
       Camera.onPreRender += OnPreRenderCallback;
    }

  
    void Update()
    {
    
       
    }
    /// <summary>
    /// OnPreRender is called before a camera starts rendering the scene.
    /// </summary>
    private void OnPreRenderCallback(Camera camera)
    {
        foreach(Light light in Gamelights)
        {
            if(camera == Camera.main)
            {
            light.enabled = false;
            }
            else
            {
                light.enabled = true;
            }
        }
        foreach(Light Mlight in MinimapLights)
        {
            if(camera == Camera.main)
            {
            Mlight.enabled = true;
            }
            else
            {
                Mlight.enabled = false;
            }
        }
    }
    /// <summary>
    /// OnPostRender is called after a camera finishes rendering the scene.
    /// </summary>
    private void OnPostRenderCallback(Camera camera)
    {
         foreach(Light light in Gamelights)
        {
            light.enabled = true;
        }
         foreach(Light Mlight in MinimapLights)
        {
            Mlight.enabled = true;
        }
    }

    /// <summary>
    /// This function is called when the MonoBehaviour will be destroyed.
    /// </summary>
    private void OnDestroy()
    {
        Camera.onPreRender -= OnPreRenderCallback;
    }
    
}
