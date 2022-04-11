using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Tablet : MonoBehaviour
{
    public static Tablet Instance;       //singleton pattern
    [SerializeField] TextMeshPro hintText;
    [SerializeField] GameObject firstPartOfTree;
    [SerializeField] GameObject secondPartOfTree;
    [SerializeField] GameObject canvas1;
    [SerializeField] GameObject canvas2;
    [SerializeField] GameObject canvas3;
    private AudioSource tabletAudio;
    public AudioClip correctAnswerSound;    //dat do managera


    private GameObject selectedAnswer;   //selected row on the tablet

    public void Awake(){
        if(Instance != null){
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);  //delete?? will be causing troubles
    }

    public void Start()
    {
        tabletAudio = GetComponent<AudioSource>();
    }

    public void SetSelectedAnswer(GameObject answer)
    {
        selectedAnswer = answer;
    }

    public void CheckAnswers()
    {
        //here the variables of the selected answers should be stored
        TabletInteraction tableInteractionScript = selectedAnswer.GetComponent<TabletInteraction>();
        bool isCorrect = tableInteractionScript.GetIsCorrect();
        if (isCorrect) {
            Debug.Log("correct");
            string question = selectedAnswer.GetComponent<TextMeshProUGUI>().text;
            tabletAudio.PlayOneShot(DecisionTreesLevelManager.Instance.successSound, 1.0f);


            //play correct sound
            //hide canvas1
            //show new tree branches
            //show canvas2
            if (question.Contains("Žlté")){
                Debug.Log("zlte");
                firstPartOfTree.SetActive(true);
                canvas1.SetActive(false);
                canvas2.SetActive(true);
            }
            else if(question.Contains("Dĺžka"))
            {
                Debug.Log("Dlzka");
            }
            else if(question.Contains("Zelené"))
            {
                Debug.Log("zelene");
                secondPartOfTree.SetActive(true);
                canvas2.SetActive(false);
                canvas3.SetActive(true);
                //what happens after canvas2?
                //more branches grow
                //player needs to sort food? 
                //show canvas3 with congratulations?
            }
            //treba dokoncit fading konara nech sa neobjavi naraz
            //nejaky ten koniec ze kam hrac pojde

        }
        else{
            Debug.Log("incorrect");
            tabletAudio.PlayOneShot(DecisionTreesLevelManager.Instance.failureSound, 1.0f);
            hintText.gameObject.SetActive(true);
            hintText.text = "Označ prvú otázku s najvyšším informačným ziskom!";
            tableInteractionScript.SetHighlightColor(new Color32(255, 0, 0, 255));
            StartCoroutine(SetInactive(hintText.gameObject, 3f));
            //Destroy(selectedAnswer.GetComponent<TabletInteraction>());  //destroys script 

            //play incorrect sound
            //turn highlight red?
            //destroy tabletinteractionscript?
            //set hinttext to "wrong" and make it dissappear after a while, fadeout using coroutine
        }
    }

    //dat do manazera
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
