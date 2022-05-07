using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisibilityHandler : MonoBehaviour
{
    [SerializeField] GameObject go;
    [SerializeField] bool makeVisible;

    void Update()
    {
         if(gameObject.activeSelf == true){
            go.SetActive(makeVisible);
            Destroy(this);      //Destroys script
         }
    }
}
