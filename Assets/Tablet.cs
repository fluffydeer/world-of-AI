using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//mozem to premenovat na handletabletext
public class Tablet : MonoBehaviour
{    private void OnTriggerEnter(Collider other) {
        if(this.name == "OKButton"){
            Debug.Log("OKBUTTON");
        }
        if(gameObject.CompareTag("TabletData")){
            Debug.Log("TABLETDATA");
        }
        Debug.Log(this.name + " was entered");
        Debug.Log(other.name);
    }
}
