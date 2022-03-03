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

    public void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag(gameObject.tag)){
            Debug.Log("kos: " + gameObject.tag) ;
            Debug.Log("smetie: " + gameObject.tag);
        }
        else
        {
            Debug.Log("zle");
        }
    }
}
