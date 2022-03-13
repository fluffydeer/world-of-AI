//======= Copyright (c) Valve Corporation, All rights reserved. ===============

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System;

namespace Valve.VR.InteractionSystem.Sample
{
    public class ButtonEffect : MonoBehaviour
    {
        [SerializeField] GameObject toShow;
        [SerializeField] GameObject[] toHide;
        public void OnButtonDown(Hand fromHand)
        {
            //ColorSelf(Color.cyan);
            fromHand.TriggerHapticPulse(1000);
            toShow.SetActive(true);
            foreach(GameObject item in toHide){
                item.SetActive(false);
            }
        }

        public void OnButtonUp(Hand fromHand)
        {
            //ColorSelf(Color.white);
        }

        private void ColorSelf(Color newColor)
        {
            Renderer[] renderers = this.GetComponentsInChildren<Renderer>();
            for (int rendererIndex = 0; rendererIndex < renderers.Length; rendererIndex++)
            {
                renderers[rendererIndex].material.color = newColor;
            }
        }
    }
}