using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleUpToCameraDistance : MonoBehaviour {

    private float startingDistance;
    private Vector3 startingScale;
    private Vector3 scale;
    public float scaleFactor;
    public float logScale = 2;
    public float rescaleSpeed = 1;
    public Vector3 startingSize;
    public Vector3 targetSize;

    void Start()
    {
        //Get starting distance to scale objects by, this is the control.
        startingDistance = Vector3.Distance(Camera.main.transform.position, transform.position);
        //Get starting scale of the object, in the previous version it would have scaled everything to one.
        //transform.localScale = Vector3.Lerp(transform.localScale, startingSize, rescaleSpeed * Time.deltaTime);
    }

    void Update()
    {
        if (Camera.main)
        {
            //Figure out the current distance by finding the difference from starting object
            float curDistance = Vector3.Distance(Camera.main.transform.position, transform.position);

            //Scale this object depending on distance away to the starting distance
            //Using logaritimic scale to gradually enlarge or reduce size of object
            //scale = (Mathf.Log(logScale) * scaleFactor) * (startingScale * (1 + Mathf.Abs(curDistance)));

            Vector3 newScale = transform.localScale = new Vector3(1.0f / (1 + scale.x), 1.0f / (1 + scale.y), 1.0f / (1 + scale.z));

            transform.localScale = Vector3.Lerp(transform.localScale, newScale, rescaleSpeed * Time.deltaTime);

            //transform.localScale = Vector3.Lerp(transform.localScale, targetSize, rescaleSpeed * Time.deltaTime); 
        }
    }
}
