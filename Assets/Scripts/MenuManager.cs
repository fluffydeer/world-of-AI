using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;
    public List<GameObject> toSetActive;

    void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    private void Start()
    {
        SetActive(toSetActive);

    }

    //so I can set TeleportPoint active
    public void SetActive(List<GameObject> listOfObjects)
    {
        Debug.Log("set actie");
        foreach(GameObject go in toSetActive)
        {
            go.SetActive(true);
        }
    }

}
