using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Init : MonoBehaviour {

    private Transform icon;
    private GameObject infoMenuContainer;
    private Quaternion cameraRot;
    private Vector3 cameraPos;
    private float camPosZ;
    private GameObject[] icons;

    // Use this for initialization
    void Start()
    {
        icons = GameObject.FindGameObjectsWithTag("icon");
       
        // Get Info Menu Container and reposition out of view
        infoMenuContainer = GameObject.FindGameObjectWithTag("infoMenuContainer");
        //Debug.Log(infoMenuContainer);
        //infoMenuContainer.transform.position = new Vector3(60000, 60000, 60000);
    }

    //// Update is called once per frame
    void Update()
    {
    
    }
}
