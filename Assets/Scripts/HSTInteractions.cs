using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HSTInteractions : MonoBehaviour {
    GameObject sphere;
    GameObject hstModel;
    Quaternion hstStartRot;
    Quaternion sphereRot;

    private GameObject[] infoMenus;

    // Update is called once per frame
    void Update()
    {
        if (hstModel != null)
        {
            sphereRot = sphere.transform.rotation;
            hstModel.transform.rotation = Quaternion.Slerp(hstModel.transform.rotation, sphereRot, Time.deltaTime);
        }
    }

    public void HSTRotate()
    {
        //Get hst model
        hstModel = GameObject.FindGameObjectWithTag("hst");
        if (hstModel != null)
        {
            hstStartRot = hstModel.transform.rotation;
            sphere = this.gameObject;
            sphere.transform.rotation = Quaternion.Euler(hstStartRot.eulerAngles.x, hstStartRot.eulerAngles.y, hstStartRot.eulerAngles.z);
        }
    }

    public void TeleportToHST()
    {
        Debug.Log("Teleport");
    }
}
