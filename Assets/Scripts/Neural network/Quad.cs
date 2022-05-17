using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quad : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if (other.name.Equals("Pencil")) { 
            HandlePencil();
            
        }
        else if (other.name.Equals("Eraser"))
        {
            HandleEraser();
        }
    }

    private void HandlePencil(){
        gameObject.GetComponent<Renderer>().material.color = new Color(0, 204, 102);
        gameObject.GetComponent<Renderer>().material.color = new Color(255, 255, 255);
        Drawing.Instance.AddHighlightedQuad(gameObject);
        Drawing.Instance.ExecuteMnist();
        GetComponent<BoxCollider>().enabled = false;
    }

    private void HandleEraser(){
        Drawing.Instance.ClearTexture();
    }
}
