using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BinManager : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other){
        Debug.Log(other.gameObject.name + " entered compost");
        
        if(other.gameObject.CompareTag("Compost")){
            Debug.Log("KOMPOOOST");
        }
    }
}
