using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingArea : MonoBehaviour
{
    public static TestingArea Instance;
    [SerializeField]
    private List<GameObject> panels;
    [SerializeField]
    private GameObject teleport;
    private int correctAsnwerCount = 0;

    public void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    public void AddCorrectAnswerToCount()
    {
        correctAsnwerCount++;
        if(panels.Count == correctAsnwerCount)
        {
            //hide other stuff
            float time = 3f;
            float offset = -4f;
            float y = transform.position.y + offset;
            foreach(GameObject go in panels)
            {
                iTween.MoveTo(go, iTween.Hash("y", y, "easeType", iTween.EaseType.easeInOutSine, "time", time));
            }
            if (NeuralNetworkManager.Instance)
            {
                float x = teleport.transform.position.x + 3;
                iTween.MoveTo(teleport, iTween.Hash("x", x, "easeType", iTween.EaseType.easeInOutSine, "time", 5f));
            }
            else
            {
                //show teleport to next level
                teleport.SetActive(true);
            }
        }
    }
}
