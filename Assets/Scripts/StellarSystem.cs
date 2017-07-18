using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using VRTK;
using UnityEngine.SceneManagement;
using System;
using System.Collections.Generic;

//Script used to create individual stellar system scene (close up view)

public class StellarSystem : MonoBehaviour {

	public string starName;
	static public float starX;
	static public float starY;
	static public float starZ;
	static public float starRadius;
	static public float starColor;

	static public List<string> planetName;
	static public float planetOrbMax;
    static public float planetOrbPeriod;
    static public float planetRadius;


	public Text starNameText;
	public Text starRadiusText;
	public Text starTempText;

	public Text planetNameText;
	public Text planetOrbMaxText;
	public Text planetRadiusText;


    // Use this for initialization
    void Start()
    {
        
        starName = StellarSystemProps.starName;
        starX = StellarSystemProps.starX;
        starY = StellarSystemProps.starY;
        starZ = StellarSystemProps.starZ;
        starColor = StellarSystemProps.starColor;
        starRadius = StellarSystemProps.starRadius;
        planetName = StellarSystemProps.planetName;
        planetOrbMax = StellarSystemProps.planetOrbMax;
        planetOrbPeriod = StellarSystemProps.planetOrbPeriod;
        planetRadius = StellarSystemProps.planetRadius;

        new createStars(starName, starX, starY, starZ, starColor, starRadius);

    }

    public class createStars
    {
        private GameObject star;
        private VRStandardAssets.Utils.VRInteractiveItem starInteractive;
        private GameObject starSystemContainer;
        private GameObject starContainer;

        //Define star materials
        private Material redStarMaterial = Resources.Load("redStarMaterial", typeof(Material)) as Material;
        private Material orangeStarMaterial = Resources.Load("orangeStarMaterial", typeof(Material)) as Material;
        private Material yellowStarMaterial = Resources.Load("yellowStarMaterial", typeof(Material)) as Material;
        private Material blueStarMaterial = Resources.Load("blueStarMaterial", typeof(Material)) as Material;
        private Material greenStarMaterial = Resources.Load("greenStarMaterial", typeof(Material)) as Material;
        private Material cyanStarMaterial = Resources.Load("cyanStarMaterial", typeof(Material)) as Material;
        private Material sunRedGamma = Resources.Load("FORGE3D/Planets/Sun/Materials/Sun_red_gamma", typeof(Material)) as Material;
        private Material sunBlueGamma = Resources.Load("FORGE3D/Planets/Sun/Materials/Sun_blue_gamma", typeof(Material)) as Material;
        private Material sunGreenGamma = Resources.Load("FORGE3D/Planets/Sun/Materials/Sun_green_gamma", typeof(Material)) as Material;
        private Material sunBlueWhiteGamma = Resources.Load("FORGE3D/Planets/Sun/Materials/Sun_blue_white_gamma", typeof(Material)) as Material;
        private Material sunWhiteGamma = Resources.Load("FORGE3D/Planets/Sun/Materials/Sun_white_gamma", typeof(Material)) as Material;
        private Material sunYellowWhiteGamma = Resources.Load("FORGE3D/Planets/Sun/Materials/Sun_yellow_white_gamma", typeof(Material)) as Material;
        private Flare yellowFlareMed = Resources.Load("FlareSmall", typeof(Flare)) as Flare;

        public void changeScene(object sender, InteractableObjectEventArgs e)
        {
            SceneManager.LoadScene("--Experimental--LUVOIR Exoplanet");
        }

        public createStars(
            string starName,
            float starX,
            float starY,
            float starZ,
            float starColor,
            float starRadius
            )
        {
            //Get game object to put star systems into
            starSystemContainer = GameObject.Find("Star Systems");
            starContainer = GameObject.Find(starName);

            //create new star primitive
            if (!starContainer)
            {

                //Create star and assign basic properties
                GameObject star = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                star.name = starName;
                star.tag = "star";

                //Add position and scalle, then move to star container
                //star.transform.position = new Vector3(starX, starY, starZ);
                star.transform.position = new Vector3(0f, 0f, 0f);
                star.transform.localScale = new Vector3(starRadius, starRadius, starRadius);
                star.transform.parent = starSystemContainer.transform;

                //Add sphere collider
                var starCollider = star.GetComponent<SphereCollider>();
                starCollider.isTrigger = true;
                starCollider.radius = 1F;


                //Make star interacable and attach change scene script to Obj Used
                var starInteractable = star.AddComponent<VRTK.VRTK_InteractableObject>();
                starInteractable.disableWhenIdle = false;
                starInteractable.pointerActivatesUseAction = true;
                starInteractable.holdButtonToUse = false;
                starInteractable.InteractableObjectUsed += new VRTK.InteractableObjectEventHandler(changeScene);

                //Assign proper materials based on star temperature
                if (starColor <= 3500)
                {
                    star.GetComponent<Renderer>().material = sunRedGamma;
                }
                else if (starColor >= 3501 && starColor <= 6000)
                {
                    star.GetComponent<Renderer>().material = sunGreenGamma;
                }
                else if (starColor >= 6001 && starColor <= 7500)
                {
                    star.GetComponent<Renderer>().material = sunYellowWhiteGamma;
                }
                else if (starColor >= 7501 && starColor <= 10000)
                {
                    star.GetComponent<Renderer>().material = sunWhiteGamma;
                }
                else
                {
                    star.GetComponent<Renderer>().material = sunBlueGamma;
                };

                //Add lens flare to star
                //var starLight = new GameObject("Star Light");
                //starLight.AddComponent<Light>();
                //var StarFlare = starLight.AddComponent<LensFlare>();
                //StarFlare.flare = yellowFlareMed;

                //starLight.transform.parent = star.transform;
                //starLight.transform.localPosition = new Vector3(0, 0, 0);

            }
            //new createPlanets(starName, starX, starY, starZ, starColor, starRadius, planetName, planetOrbMax, planetOrbPeriod, planetRadius);
        }
    }

    public class createPlanets
    {
        private GameObject star;
        private Material planetTrailMaterial = Resources.Load("redStarMaterial", typeof(Material)) as Material;

        public createPlanets(
            string starName,
            float starX,
            float starY,
            float starZ,
            float starColor,
            float starRadius,
            string planetName,
            float planetOrbMax,
            float planetOrbPeriod,
            float planetRadius)
        {

            star = GameObject.Find(starName);

            //Create new planet primitive
            GameObject planet = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            planet.transform.parent = star.transform;
            planet.AddComponent<Orbiter>();
            //planet.GetComponent<Orbiter>().orbitSpeed = planetOrbPeriod;
            planet.GetComponent<Orbiter>().orbitSpeed = 100;
            planet.name = planetName;
            planet.tag = "planet";
            var planetZ = starZ + planetOrbMax;
            planet.transform.position = new Vector3(starX, starY, 0);
            planet.transform.localScale = new Vector3(planetRadius, planetRadius, planetRadius);

            //// Add star rigidbody component
            Rigidbody planetRigidBody = planet.AddComponent<Rigidbody>();
            planetRigidBody.mass = 0;
            planetRigidBody.useGravity = false;
            planetRigidBody.isKinematic = true;


            //Add trail renderers
            TrailRenderer planetTrail;
            Material planetTrailMat;

            GameObject planetTrailObj = new GameObject();
            planetTrailObj.name = planetName + "_trail";
            planetTrailObj.transform.parent = planet.transform;
            planetTrailObj.transform.localPosition = Vector3.zero;

            planetTrail = planetTrailObj.AddComponent<TrailRenderer>();
            planetTrail.time = 10;
            planetTrail.startWidth = 0.5F;
            planetTrail.endWidth = 0.0F;

            planetTrailMat = planetTrailObj.GetComponent<Renderer>().material = planetTrailMaterial;

            //Render text overlay
            //GameObject player = GameObject.FindGameObjectWithTag("GameController");
            //float distToStar = Vector3.Distance(planet.transform.position, player.transform.position);
            //var textcoloropacity = ConvertRange(0f, 10000f, 1f, 0f, distToStar);
            ////GameObject canvas = Gameobject.findgameobjectwithtag("canvaslabels");
            //GameObject canvas = GameObject.FindWithTag("starLabels");
            //GameObject textgo = new GameObject(starName + "_labelcont");
            //textgo.transform.SetParent(canvas.transform);
            //var text = textgo.AddComponent<Text>();
            //text.text = starName;
            //text.tag = "starLabel";
            //text.color = new Color(1f, 1f, 1f, textcoloropacity);
            //var objLabel = textgo.AddComponent<ObjectLabel>();
            //objLabel.target = star.transform;
            //objLabel.clampToScreen = false;
        }
    }
}
