using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecisionTreesLevelManager : MonoBehaviour
{
    public static DecisionTreesLevelManager Instance;
    public AudioClip successSound;
    public AudioClip failureSound;

    public void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        //DontDestroyOnLoad(gameObject);  //doesnt destroy GO when scene changes
        //todo: but maybe i want the scene to change? 
    }

    public void Hide(GameObject hideMe)
    {
        hideMe.SetActive(false);
    }

    public void Show(GameObject showMe)
    {
        showMe.SetActive(true);
    }

}
