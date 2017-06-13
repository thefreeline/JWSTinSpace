using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JWSTAnimate : MonoBehaviour {

    GameObject jwstModel;
    Animation jwstAnimation;

	// Use this for initialization
	void Start () {
        
        jwstModel = GameObject.FindGameObjectWithTag("jwst");
        jwstAnimation =  jwstModel.GetComponent<Animation>();
        jwstAnimation["JWST Deploy"].speed = 0.10f;
        jwstAnimation.Play("JWST Deploy");

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
