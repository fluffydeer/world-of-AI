using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//script for handling user interaction with tablet 
//specifically with the Text (TMP) the player will touch on
public class TabletInteraction : MonoBehaviour{
    [SerializeField] GameObject highlight;
    //[SerializeField] bool isSelected;
    [SerializeField] bool isCorrect;

    private void OnTriggerEnter(Collider other){
        //tu by bolo fajn kontrolovatze ci zaciatok sova je finger a az potom t oznacit
        //Debug.Log(this.name + " was entered");
        Debug.Log(other.name);
        if (gameObject.CompareTag("OkButton")){
            PressButton();
        }
        else if (gameObject.CompareTag("TabletData")){
            HighlightRow();
        }
    }

    private void HighlightRow(){
        //Debug.Log("TABLETDATA");
        //this resets all the highlights and highlights the one user just touched
        Transform parent = this.transform.parent;
        foreach (Transform child1 in parent){
            foreach (Transform child2 in child1){
                GameObject o = child2.gameObject;
                if (o.name == "Highlight"){
                    o.SetActive(false);
                }
            }
        }
        GameObject highlight = gameObject.transform.Find("Highlight").gameObject;
        highlight.SetActive(true);
        Tablet.Instance.SetSelectedAnswer(gameObject);      //here we send the whole object also with this script!
    }

    private void PressButton(){
        //Debug.Log("OKBUTTON");
        GameObject pressedButton = gameObject.transform.Find("PressedButton").gameObject;
        GameObject unpressedButton = gameObject.transform.Find("UnpressedButton").gameObject;

        pressedButton.SetActive(true);
        unpressedButton.SetActive(false);
        StartCoroutine(Tablet.Instance.SetActive(unpressedButton, 0.5f));  
        Tablet.Instance.CheckAnswers();
    }

    public bool GetIsCorrect(){
        return isCorrect;
    }

    public void SetHighlightColor(Color color)
    {
        highlight.gameObject.GetComponent<Renderer>().material.color = color;
    }
}
