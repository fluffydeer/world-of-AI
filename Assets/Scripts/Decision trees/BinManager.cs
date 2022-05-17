using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;
using TMPro;

public class BinManager : MonoBehaviour
{
    [SerializeField] GameObject scorebar;
    [SerializeField] GameObject slider;
    [SerializeField] int garbageAmount = 8;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] AudioClip correctAnswerSound;
    [SerializeField] AudioClip incorrectAnswerSound;
    [SerializeField] GameObject branch3;
    [SerializeField] GameObject sign;
    [SerializeField] GameObject sign2;
    [SerializeField] GameObject signText;
    [SerializeField] GameObject scorebar2;
    [SerializeField] GameObject slider2;

    private AudioSource binAudio;
    private float scorebarWidth;
    private float initialSliderWidth;
    private static int correctAnswers = 0;

    public void Start()
    {
        scorebarWidth = scorebar.transform.localScale.x; 
        initialSliderWidth = slider.transform.localScale.x;   
        binAudio = GetComponent<AudioSource>();
    }
    
    public void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag(gameObject.tag)){
            Garbage garbageScript = other.GetComponent<Garbage>();
            if (!garbageScript.GetIsInBin())
            {
                garbageScript.RemoveTrash();
                CorrectAnswer();
            }
        }
        else
        {
            WrongAnswer(other);
        }
    }

    //toto som zmenila
    private void WrongAnswer(Collider other){
        binAudio.PlayOneShot(incorrectAnswerSound, 1.0f);
        Garbage garbageScript = other.GetComponent<Garbage>();
        other.transform.position = garbageScript.GetInitialPosition();
    }

    private void CorrectAnswer(){
        correctAnswers++;
        SetSliderWidth();
        binAudio.PlayOneShot(correctAnswerSound, 1.0f);
        scoreText.text = $"\n \nRoztriedené\n \n \n {correctAnswers}/8";

        if(correctAnswers == 1)
        {
            signText.SetActive(true);
            scorebar2.SetActive(true);
            slider2.SetActive(true);
        }
        IsDone();
    }

    private void SetSliderWidth(){
        float x = correctAnswers * initialSliderWidth;
        Vector3 scale = slider.transform.localScale;
        slider.transform.localScale = new Vector3(x, scale.y, scale.z);
        SetSliderPosition();
    }

    private void SetSliderPosition(){
        float x = scorebarWidth/2 -  (initialSliderWidth * correctAnswers)/2;
        Vector3 position = slider.transform.localPosition;
        slider.transform.localPosition = new Vector3(x, position.y, position.z);
    }

    private void IsDone(){
        if(correctAnswers >= garbageAmount){
            scoreText.text = $"\n \nHotovo. Poďme ďalej!\n \n \n {correctAnswers}/8";
            StartCoroutine(NextLevel(4f));
        }
    }

    public IEnumerator NextLevel(float time)
    {
        yield return new WaitForSeconds(time);
        branch3.SetActive(true);
        sign.SetActive(false);
        sign2.SetActive(false);
    }
}
