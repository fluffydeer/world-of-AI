using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quad : MonoBehaviour
{   
    private void OnTriggerEnter(Collider other) {
        if(other.name.Equals("Pencil")){  //toto tahat z playera?? aby to nebolo hard coded
            gameObject.GetComponent<Renderer>().material.color = new Color(0, 204, 102);
            gameObject.GetComponent<Renderer>().material.color = new Color(255, 255, 255);

            Drawing.Instance.AddHighlightedQuad(gameObject);
            Drawing.Instance.ExecuteMnist();
            GetComponent<BoxCollider>().enabled = false;
            //nasledne znicit skript? disable collider? aby to nebralo cpu
            //Destroy(this);  //destroys the script on the gameobject
        }
    }
}
