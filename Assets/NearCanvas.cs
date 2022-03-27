using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class NearCanvas : MonoBehaviour
{
    [SerializeField] SteamVR_Skeleton_Poser skeletonPoser;
    [SerializeField] GameObject rightHand;

    private void OnTriggerEnter(Collider other)
    {
        //rightHand.skeleton.BlendToPoser(SteamVR_Skeleton_Poser);
    }
}
