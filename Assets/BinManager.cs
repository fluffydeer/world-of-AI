using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;
using TMPro;


//objekty sa daju vyberat a donekonecna vkladat
//-buz nich dat dole throwable skript
//-alebo ich vymazat a nahradit ich prefabom z rovnakym transformom bez skriptov
//predmety po priradeni do zleho kosa miznu
//slider sa na tabuli vobec nezvacuje - ani tam nie
//v hre sa da zaradit viac ako 8 objektov do kosov co je blbost
//bolo by fajn tam mat 10 predmetov na zaradenie
//otestovat to aby sa objekty zaratali len ak su vo vnutri kosa a nie ak sa dotknu vonka
//-toto kvoli tomu, ze je to vr sa ani neda moc tomu zabranit, jedine pomocou kodu

//repnut zaciatocnu tabulu na skore potom co 1. objekt je v kosi
//na konci znicit tuto tabulu po par sekundach a ukazat cestu dalej

public class BinManager : MonoBehaviour
{
    [SerializeField] GameObject scorebar;
    [SerializeField] GameObject slider;
    [SerializeField] int garbageAmount = 8;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] AudioClip correctAnswerSound;
    [SerializeField] AudioClip incorrectAnswerSound;
    private AudioSource binAudio;
    private float scorebarWidth;
    private float initialSliderWidth;
    private int correctAnswers = 0;

    void Start()
    {
        scorebarWidth = scorebar.transform.localScale.x; //0.7
        initialSliderWidth = slider.transform.localScale.x;    //0.0875
        binAudio = GetComponent<AudioSource>();
    }

    public void OnTriggerEnter(Collider other) {
        Debug.Log("other name: " + other.gameObject.name);
        Debug.Log("other tag: " + other.gameObject.tag);
        Debug.Log("bin: " + gameObject.tag);
        if (other.gameObject.CompareTag(gameObject.tag)){
            Debug.Log("dobre");
            //freeze position
            //len ci toto zastavi aby interactable fungovalo nadalej
            Rigidbody rb = other.GetComponent<Rigidbody>(); 
            rb.constraints = RigidbodyConstraints.FreezePosition;
            other.GetComponent<Interactable>().enabled = false;
            other.GetComponent<Throwable>().enabled = false;
            CorrectAnswer();
        }
        else
        {
            Debug.Log("zle");
            binAudio.PlayOneShot(incorrectAnswerSound, 1.0f);
            //find child called spawnpoint
            //assign this spawnpoint to "new position"
            Transform spawnPoint = other.transform.Find("SpawnPoint");
            Debug.Log(spawnPoint);
            transform.position = spawnPoint.position;
//            transform.position = new Vector3(0,0,+5f);

        }
    }


    //implementovat aj OnTriggerExit? 
    private void CorrectAnswer(){
        correctAnswers++;
        SetSliderWidth();
        SetSliderPosition();
        binAudio.PlayOneShot(correctAnswerSound, 1.0f);
        scoreText.text = $"\n \nRoztriedené\n \n \n {correctAnswers}/8";

        //demobilizovat danu vec aby zotrvala v tom bine -
        //freeze x,y,z? 
        //potom by netrebalo riesit OnTriggerExit
        IsDone();
    }

    //toto este prestudovat!!!
    private void SetSliderWidth(){
        float x = correctAnswers * initialSliderWidth;
        Vector3 scale = slider.transform.localScale;
        slider.transform.localScale = new Vector3(x, scale.y, scale.z);
        Debug.Log(slider.transform.localScale);
    }

    private void SetSliderPosition(){
        float x = scorebarWidth/2 -  (initialSliderWidth * correctAnswers)/2;
        Vector3 position = slider.transform.position;
        slider.transform.position = new Vector3(x, position.y, position.z);
        Debug.Log(slider.transform.position);
    }

    private void IsDone(){
        if(correctAnswers == garbageAmount){
            scoreText.text = "done";
            //co potom???
        }
    }
}
