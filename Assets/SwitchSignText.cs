using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class SwitchSignText : MonoBehaviour
{
    //we need to set size of array in the inspector
    [SerializeField] TMP_Text[] texts;
    //another way of doing this would be to find children of the canvas
    private index = 0;

    void Start()
    {

    }

    public void OnButtonDown()
    {
        Debug.Log("downnn");
        
    }

    public void OnButtonUp()
    {
        Debug.Log("UPPP");
        gameObject.SetActive(false);
    }

    //toto by som este mala prilinkovat v button -> v on trigger funkciach
    public void GoNext()
    {
        texts[index].text = "heh";
        indexer++;
        //schovat potom button ak uzje index posledny
    }

    public void GoBack()
    {

    }
}
