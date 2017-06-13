using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleToObject : MonoBehaviour {

    private Vector3 startingScale;
    public GameObject scaleObject;
    public float scaleFactor = 1.1f;
    public float scaleSpeed = 100;
    private Vector3 scaleToObjStartingScale;
    private Vector3 scaleToObjCurrentScale;
    private Component halo;

    // Use this for initialization
    void Start()
    {
        halo = this.GetComponent("Halo");

        //Get object starting scale
        startingScale = transform.localScale;

        //Get scale of object to which halo will be relatively scaled
        scaleToObjStartingScale = scaleObject.transform.localScale;

    }

    // Update is called once per frame
    void Update()
    {
        scaleToObjCurrentScale = scaleObject.transform.localScale;

        //transform.localScale = Vector3.Lerp(transform.localScale, scaleToObjCurrentScale * scaleFactor, scaleSpeed * Time.deltaTime);
    }

}
