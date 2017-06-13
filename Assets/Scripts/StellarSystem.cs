using UnityEngine;
using UnityEngine.UI;
using System.Collections;


//Script used to create individual stellar system scene (close up view)

public class StellarSystem : MonoBehaviour {

	static public string starName;
	static public float starX;
	static public float starY;
	static public float starZ;
	static public float starRadius;
	static public float starColor;

	static public string planetName;
	static public float planetOrbMax;
	static public float planetRadius;


	public Text starNameText;
	public Text starRadiusText;
	public Text starTempText;

	public Text planetNameText;
	public Text planetOrbMaxText;
	public Text planetRadiusText;


	public class planetSystem {


		private float planetZ;
		//private float orbitDiameter;

		public planetSystem (
			string starName, 
			float starX, 
			float starY, 
			float starZ, 
			float starColor, 
			float starRadius, 
			string planetName, 
			float planetOrbitMax,
			float planetRadius )
		{



			var cameraPosY = planetOrbMax * 5;
			Camera.main.transform.position = new Vector3(0,cameraPosY,0);

			//create new star primitive
			GameObject star = GameObject.CreatePrimitive (PrimitiveType.Sphere);
			star.name = starName;
			star.tag = "star";
			star.transform.position = Vector3.zero; //Place star at 0,0,0
			star.transform.localScale = new Vector3 (starRadius, starRadius, starRadius);

			// Add properties to StellarSystemProps script to be access when creating new scene
			star.AddComponent<StellarSystemProps>();
			var starProps = star.GetComponent<StellarSystemProps>();
			starProps.starName = starName;
			starProps.starX = starX;
			starProps.starY = starY; 
			starProps.starZ = starZ; 
			starProps.starColor = starColor; 
			starProps.starRadius = starRadius; 
			starProps.planetName = planetName;
			starProps.planetOrbMax = planetOrbMax;
			starProps.planetRadius = planetRadius;

			// Add star rigidbody component
			Rigidbody starRigidBody = star.AddComponent<Rigidbody> ();
			starRigidBody.mass = 0;
			starRigidBody.useGravity = false;
			starRigidBody.isKinematic = true;


			Material orbitalSphereMaterial = Resources.Load ("orbitalSphereMaterial", typeof(Material)) as Material;

			Material blueStarMaterial = Resources.Load ("LocalStarBody-Blue-001", typeof(Material)) as Material;
			Material yellowStarMaterial = Resources.Load ("LocalStarBody-Yellow-001", typeof(Material)) as Material;
			Material orangeStarMaterial = Resources.Load ("LocalStarBody-Orange-001", typeof(Material)) as Material;
			Material redStarMaterial = Resources.Load ("LocalStarBody-Red-001", typeof(Material)) as Material;

			if(starColor <= 3500)
			{
				star.GetComponent<Renderer>().material = redStarMaterial;
			}
			else if(starColor >= 3501 && starColor <= 5000)
			{
				star.GetComponent<Renderer>().material = orangeStarMaterial;
			}
			else if(starColor >= 5001 && starColor <= 6000)
			{
				star.GetComponent<Renderer>().material = yellowStarMaterial;
			}
			else if(starColor >= 6001 )
			{
				star.GetComponent<Renderer>().material = blueStarMaterial;
			}

			//Create new planet primitive
			GameObject planet = GameObject.CreatePrimitive (PrimitiveType.Sphere);
			planet.transform.parent = star.transform;
			planet.AddComponent<Orbiter>();
			planet.name = planetName;
			planet.tag = "planet";
			var planetZ = starZ + planetOrbitMax;
			planet.transform.position = new Vector3 (starX, starY, planetZ);
			planet.transform.localScale = new Vector3 (planetRadius, planetRadius, planetRadius); 

			//// Add star rigidbody component
			Rigidbody planetRigidBody = planet.AddComponent<Rigidbody> ();
			planetRigidBody.mass = 0;
			planetRigidBody.useGravity = false;
			planetRigidBody.isKinematic = true;

			TrailRenderer planetTrail;
			GameObject planetTrailObj = new GameObject();
			planetTrailObj.name = planetName + "_trail";
			planetTrailObj.transform.parent = planet.transform;
			planetTrailObj.transform.localPosition = Vector3.zero;
			planetTrail = planetTrailObj.AddComponent<TrailRenderer>();
			planetTrail.time = Mathf.Infinity;
			planetTrail.startWidth = 0.1F;
			planetTrail.endWidth = 0.1F;
			planetTrailObj.GetComponent<TrailRenderer>().material = orbitalSphereMaterial;


			//				orbitDiameter = ((planetZ)-(starZ));

			////Create new planet orbital path primitive
			//				GameObject planetOrbit = GameObject.CreatePrimitive (PrimitiveType.Cylinder);
			//				planetOrbit.name = planetName + "_orbitalPath";
			//				planetOrbit.GetComponent<Renderer>().material = orbitalSphereMaterial;
			//				planetOrbit.transform.position = new Vector3 (starX, starY, starZ);
			//				planetOrbit.transform.localScale = new Vector3 (orbitDiameter, 0.01F, orbitDiameter);

			////Add star rigidbody component
			//				Rigidbody planetOrbitRigidBody = planetOrbit.AddComponent<Rigidbody> ();
			//				planetOrbitRigidBody.mass = 0;
			//				planetOrbitRigidBody.useGravity = false;
			//				planetOrbitRigidBody.isKinematic = true;

		}
	}

	// Use this for initialization
	void Start () {

		new planetSystem (starName, starX, starY, starZ, starColor, starRadius, planetName, planetOrbMax, planetRadius);

		//Populate canvas text
		starNameText.text = starName;
		starRadiusText.text = starRadius + " Solar Radii";
		starTempText.text = starColor + "K";

		planetNameText.text = planetName;
		planetOrbMaxText.text = planetOrbMax + "AU";
		planetRadiusText.text = planetRadius + " Jupiter Radii";

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
