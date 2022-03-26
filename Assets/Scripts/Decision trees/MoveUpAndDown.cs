using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUpAndDown : MonoBehaviour
{
    [SerializeField] float time = 5f;
    [SerializeField] float offset = 2f;

    void Start()
    {
        float y = transform.position.y + offset;
		iTween.MoveTo(gameObject, iTween.Hash("y", y, "easeType", iTween.EaseType.easeInOutSine , "loopType", "pingPong", "time", time));
    }
}
