using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour {

    public Transform ObjectToLookAt;
    private Camera cam;

    private void Start()
    {
        cam = Camera.main;
    }
    public void LookAtObject()
    {
        cam.transform.LookAt(ObjectToLookAt);
        //transform.LookAt(ObjectToLookAt);
    }
}
