using UnityEngine;
using System.Collections;
using UnityEngine.VR;

public class VR : MonoBehaviour {

	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		//toggle the VR view
		if (Input.GetKeyDown(KeyCode.V))
		{
			VRSettings.enabled = !VRSettings.enabled;
			Debug.Log("Changed VRSettings.enabled to:"+VRSettings.enabled);
		}
	}
}
