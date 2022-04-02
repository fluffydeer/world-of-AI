using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SortTrainingData : MonoBehaviour
{
    
    [SerializeField] 
    private Image image;
    
    [SerializeField] 
    private List<Sprite> sprites;

    void Start()
    {
        SetSprite(6);
    }

    void Update()
    {
        
    }

    public void SetSprite(int i){
        image.sprite = sprites[i];
    }
}
