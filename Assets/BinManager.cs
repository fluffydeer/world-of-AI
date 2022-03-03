using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class BinManager : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other) {
        Debug.Log("other name: " + other.gameObject.name);
        Debug.Log("other tag: " + other.gameObject.tag);
        Debug.Log("bin: " + gameObject.tag);
        if (other.gameObject.CompareTag(gameObject.tag)){
            Debug.Log("dobre") ;
        }
        else
        {
            Debug.Log("zle");
        }
    }
}
