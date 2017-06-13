using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleByRotation : MonoBehaviour {

    public GameObject[] enabledObjects;
    public GameObject[] disabledObjects;
    public GameObject[] toggleObjects;

    private GameObject lightPathObj;

    public GameObject checkVelocityOfObject;
    private Rigidbody rb;
    private Vector3 av;

    private Quaternion rot;
    private Quaternion curRot;
    private Quaternion prevRot;
    private int counter;

    private bool activeFlag;
    private bool rotating;

    public GameObject toggleButtonObj;

    private void Start()
    {
        rb = checkVelocityOfObject.GetComponent<Rigidbody>();
        av = rb.angularVelocity;
    }

    public void hideObj()
    {
        //Get the current state of the toggle switch
        activeFlag = toggleButtonObj.GetComponent<UnityEngine.UI.Toggle>().isOn;

        //If the toggle switch is on
        if (activeFlag == true)
        {
            //For each item assigned
            for (int i = 0; i < toggleObjects.Length; i++)
            {
                //If it is currently active
                //if (toggleObjects[i].activeSelf == true)
                //{
                    //Disable it
                    toggleObjects[i].SetActive(false);

                    int childCount = toggleObjects[i].transform.childCount;

                    for (int j = 0; j < childCount; j++)
                    {
                        lightPathObj = toggleObjects[i].transform.GetChild(j).gameObject;
                        lightPathObj.SetActive(false);
                    }
                //}
            }
        }
    }

    public void showObj()
    {
        StartCoroutine(checkRotation());
    }




    //This coroutine checks the  current state of the object rotation. While rotating, it returns null and checks again. 
    //When rotation is finished, it reactivates the objects which were toggle off. 
    IEnumerator checkRotation()
    {
        while (rotating == true)
        {
            yield return null;
        }

        //Get the current state of the toggle switch
        activeFlag = toggleButtonObj.GetComponent<UnityEngine.UI.Toggle>().isOn;

        //If the toggle switch is on
        if (activeFlag == true)
        {
            for (int i = 0; i < toggleObjects.Length; i++)
            {
                //if (toggleObjects[i].activeSelf == false)
                //{
                    toggleObjects[i].SetActive(true);

                    int childCount = toggleObjects[i].transform.childCount;

                    for (int j = 0; j < childCount; j++)
                    {
                        lightPathObj = toggleObjects[i].transform.GetChild(j).gameObject;
                        lightPathObj.SetActive(true);

                        yield return new WaitForSeconds(2);
                    }
                //}
            }
        }
    }


    private void Update()
    {
        curRot = checkVelocityOfObject.transform.rotation;
        prevRot = rot;
        rot = curRot;
   
        if(prevRot == rot)
        {
            rotating = false;
        } else
        {
            rotating = true;
        }
    }
}
