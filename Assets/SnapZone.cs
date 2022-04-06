using System.Collections;
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
            boze();
        }
    }
    public IEnumerator ShowWithDelay(GameObject something)
    {
        yield return new WaitForSeconds(2.0f);
        something.SetActive(true);
    }

    private void boze(){
            //show the CD in Driver
            CD_in_driver.SetActive(true);

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

            //fade the output text    
            //outputText.SetActive(true);
            StartCoroutine(NeuralNetworkManager.Instance.ShowWithDelay(outputText));
            //StartCoroutine(ShowWithDelay(outputText));

            teleportArea.GetComponent<TeleportArea>().locked = false;
            
            //toto mozem zmazat
            //toto nefungovalo
            //other.gameObject.transform.SetParent(transform);  
            //ak by fungovalo toto, tak by asi vsetky tieto dalsie vlastnosti museli byt 0s

            /*
            Destroy(other.gameObject.GetComponent<Throwable>());
            Destroy(other.gameObject.GetComponent<Interactable>());
            Destroy(other.gameObject.GetComponent<Rigidbody>());
            
            Debug.Log("after: other.gameObject.transform.parent " + other.gameObject.transform.parent.name);
            Debug.Log("ater: transform.parent " + transform.parent.name);
            other.gameObject.transform.position = transform.position;
            other.gameObject.transform.rotation = transform.rotation;
            other.gameObject.transform.localScale = transform.localScale;
            //lebo ja budem ukazovat toto*/
            //CD_static.SetActive(true);
    }
}
