using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
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
