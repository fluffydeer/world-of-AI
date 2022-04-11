﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;
using UnityEngine.Events;

public class SnapZone : MonoBehaviour
{
    [SerializeField] private Animator anim = null;
    [SerializeField] private GameObject outputText = null;
    [SerializeField] private GameObject teleportArea = null;
    [SerializeField] private GameObject CD_in_driver = null;
    [SerializeField] private Renderer renderer = null;
    [SerializeField] private ParticleSystem electricityParticleSystem;

    private string closeCDDrive = "Close_CD_Drive";

    public bool turnOn = false;
    private bool turnedOnOnce = true;

    void Start()
    {
    }

    private void Update() {
        //v editore mozem nastavit turnOn
        if(turnOn && turnedOnOnce){
            turnedOnOnce = false;
            boze();
        }
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("CD")){
            boze();     //toto by sa malo spustat z ineho skriptu
        }
    }
    public IEnumerator ShowWithDelay(GameObject something)
    {
        yield return new WaitForSeconds(2.0f);
        something.SetActive(true);
    }

    private void boze(){
            CD_in_driver.SetActive(true);
            NeuralNetworkManager.Instance.PlayCDPlayerClosingSound();

            //asi toto zabija tu korutinu
            //gameObject.SetActive(false);  
            /*It's not true, though. I've tried this and for me the coroutines 
            are stopped as soon as I call SetActive(false) on the MonoBehaviour.
             EDIT: As @Bunny83 has pointed out, SetActive() disables the 
             GameObject, which is not the same as disabling the MonoBehaviour. 
             I still find it very misleading that the documentation never 
             mentions that disabling a GameObject also stops all coroutines. 
            They do not continue when you re-enable the object.*/ 
            //Renderer renderer = GetComponent<MeshRenderer>();
            Color c = new Color(0,0,0,0);
            renderer.material.color = c;

            //animate the cd player
            Debug.Log("animating");
            anim.Play(closeCDDrive, 0, 0.0f);

            StartCoroutine(NeuralNetworkManager.Instance.ShowWithDelay(outputText));
            electricityParticleSystem.Play();

            teleportArea.GetComponent<TeleportArea>().locked = false;
    }
}