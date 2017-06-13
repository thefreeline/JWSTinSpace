using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JWSTInteractions : MonoBehaviour {

    GameObject sphere;
    GameObject jwstModel;
    Quaternion jwstStartRot;
    Quaternion sphereRot;

    private GameObject[] infoMenus;

    // Update is called once per frame
    public void Update()
    {
        if (jwstModel != null)
        {
            sphereRot = sphere.transform.rotation;
            jwstModel.transform.rotation = Quaternion.Slerp(jwstModel.transform.rotation, sphereRot, Time.deltaTime);
        }
    }

    public void rotateJWST()
    {
        //Get jwst model
        jwstModel = GameObject.FindGameObjectWithTag("jwst");
        if (jwstModel != null)
        {
            jwstStartRot = jwstModel.transform.rotation;
            sphere = this.gameObject;
            sphere.transform.rotation = Quaternion.Euler(jwstStartRot.eulerAngles.x, jwstStartRot.eulerAngles.y, jwstStartRot.eulerAngles.z);
        }
    }
}
