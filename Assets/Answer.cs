using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Answer : MonoBehaviour
{
    [SerializeField] private GameObject staticGameObject;

    public void Destroy()
    {
        staticGameObject.SetActive(true);
        Destroy(gameObject);
    }
}
