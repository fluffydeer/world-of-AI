using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField] private Door door;
    private void OnTriggerEnter(Collider other) {
        Debug.Log("in trigger");
        door.OpenDoor();
    }

    private void OnTriggerExit(Collider other) {
        door.CloseDoor();
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("in collider");
        door.OpenDoor();
    }
}
