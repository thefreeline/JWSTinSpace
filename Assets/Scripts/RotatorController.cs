using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatorController : MonoBehaviour
{

    public GameObject sphere;
    public GameObject objectToRotate;
    Quaternion objectStartRot;
    Quaternion sphereRot;


    public void Start()
    {

    }

    // Update is called once per frame
    public void Update()
    {
        if (objectToRotate != null)
        {
            //sphereRot = sphere.transform.localRotation;
            objectToRotate.transform.rotation = Quaternion.Slerp(objectToRotate.transform.localRotation, sphereRot, Time.deltaTime);
        }
    }

    //public void rotateJWST()
    //{
    //    if (objectToRotate != null)
    //    {
    //        objectStartRot = objectToRotate.transform.rotation;
           
    //        sphere.transform.localRotation = Quaternion.Euler(objectStartRot.eulerAngles.x, objectStartRot.eulerAngles.y, objectStartRot.eulerAngles.z);
    //    }
    //}
}