using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightPath : MonoBehaviour {

    private float time;
    private GameObject obj;
	// Use this for initialization
	void Start () {
        
        obj = this.gameObject;
	}
	
	// Update is called once per frame
	void Update () {

        if (obj.activeSelf)
        {
            time += Time.deltaTime;
           
        } else
        {
           
        }
    }
}
