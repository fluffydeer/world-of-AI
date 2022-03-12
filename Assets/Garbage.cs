using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Garbage : MonoBehaviour
{
    [SerializeField] bool isInBin = false;
    [SerializeField] Vector3 initialPosition;

    public void Start()
    {
        //saving the global position
        initialPosition = transform.position;
    }

    public bool GetIsInBin()
    {
        return isInBin;
    }

    public void SetIsInBin(bool isInBin)
    {
        this.isInBin = isInBin;
    }

    public Vector3 GetInitialPosition()
    {
        return initialPosition;
    }
}
