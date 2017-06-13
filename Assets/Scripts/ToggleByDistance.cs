using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleByDistance : MonoBehaviour {

    public GameObject[] toggleObjects;

    private Vector3 thisPos;
    private Vector3 cameraPos;
    private float distanceFromObject;

    private void Start()
    {
        thisPos = this.transform.position;
    }

    private void Update()
    {

        cameraPos = Camera.main.transform.position;

        //Get Distance from obj
        distanceFromObject = Vector3.Distance(cameraPos, thisPos);

        if (distanceFromObject < 500)
        {
            for (int i = 0; i < toggleObjects.Length; i++)
            {
                toggleObjects[i].SetActive(true);
            } 
        }
        else
        {
            for (int i = 0; i < toggleObjects.Length; i++)
            {
                toggleObjects[i].SetActive(false);
            }
        }

    }
}
