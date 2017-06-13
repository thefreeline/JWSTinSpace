using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed;
	private Rigidbody rb;
	private Vector3 targetPos;

//	void OnGUI() {
//		Event e = Event.current;
//		if (e.isKey)
//			Debug.Log("e.keyCode: "+e.keyCode);
//	}

	void Start ()
	{
		rb = GetComponent<Rigidbody>();
		speed = 0;

	}

	void Update(){
		
	}

	void FixedUpdate ()
	{
//		float moveHorizontal = Input.GetAxis ("Horizontal");
//		float moveVertical = Input.GetAxis ("Vertical");
//
//
//		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);



		//Debug.Log (Input.inputString);
		if (Input.GetKeyDown ("[")) {
			speed -= 1;
		}
		if (Input.GetKeyDown ("]")) {
			speed += 1;
		}
		if (Input.GetKeyDown ("space")) {
			speed = 0;
			rb.velocity = new Vector3(0,0,0);
		}

		rb.AddForce (transform.forward * speed);
		//transform.position += transform.forward * Time.deltaTime * speed;

		transform.Rotate ( Input.GetAxis("Vertical"), 0.0f, -Input.GetAxis("Horizontal"));


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
