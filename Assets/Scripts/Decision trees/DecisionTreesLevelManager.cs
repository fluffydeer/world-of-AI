using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecisionTreesLevelManager : MonoBehaviour
{
    public static DecisionTreesLevelManager Instance;
    public AudioClip successSound;
    public AudioClip failureSound;
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
    }

    public void Hide(GameObject hideMe)
    {
        hideMe.SetActive(false);
    }

    public void Show(GameObject showMe)
    {
        showMe.SetActive(true);
    }

    public void PlayCorrectAnswerSound()
    {
        audioSource.PlayOneShot(successSound);
    }

    public void PlayIncorrectAnswerSound()
    {
        audioSource.PlayOneShot(failureSound);
    }
}
