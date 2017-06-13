using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleObjectsByDistance : MonoBehaviour {

    public GameObject object1;
    private Vector3 object1size;
    public Vector3 object1ScaleToSize;

    public GameObject object2;
    private Vector3 object2size;
    public Vector3 object2ScaleToSize;

    public GameObject object3;
    private Vector3 object3size;
    public Vector3 object3ScaleToSize;

   
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Body")
        {
            object1.transform.localScale = object1ScaleToSize;
            object2.transform.localScale = object2ScaleToSize;
            object3.transform.localScale = object3ScaleToSize;
        }   
    }
}
