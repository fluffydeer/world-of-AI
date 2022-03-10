using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;
using TMPro;

public class BinManager : MonoBehaviour
{
    [SerializeField] GameObject scorebar;
    [SerializeField] GameObject slider;
    [SerializeField] int garbageAmount;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] AudioClip correctAnswerSound;
    [SerializeField] AudioClip incorrectAnswerSound;
    private AudioSource playerAudio;
    private float scorebarWidth;
    private float initialSliderWidth;
    private int correctAnswers = 0;

    void Start()
    {
        scorebarWidth = scorebar.transform.localScale.x; //0.7
        initialSliderWidth = slider.transform.localScale.x;    //0.0875
        playerAudio = GetComponent<AudioSource>();
    }
 
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other) {
        Debug.Log("other name: " + other.gameObject.name);
        Debug.Log("other tag: " + other.gameObject.tag);
        Debug.Log("bin: " + gameObject.tag);
        if (other.gameObject.CompareTag(gameObject.tag)){
            Debug.Log("dobre");
            CorrectAnswer();
        }
        else
        {
            Debug.Log("zle");
            Transform transform = other.gameObject.transform;
            transform.position = new Vector3(0,0,+5f);
            playerAudio.PlayOneShot(incorrectAnswerSound, 1.0f);
        }
    }


    //implementovat aj OnTriggerExit? 
    private void CorrectAnswer(){
        correctAnswers++;
        SetSliderWidth();
        SetSliderPosition();
        playerAudio.PlayOneShot(correctAnswerSound, 1.0f);
        scoreText.text = "heh";
        scoreText.text = $"\n \nRoztriedené\n \n \n {correctAnswers}/8";

        //demobilizovat danu vec aby zotrvala v tom bine -
        //freeze x,y,z? 
        //potom by netrebalo riesit OnTriggerExit
        IsDone();
    }

    private void SetSliderWidth(){
        float x = correctAnswers * initialSliderWidth;
        Vector3 scale = slider.transform.localScale;
        slider.transform.localScale = new Vector3(x, scale.y, scale.z);
    }

    private void SetSliderPosition(){
        float x = scorebarWidth/2 -  (initialSliderWidth * correctAnswers)/2;
        Vector3 position = slider.transform.position;
        slider.transform.position = new Vector3(x, position.y, position.z);
    }

    private void IsDone(){
        if(correctAnswers == garbageAmount){
            scoreText.text = "done";

        }
    }
}
