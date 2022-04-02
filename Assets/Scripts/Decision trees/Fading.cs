﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fading : MonoBehaviour
{
    public float fadeSpeed = 1;
    private MeshRenderer renderer;
    
    void Start()
    {
        renderer = GetComponent<MeshRenderer>();
    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.B)){
            StartCoroutine("FadeOut");
        }
        if(Input.GetKeyDown(KeyCode.C)){
            StartCoroutine("FadeIn");
        }
    }

    public IEnumerator FadeOut(){
        for(float f = 1f; f >= -0.05f; f -= 0.05f){
            Color c = renderer.material.color;
            c.a = f;
            renderer.material.color = c;
            yield return new WaitForSeconds(0.05f);
        }
    }

    public IEnumerator FadeIn(){
        for(float f = 0f; f <= 1.1f; f += 0.05f){
            Color c = renderer.material.color;
            c.a = f;
            renderer.material.color = c;
            yield return new WaitForSeconds(0.05f);
        }
    }
}