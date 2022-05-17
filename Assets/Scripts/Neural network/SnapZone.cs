using System.Collections;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class SnapZone : MonoBehaviour
{
    [SerializeField] private Animator anim = null;
    [SerializeField] private GameObject outputText = null;
    [SerializeField] private GameObject teleportArea = null;
    [SerializeField] private GameObject CD_in_driver = null;
    [SerializeField] private Renderer interactableCD = null;
    [SerializeField] private ParticleSystem electricityParticleSystem;

    private readonly string closeCDDrive = "Close_CD_Drive";

    public bool turnOn = false;
    private bool CDDriverOpen = true;
    private void Update() {
        //v editore mozem nastavit turnOn
        if(turnOn && CDDriverOpen){
            CDDriverOpen = false;
            HandleCDInDriver();
        }
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("CD")){
            if (CDDriverOpen){
                CDDriverOpen = false;
                HandleCDInDriver();     //toto by sa malo spustat z ineho skriptu
            }
        }
    }
    public IEnumerator ShowWithDelay(GameObject something)
    {
        yield return new WaitForSeconds(2.0f);
        something.SetActive(true);
    }

    private void HandleCDInDriver() {
        CD_in_driver.SetActive(true);
        NeuralNetworkManager.Instance.PlayCDPlayerClosingSound();
        Color c = new Color(0, 0, 0, 0);
        interactableCD.material.color = c;

        //animate the cd player
        Debug.Log("animating");
        anim.Play(closeCDDrive, 0, 0.0f);

        StartCoroutine(NeuralNetworkManager.Instance.ShowWithDelay(outputText));
        electricityParticleSystem.Play();

        teleportArea.GetComponent<TeleportArea>().locked = false;
    }
}
