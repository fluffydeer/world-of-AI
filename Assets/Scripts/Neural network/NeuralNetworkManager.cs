using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class NeuralNetworkManager : MonoBehaviour
{
    public static NeuralNetworkManager Instance;
    [SerializeField] private Fading fadingScript = null;
    [SerializeField] private AudioClip correctAnswerSound = null;
    [SerializeField] private AudioClip incorrectAnswerSound = null;
    [SerializeField] private AudioClip cdPlayerClosing = null;

    [SerializeField] private List<GameObject> teleports = null;
    [SerializeField] private GameObject setOfCrates = null;
    private AudioSource audioSource;

    public void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        audioSource = GetComponent<AudioSource>();
        fadingScript = GetComponent<Fading>();
    }

    public void PlayCorrectAnswerSound()
    {
        audioSource.PlayOneShot(correctAnswerSound);
    }

    public void PlayIncorrectAnswerSound()
    {
        audioSource.PlayOneShot(incorrectAnswerSound);
    }

    public void PlayCDPlayerClosingSound()
    {
        audioSource.PlayOneShot(cdPlayerClosing);
    }

    public void SetUpDrawing()
    {
        SetActive(teleports);
        SetInteractableAndThrowableToChildren(setOfCrates);
    }

    public void SetActive(List<GameObject> listGameObjects)
    {
        foreach (GameObject go in listGameObjects)
        {
            go.SetActive(true);
        }
    }

    public void SetInteractableAndThrowableToChildren(GameObject parentGameObject)
    {
        //Transform supplies all children, box.gameObject is a child 
        foreach(Transform box in parentGameObject.transform)
        {
            box.gameObject.GetComponent<Interactable>().enabled = true;
            box.gameObject.GetComponent<Throwable>().enabled = true;
        }
    }

    public void FadeInGameObject(GameObject something){
        Debug.Log("fadinggg");
        StartCoroutine(fadingScript.FadeIn(something));
    }

    

    public IEnumerator ShowWithDelay(GameObject something){
        yield return new WaitForSeconds(4.0f);
        something.SetActive(true);
    }
}
