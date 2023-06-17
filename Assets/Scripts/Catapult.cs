using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[SerializeField] GameObject DisplayPanelForRigidbody
[SerializeField] Text TextForNoRigidbody
public class Catapult : MonoBehaviour
{

    
    // Start is called before the first frame update
    void Start()
    {
        TextForNoRigidbody.setActive(False);
        DisplayPanelForRigidbody.setActive(False);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter (Collider other)
    {
        if(other.GetComponent<Rigidbody>())
        {
            DisplayPanelForRigidbody.setActive(True);
        }
        else
        {
            TextForNoRigidbody.text = "Object to be launched must have a Rigidbody component!"
            Debug.Log("Error: game object - " + TextForNoRigidbody.GameObject.name + " has no Rigidbody component!"
            TextForNoRigidbody.setActive(True);
        }
        
    }

    void OnTriggerExit (Collider other)
    {
        TextForNoRigidbody.setActive(False);
        DisplayPanelForRigidbody.setActive(False);

    }
}
