using UnityEngine;
using System.Collections;

public class Orbiter : MonoBehaviour {

	public Transform targetPoint;
	public Vector3 axis;
	public float orbitSpeed;


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		
		transform.RotateAround (targetPoint.transform.position, Vector3.up, orbitSpeed * Time.deltaTime);
	}
}
