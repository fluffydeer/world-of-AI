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
    private string closeCDDrive = "Close_CD_Drive";

    void Start()
    {

    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("CD")){
            outputText.SetActive(true);
            Destroy(other.gameObject.GetComponent<Throwable>());
            Destroy(other.gameObject.GetComponent<Interactable>());
            Destroy(other.gameObject.GetComponent<Rigidbody>());
            //toto mozem zmazat
            Debug.Log("other.gameObject.transform.parent " + other.gameObject.transform.parent.name);
            Debug.Log("transform.parent " + transform.parent.name);
            //other.gameObject.transform.parent = transform.parent;
            //other.gameObject.transform.SetParent(transform.parent);
            other.gameObject.transform.SetParent(transform);  
            //ak by fungovalo toto, tak by asi vsetky tieto dalsie vlastnosti museli byt 0s


            Debug.Log("after: other.gameObject.transform.parent " + other.gameObject.transform.parent.name);
            Debug.Log("ater: transform.parent " + transform.parent.name);
            other.gameObject.transform.position = transform.position;
            other.gameObject.transform.rotation = transform.rotation;
            other.gameObject.transform.localScale = transform.localScale;
            //lebo ja budem ukazovat toto
            //CD_static.SetActive(true);
            anim.Play(closeCDDrive, 0, 0.0f);
            //StartCoroutine(NeuralNetworkManager.Instance.ShowWithDelay(outputText));
            //StartCoroutine(ShowWithDelay(outputText));

            Debug.Log("setting to active");
            teleportArea.GetComponent<TeleportArea>().locked = false;
            gameObject.SetActive(false);    //asi toto zabija tu korutinu
            
        }
    }
    public IEnumerator ShowWithDelay(GameObject something)
    {
        yield return new WaitForSeconds(2.0f);
        something.SetActive(true);
    }
}
