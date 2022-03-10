using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//mozem to premenovat na handletabletext
public class TabletInteraction : MonoBehaviour{
    DecisionTreesLevelManager.Instance


    private void OnTriggerEnter(Collider other) {
        if(gameObject.CompareTag("OkButton")){
            Debug.Log("OKBUTTON");
            GameObject pressedButton = gameObject.transform.Find("PressedButton").gameObject;
            pressedButton.SetActive(true);
            GameObject unpressedButton = gameObject.transform.Find("UnpressedButton").gameObject;
            unpressedButton.SetActive(false);
            CheckAnswers();
        }
        if(gameObject.CompareTag("TabletData")){
            Debug.Log("TABLETDATA");
            Transform parent = this.transform.parent;
            foreach (Transform child1 in parent) {
                foreach (Transform child2 in child1){
                    GameObject o = child2.gameObject;
                    if(o.name == "Highlight")
                    {
                        o.SetActive(false);
                    }
                }
            }
            GameObject highlight = gameObject.transform.Find("Highlight").gameObject;
            highlight.SetActive(true);
            //toto by bolo fajn asi poslat do gamemanagera aby to mohol spracovat
            //alebo neviem kde si ulozit tu premennu
            //alebo to tablet skriptu
        
        }
        //tu by bolo fajn kontrolovatze ci zaciatok sova je finger a az potom t oznacit
        Debug.Log(this.name + " was entered");
        Debug.Log(other.name);
    }

    private void CheckAnswers()
    {
        Debug.Log("checking");

    }
}
