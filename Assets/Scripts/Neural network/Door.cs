using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Animator myDoor;
    [SerializeField] private bool openDoor = false;
    [SerializeField] private bool closeDoor = false;
    void Update()
    {
        //comment ot
        if(openDoor){
            openDoor = false;
            OpenDoor();
        }

        if(closeDoor){
            closeDoor = false;
            CloseDoor();
        }
    }

    public void OpenDoor(){
        myDoor.Play("DoorOpen", 0, 0.0f);
    }

    public void CloseDoor(){
        myDoor.Play("DoorClose", 0, 0.0f);
    }
}
