using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightUp : MonoBehaviour
{
    void Start()
    {
        MeshRenderer ren = GetComponent<MeshRenderer>();
        ren.material.color = Color.cyan;
    }

    void Update()
    {
        
    }
}
