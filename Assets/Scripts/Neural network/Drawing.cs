using System.Collections.Generic;
using UnityEngine;
using BarracudaSample;

public class Drawing : MonoBehaviour
{
    public static Drawing Instance;
    [SerializeField] RenderTexture texture = null;
    [SerializeField] MnistWrapper mnistSample = null;
    private List<GameObject> highlightedQuads = new List<GameObject>();

    public void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    //texturu bude stacit drzat len tu
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
        foreach(GameObject quad in highlightedQuads)
        {
            quad.GetComponent<MeshRenderer>().material.color = new Color(0,0,0);
            quad.GetComponent<BoxCollider>().enabled = true;
        }
        highlightedQuads.Clear();
    }
}
