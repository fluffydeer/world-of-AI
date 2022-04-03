﻿using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class NeuralNetworkManager : MonoBehaviour
{
    public static NeuralNetworkManager Instance;
    [SerializeField] private AudioClip correctAnswerSound = null;
    [SerializeField] private AudioClip incorrectAnswerSound = null;
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
    }

    public void PlayCorrectAnswerSound()
    {
        audioSource.PlayOneShot(correctAnswerSound);
    }

    public void PlayIncorrectAnswerSound()
    {
        audioSource.PlayOneShot(incorrectAnswerSound);
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

}
