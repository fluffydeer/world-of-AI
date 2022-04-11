using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Valve.VR.InteractionSystem;


public class SortTrainingData : MonoBehaviour
{
    [SerializeField] private Image image = null;
    [SerializeField] private GameObject finalText = null;
    [SerializeField] private GameObject CD = null;
    [SerializeField] private TeleportArea teleportArea = null; 
    [SerializeField] private List<Sprite> sprites = null;       //images are sorted in asc order 


    private List<int> availableIndices = new List<int>();
    private int randomIndex;
    private bool trainingIsDone = false;
    
    void Start()
    {
        for(int i = 0; i < sprites.Count; i++)
        {
            availableIndices.Add(i);
        }
        ShowNextSprite();
    }

    public void SetSpriteImage(int i){
        image.sprite = sprites[i];
    }

    public void CheckAnswer(TMP_Text text)
    {
        if (!trainingIsDone)
        {
            if (int.Parse(text.text).Equals(availableIndices[randomIndex]))
            {
                CorrectAnswer();
            }
            else
            {
                IncorrectAswer();
            }
        }
    }

    private void CorrectAnswer()
    {
        NeuralNetworkManager.Instance.PlayCorrectAnswerSound();
        availableIndices.RemoveAt(randomIndex);
        ShowNextSprite();
    }

    private void IncorrectAswer()
    {
        NeuralNetworkManager.Instance.PlayIncorrectAnswerSound();
    }

    private void ShowNextSprite(){
        if(availableIndices.Count > 0){
            randomIndex = Random.Range(0, availableIndices.Count);
            SetSpriteImage(availableIndices[randomIndex]);
        }else{
            TrainingOver();
        }
    }

    private void TrainingOver(){
        trainingIsDone = true;
        Destroy(image);     //removing graphical component so we can add text 
        NeuralNetworkManager.Instance.SetUpDrawing();
        CD.transform.parent.gameObject.SetActive(true);
        NeuralNetworkManager.Instance.FadeInGameObject(CD);
        finalText.SetActive(true);
        teleportArea.locked = false;
    }
}