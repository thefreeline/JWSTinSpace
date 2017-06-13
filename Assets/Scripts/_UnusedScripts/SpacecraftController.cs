using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class SpacecraftController : MonoBehaviour
{
	public float MaxEnginePower = 40f;
	public float RollEffect = 50f;
	public float PitchEffect = 50f;
	public float YawEffect = 0.2f;
	public float BankedTurnEffect = 0.5f;
	public float AutoTurnPitch = 0.5f;
	public float AutoRollLevel = 0.1f;
	public float AutoPitchLevel = 0.1f;
	public float AirBreaksEffect = 3f;
	public float ThrottleChangeSpeed = 0.3f;
	public float DragIncreaseFactor = 0.001f;

	private float Throttle;
	private bool AirBrakes;
	private float ForwardSpeed;
	private float EnginePower;
	private float cur_MaxEnginePower;
	private float RollAngle;
	private float PitchAngle;
	private float RollInput;
	private float PitchInput;
	private float YawInput;
	private float ThrottleInput;

	private float OriginalDrag;
	private float OriginalAngularDrag;
	//private float AeroFactor = 1;
	//private bool Immobilized = false;
	private float BankedTurnAmount;
	private Rigidbody rigidBody;
	WheelCollider[] cols;


//	void Start()
//	{
//		rigidBody = GetComponent<Rigidbody> ();
//
//		OriginalDrag = rigidBody.drag;
//		OriginalAngularDrag = rigidBody.angularDrag;
//
//		for (int i = 0; i < transform.childCount; i++) {
//			foreach (var componentsInChild in transform.GetChild(i).GetComponentInChildren<WheelCollider>()) {
//				//componentsInChild.motorTorque = 0.18f;
//			}
//		}
	//}


}