using UnityEngine;
using System.Collections;

public class PlayerControllerPlaneMode : MonoBehaviour {

	private Vector3 targetPos;
	private Rigidbody rb;

	// Use this for initialization
	void Start () {
		//Debug.Log("plane script added to: " + gameObject.name);
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		
		transform.position += transform.forward * Time.deltaTime * 10f;

		transform.Rotate ( Input.GetAxis("Vertical"), 0.0f, -Input.GetAxis("Horizontal")*2);


		if (Input.GetMouseButtonDown (0)) {
			RaycastHit hitInfo = new RaycastHit();
			bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);
			if (hit && hitInfo.transform.gameObject.tag == "star") 
			{
				targetPos = hitInfo.transform.position;
				rb.position = new Vector3(targetPos.x,targetPos.y,targetPos.z-10);
				rb.velocity = new Vector3(0,0,0);
			}
		}

	}
}
