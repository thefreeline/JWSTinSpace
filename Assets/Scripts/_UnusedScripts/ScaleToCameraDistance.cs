using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleToCameraDistance : MonoBehaviour {

    private float startingDistance;
    private Vector3 startingScale;
    private Vector3 scale;
    public float scaleFactor;
    public float logScale = 2;
    public float rescaleSpeed = 1;

    void Start()
    {
        //Get starting distance to scale objects by, this is the control.
        startingDistance = Vector3.Distance(Camera.main.transform.position, transform.position);
        //Get starting scale of the object, in the previous version it would have scaled everything to one.
        startingScale = transform.localScale;
    }

    void Update()
    {

        
        if (Camera.main)
        {
            //Figure out the current distance by finding the difference from starting distance
            float curDistance = Vector3.Distance(Camera.main.transform.position, transform.position) - startingDistance;
            // or was it the other way around, this code is untested!

            //Scale this object depending on distance away to the starting distance
            //Using logaritimic scale to gradually enlarge or reduce size of object
            scale = (Mathf.Log(logScale) * scaleFactor) * (startingScale * (1 + Mathf.Abs(curDistance)));

            //Debug.Log(scale);

            if (scale.x > startingScale.x)
            {
                transform.localScale = scale;
            }
            else if (scale.x <= startingScale.x)
            {
                transform.localScale = Vector3.Lerp(transform.localScale, startingScale, rescaleSpeed * Time.deltaTime);
            }

        }



    }
}
