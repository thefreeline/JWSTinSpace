using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleToCameraDistancev2 : MonoBehaviour {
    

    private Vector3 startSize;
    public Vector3 targetSize;
    private Vector3 updatedSize;
    private Vector3 startPosCamera;
    private Vector3 startPosObj;
    private float currentDistanceFromStart;
    private float currentDistanceFromObj;
    private Vector3 cameraPos;
    private float distanceToObj;
    private float scale;
    private string scaleDirection;
    public float rescaleSpeed = 10;
    public float rescaleModifier = 1;


    void Start()
    {

        //Get the starting size of the object
        startSize = transform.localScale;

        //Get the main camera starting position
        startPosCamera = Camera.main.transform.position;

        //Get the object position
        startPosObj = transform.position;

        //Find the distance between the camera position and the object
        distanceToObj = Vector3.Distance(startPosCamera, startPosObj);
        
        //Determine if we are enlarging or reducing the object
        if (startSize.x > targetSize.x)
        {
            scaleDirection = "reduce";
        } else if (startSize.x <= targetSize.x)
        {
            scaleDirection = "enlarge";
        }

    }

    void Update()
    {
        if (Camera.main)
        {
            //Get camera position
            cameraPos = Camera.main.transform.position;

            //Get the current distance from starting position
            currentDistanceFromStart = Vector3.Distance(cameraPos, startPosCamera);

            //Get the current distance from the target object
            currentDistanceFromObj = Vector3.Distance(cameraPos, startPosObj);

            //Only perform operation if we are moving toward object from where we started
            if (currentDistanceFromObj < distanceToObj)
            {
//Debug.Log("Current Distance from OBJECT is LESS THAN than distance to object");
                //Only perform operation if we are moving toward the object but have not passed it
                if (currentDistanceFromStart < distanceToObj)
                {
    //Debug.Log("Current Distance from OBJECT is LESS THAN than distance to object");
                    //Determine the scale at which to resize the object
                    scale = currentDistanceFromStart / distanceToObj;

                    //Calculate the updated target size of the object
                    updatedSize = targetSize * scale;

                    //Only perform the operation if we are enlarging the object
                    if (scaleDirection == "enlarge")
                    {
       //Debug.Log("--ENLARGING--");
                        if (updatedSize.x > startSize.x)
                        {
Debug.Log("1");
                            //If we are moving toward the object, but have not passed it, enlarge the object to the target size
                            transform.localScale = Vector3.Lerp(transform.localScale, updatedSize, rescaleSpeed * Time.deltaTime);
                        }
                    }
                    else if(scaleDirection == "reduce")
                    {
                        //Debug.Log("--REDUCING--");
Debug.Log("2");
                        //If we are moving toward the object, but have not passed it, enlarge the object to the target size
                        transform.localScale = Vector3.Lerp(transform.localScale, startSize, rescaleSpeed * Time.deltaTime);
                    }
                }
            }

            //Only perform operation if we are moving PAST the object
            if (currentDistanceFromStart > distanceToObj)
            {
//Debug.Log("Current Distance from start is Greater than distance to object");
                if(scaleDirection == "enlarge")
                {
                    //Determine the scale at which to resize the object
                    scale = 1 - (currentDistanceFromObj / distanceToObj);

                    //Calculate the updated target size of the object
                    updatedSize = targetSize * scale;

                    if (updatedSize.x > startSize.x)
                    {
Debug.Log("3");
                        transform.localScale = Vector3.Lerp(transform.localScale, updatedSize, rescaleSpeed * Time.deltaTime);
                    }
                }
                else if (scaleDirection == "reduce")
                {
                    //Determine the scale at which to resize the object
                    scale = 1 - (currentDistanceFromObj / distanceToObj);

                    //Calculate the updated target size of the object
                    updatedSize = targetSize * scale;

                    if (updatedSize.x < targetSize.x)
                    {
                        if(scale > 0 && updatedSize.x > startSize.x)
                        {
Debug.Log("4");
Debug.Log(scale);
Debug.Log(updatedSize);
                            transform.localScale = Vector3.Lerp(transform.localScale, updatedSize, rescaleSpeed * Time.deltaTime);
                        } else if (scale > 0 && updatedSize.x < startSize.x)
                        {
                            updatedSize = startSize * scale;
                            transform.localScale = Vector3.Lerp(transform.localScale, updatedSize, rescaleSpeed * Time.deltaTime);
                        }
                        else
                        {
Debug.Log("5");
                            transform.localScale = Vector3.Lerp(transform.localScale, targetSize, rescaleSpeed * Time.deltaTime);
                        }
                    }
                }
            }
            

            //Debug.Log("Reducing");
            //Debug.Log("Distance to Object (Start)" + distanceToObj);
            //Debug.Log("Current Distance from Object: " + currentDistanceFromObj);
            //Debug.Log("Scale:" + scale);
            //Debug.Log("CurrDistFromStart: " + currentDistanceFromStart +  "  /  " + "DistToObj: " + distanceToObj +  "  =  " + currentDistanceFromStart/ distanceToObj);
            //Debug.Log("DistToObj: " + distanceToObj +  "  /  " +  "CurrDistFromStart: " + currentDistanceFromStart +  "  =  " + distanceToObj/ currentDistanceFromStart);
            //Debug.Log(1 - (scale - 1));
            //Debug.Log("recale Modifier: " + rescaleModifier);
            // Debug.Log(updatedSize);
        }
    }
}
