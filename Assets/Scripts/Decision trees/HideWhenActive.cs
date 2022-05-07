using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideWhenActive : MonoBehaviour
{
    [SerializeField] GameObject go;
    void Update()
    {
        if (gameObject.activeSelf == true)
        {
            go.SetActive(false);
            Destroy(this);      //Destroys script
        }
    }
}
