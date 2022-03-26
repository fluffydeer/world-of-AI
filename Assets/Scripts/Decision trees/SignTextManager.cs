using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class SignTextManager : MonoBehaviour
{
    [SerializeField] GameObject nextButton;
    [SerializeField] GameObject backButton;

    //another way of doing this would be to find children of the canvas
    //we need to set size of array in the inspector
    [SerializeField] TMP_Text[] texts;
    private int index = 0;  //Static? 

    public void Start(){
        //to hide BackButtons - buttons going to left if they are visible
        HandleButtonVisibility();
    }

    public void OnButtonDown(int direction)
    {
        ChangeText(direction);
    }

    //toto by som este mala prilinkovat v button -> v on trigger funkciach
    //schovat potom button ak uzje index posledny
    public void ChangeText(int increment)
    {
        Debug.Log("current: " + index);
        texts[index].gameObject.SetActive(false);
        index = index + increment;
        Debug.Log("new: " + index);
        texts[index].gameObject.SetActive(true);
        HandleButtonVisibility();
    }

    //first Text (TMP) always needs to be visible in the editor
    private void HandleButtonVisibility(){
        if(index == texts.Length-1){
            nextButton.SetActive(false);
        }else if(index == 0){
            backButton.SetActive(false);
        }else{  
            //toto je neefektivne, lebo to vzdy nastavuje viditelnost
            //i ked to uz viditelne moze byt
            nextButton.SetActive(true);
            backButton.SetActive(true);
        }
    }

    public void Hide(GameObject hideMe){
        hideMe.SetActive(false);
    }
}
