using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using BarracudaSample;

public class Drawing : MonoBehaviour
{
    public static Drawing Instance;
    [SerializeField] RenderTexture texture;
    [SerializeField] MnistSample mnistSample;
    private List<GameObject> highlightedQuads = new List<GameObject>();

    public void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        //DontDestroOnLoad -> asi ked budeme mat restart v scene tak to bude treba implementovat
    }

    //texturu bude stacit dzrat len tu
    public void ExecuteMnist()
    {
        mnistSample.Execute(texture);
    }

    public void AddHighlightedQuad(GameObject quad)
    {
        highlightedQuads.Add(quad);
    }

    public void ClearTexture()
    {
        Debug.Log("clearing");
        foreach(GameObject quad in highlightedQuads)
        {
            quad.GetComponent<MeshRenderer>().material.color = new Color(0,0,0);
            //quad.GetComponent<Renderer>().material.color = Color.black;
            quad.GetComponent<BoxCollider>().enabled = true;
        }
        highlightedQuads.Clear();
    }
}
