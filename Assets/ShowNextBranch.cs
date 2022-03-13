using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowNextBranch : MonoBehaviour
{
    [SerializeField] GameObject go;
    void Update()
    {
         if(gameObject.activeSelf == true){
            go.SetActive(true);
            Destroy(this);      //Destroys script
         }
        
    }
}
