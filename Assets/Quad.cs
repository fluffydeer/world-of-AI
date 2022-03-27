using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quad : MonoBehaviour
{   
    void Start()
    {
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        Debug.Log("trigger: " + other.name);
        //if(other.name.Equals("finger_index_2_r")){  //toto tahat z playera?? aby to nebolo hard coded
        if(other.name.Equals("Pencil")){  //toto tahat z playera?? aby to nebolo hard coded
            Debug.Log("kreslim ukazovakom");
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
