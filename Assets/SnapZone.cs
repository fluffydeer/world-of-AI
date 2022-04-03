using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;
using UnityEngine.Events;

public class SnapZone : MonoBehaviour
{
    [SerializeField] private Animator anim = null;
    [SerializeField] private GameObject outputText = null;
    private string closeCDDrive = "Close_CD_Drive";


    //[SerializeField] private GameObject CD_static = null;
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("CD")){
            gameObject.SetActive(false);
            Destroy(other.gameObject.GetComponent<Throwable>());
            Destroy(other.gameObject.GetComponent<Interactable>());
            Destroy(other.gameObject.GetComponent<Rigidbody>());
            //toto mozem zmazat
            other.gameObject.transform.parent = transform.parent;
            other.gameObject.transform.position = transform.position;
            other.gameObject.transform.rotation = transform.rotation;
            other.gameObject.transform.localScale = transform.localScale;
            //lebo ja budem ukazovat toto
            //CD_static.SetActive(true);
            anim.Play(closeCDDrive, 0, 0.0f);
            outputText.SetActive(true);
            StartCoroutine(NeuralNetworkManager.Instance.ShowWithDelay(outputText));
        }
    }
}
