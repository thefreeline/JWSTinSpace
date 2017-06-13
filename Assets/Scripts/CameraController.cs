using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public GameObject player;
	private Vector3 offset;
	private Transform target;

	void Start ()
	{
		offset = transform.position - player.transform.position;
	}

	void FixedUpdate ()
	{

//		if (Input.GetMouseButtonDown (0)) {
//
//
//			RaycastHit hitInfo = new RaycastHit();
//			bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);
//			if (hit && hitInfo.transform.gameObject.tag == "star") 
//			{
//				target = hitInfo.transform;
//				Debug.Log (hitInfo.transform.position);
//				transform.LookAt(target);
//			}
//		}
	}

	void LateUpdate ()
	{
		transform.position = player.transform.position + offset;
	}
}


