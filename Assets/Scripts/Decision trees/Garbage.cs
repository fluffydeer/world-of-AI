using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Garbage : MonoBehaviour
{
    [SerializeField] bool isInBin = false;
    [SerializeField] Vector3 initialPosition;
    [SerializeField] GameObject staticObject;

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

    public void RemoveTrash()
    {
        staticObject.SetActive(true);
        Destroy(gameObject);
    }
}
