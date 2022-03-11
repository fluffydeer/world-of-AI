using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Tablet : MonoBehaviour
{
    public static Tablet Instance;       //singleton pattern
    [SerializeField] TextMeshPro hintText;

    private GameObject selectedAnswer;   //correct row on the tablet

    public void Awake(){
        if(Instance != null){
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);  //delete?? will be causing troubles
    }
   
    public void SetSelectedAnswer(GameObject answer)
    {
        selectedAnswer = answer;
    }

    public void CheckAnswers()
    {
        Debug.Log("checking");
        //here the variables of the selected answers should be stored
        TabletInteraction tableInteractionScript = selectedAnswer.GetComponent<TabletInteraction>();
        bool isCorrect = tableInteractionScript.GetIsCorrect();
        if(isCorrect){
            Debug.Log("correct");
            //play correct sound
            //hide canvas1
            //show new tree branches
            //show canvas2
            
            //what happens after canvas2?
            //more branches grow
            //player needs to sort food? 
            //show canvas3 with congratulations?
        }
        else{
            Debug.Log("incorrect");
            hintText.gameObject.SetActive(true);
            hintText.text = "Označ prvú otázku s najvyšším informačným ziskom!";
            StartCoroutine(SetInactive(hintText.gameObject, 2f));

            //play incorrect sound
            //turn highlight red?
            //destroy tabletinteractionscript?
            //set hinttext to "wrong" and make it dissappear after a while, fadeout using coroutine
        }
    }

    public IEnumerator SetActive(GameObject go, float time)
    {
        yield return new WaitForSeconds(time);
        go.SetActive(true);
    }

    public IEnumerator SetInactive(GameObject go, float time)
    {
        yield return new WaitForSeconds(time);
        go.SetActive(false);
    }
}
