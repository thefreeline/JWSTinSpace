using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerToggle : MonoBehaviour {

    public GameObject[] toggleObjects;

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Body")
        {
            for (int i = 0; i < toggleObjects.Length; i++)
            {
                toggleObjects[i].SetActive(true);
            }
        } 
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "Body")
        {
            for (int i = 0; i < toggleObjects.Length; i++)
            {
                toggleObjects[i].SetActive(false);
            }
        }
    }
}
