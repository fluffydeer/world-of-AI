using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SortTrainingData : MonoBehaviour
{
    
    [SerializeField] 
    private Image image;
    
    [SerializeField] 
    //images are sorted in asc order 
    private List<Sprite> sprites;

    void Start()
    {
        ShowNextSprite();
    }

    public void SetSprite(int i){
        image.sprite = sprites[i];
    }

    public void ShowNextSprite(){
        if(sprites.Count > 0){
            int randomIndex = Random.Range(0, sprites.Count);
            SetSprite(randomIndex);
            sprites.RemoveAt(randomIndex);
        }else{
            TrainingOver();
        }
    }

    private void TrainingOver(){
        Debug.Log("Training is over");
        //show ui message that its done and he can continue journey
        //remove triggers from keyboards? so user cant fire shownextsprite all the time
        //or a variable checking is traning is really over
    }
}
