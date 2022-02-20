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
            Debug.Log("je vo mne " + other.gameObject.name);
        }
        else
        {

        }
    }
}
