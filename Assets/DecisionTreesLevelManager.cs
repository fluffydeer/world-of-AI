using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecisionTreesLevelManager : MonoBehaviour
{
    public static DecisionTreesLevelManager Instance; 

    public void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);  //doesnt destroy GO when scene changes
        //todo: but ,aybe i want the scene to change? 

    }

    void Start()
    {
        
    }

    void Update()
    {
        
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
