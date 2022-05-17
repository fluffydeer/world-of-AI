using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RadialProgressBar : MonoBehaviour
{
    [SerializeField]
    private int output;       //of the neural network - number from 0-9
    private Image circle;
    
    void Start()
    {
        circle = GetComponent<Image>();
    }

    public void SetProgressBar(int output, float probability)
    {
        if(output == this.output)
        {
            //Debug.Log("Value: " + output + " probability: " + probability);
            circle.fillAmount = probability;
        }
    }
}
