using UnityEngine;
using System.Collections;

public class Orbiter : MonoBehaviour {

	public Transform targetPoint;
	public Vector3 axis;
	public float orbitSpeed;


	// Use this for initialization
	void Start () {
        if (targetPoint == null)
        {
            targetPoint = this.transform.parent;
        }
	}
	
	// Update is called once per frame
	void Update () {	
		transform.RotateAround (targetPoint.transform.position, Vector3.forward, orbitSpeed * Time.deltaTime);
	}
}
