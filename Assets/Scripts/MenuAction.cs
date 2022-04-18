using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Valve.VR;

public class MenuAction : MonoBehaviour
{
    public SteamVR_Action_Boolean switchToMenu;
    public SteamVR_Input_Sources handType;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("startingg");
        switchToMenu.AddOnStateDownListener(SwitchScene, handType);    
    }

    public void SwitchScene(SteamVR_Action_Boolean action, SteamVR_Input_Sources handType)
    {
        Debug.Log("pressing down");
        SceneManager.LoadScene(0);
    }
}
