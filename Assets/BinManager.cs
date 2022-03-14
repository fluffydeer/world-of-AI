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
        scorebarWidth = scorebar.transform.localScale.x; //0.7
        //Debug.Log("scorebarwidth " + scorebarWidth);
        initialSliderWidth = slider.transform.localScale.x;    //0.0875
        //Debug.Log("initial slider width " + initialSliderWidth);
        binAudio = GetComponent<AudioSource>();
    }

    
    public void OnTriggerEnter(Collider other) {
        //Debug.Log("other name: " + other.gameObject.name);
        //Debug.Log("other tag: " + other.gameObject.tag);
        //Debug.Log("bin: " + gameObject.tag);
        if (other.gameObject.CompareTag(gameObject.tag)){
            other.transform.parent = null;
            StartCoroutine(RemoveThrowable(other.gameObject));
            Garbage garbageScript = other.GetComponent<Garbage>();
            if (!garbageScript.GetIsInBin())
            {
                garbageScript.SetIsInBin(true);
                CorrectAnswer();
            }
        }
        else
        {
            //Debug.Log("zle");
            binAudio.PlayOneShot(incorrectAnswerSound, 1.0f);
            //find child called spawnpoint
            //assign this spawnpoint to "new position"
            //Transform spawnPoint = other.transform.Find("SpawnPoint");
            //Debug.Log(spawnPoint);
            //checknut local position
            //Debug.Log("spawn point" + spawnPoint.position);
            //other.transform.position = spawnPoint.position;
            Garbage garbageScript = other.GetComponent<Garbage>();

            other.transform.position = garbageScript.GetInitialPosition();
            //Debug.Log("garbage" + other.transform.position);
        }
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
        //Debug.Log("correct answers " + x);
        Vector3 scale = slider.transform.localScale;
        slider.transform.localScale = new Vector3(x, scale.y, scale.z);
        //Debug.Log("slider localScale" + slider.transform.localScale.ToString("F4"));
        SetSliderPosition();
    }

    private void SetSliderPosition(){
        float x = scorebarWidth/2 -  (initialSliderWidth * correctAnswers)/2;
        Vector3 position = slider.transform.localPosition;
        //Debug.Log("previous slider position" + slider.transform.localPosition.ToString("F4"));
        slider.transform.localPosition = new Vector3(x, position.y, position.z);
        //Debug.Log("slider position" + slider.transform.localPosition.ToString("F4"));
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

    public IEnumerator RemoveThrowable(GameObject other)
    {
        yield return new WaitForSeconds(1f);
        Destroy(other.GetComponent<Throwable>());   //aby s tym nemohol hybat
    }
}
