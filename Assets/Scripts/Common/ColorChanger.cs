using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    private Renderer renderer;
    private Color originalColor;
    private float time = 1.0f;
     
    void Start()
    {
        renderer = GetComponent<Renderer>();
        originalColor = renderer.material.color;
        LoopGreenColorChange();
    }
    private void LoopGreenColorChange()
    {
        //changes green color over time
        iTween.ColorTo(gameObject, iTween.Hash("g", originalColor.g + 0.5f, "time", time, "looptype", "pingPong", "includeChildren", false));
    }
    
    public void Destroy()
    {
        //destroys itweens on target
        iTween.Stop(gameObject);
        renderer.material.color = originalColor;
        //Destroy(this);
    }
}
