using UnityEngine;
using UnityEngine.SceneManagement;
using Valve.VR;

public class MenuAction : MonoBehaviour
{
    public SteamVR_Action_Boolean switchToMenu;
    public SteamVR_Input_Sources handType;

    void Start()
    {
        switchToMenu.AddOnStateDownListener(SwitchScene, handType);    
    }

    public void SwitchScene(SteamVR_Action_Boolean action, SteamVR_Input_Sources handType)
    {
        SceneManager.LoadScene(0);
    }
}
