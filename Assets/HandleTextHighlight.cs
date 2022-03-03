using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//mozem to premenovat na handletabletext
public class HandleTextHighlight : MonoBehaviour
{    private void OnTriggerEnter(Collider other) {
        if(this.name == "OKButton"){
            Debug.Log("OKBUTTON");
        }
        Debug.Log(this.name + " was entered");
        Debug.Log(other.name);
    }
}
