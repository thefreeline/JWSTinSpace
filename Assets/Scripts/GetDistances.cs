using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent (typeof (GUIText))]
public class GetDistances : MonoBehaviour {

	public GUIText distToSunText;
	public GUIText distToMercuryText;
	public GUIText distToVenusText;
	public GUIText distToEarthText;
	public GUIText distToMarsText;
	public GUIText distToJupiterText;
	public GUIText distToSaturnText;
	public GUIText distToNeptuneText;
	public GUIText distToUranusText;
	public GUIText distToJWSTText;

	//private float distToEarth;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		GameObject sun = GameObject.FindGameObjectWithTag("sun");
		GameObject mercury = GameObject.FindGameObjectWithTag("mercury");
		GameObject venus = GameObject.FindGameObjectWithTag("venus");
		GameObject earth = GameObject.FindGameObjectWithTag("earth");
		GameObject mars = GameObject.FindGameObjectWithTag("mars");
		GameObject jupiter = GameObject.FindGameObjectWithTag("jupiter");
		GameObject saturn = GameObject.FindGameObjectWithTag("saturn");
		GameObject neptune = GameObject.FindGameObjectWithTag("neptune");
		GameObject uranus = GameObject.FindGameObjectWithTag("uranus");
		GameObject jwst = GameObject.FindGameObjectWithTag("jwst");


		if (sun) {
			//float sunDist = (Mathf.Round((Vector3.Distance(sun.transform.position, sun.transform.position) * 1000f) * 0.001f) / 0.001f);
			//distToSunText.text = "Sun";
		}
		if (mercury) {
//			float mercuryDist = (Mathf.Round((Vector3.Distance(mercury.transform.position, sun.transform.position) * 1000f) * 0.001f) / 0.001f);
//			distToMercuryText.text = "Mercury: " + mercuryDist.ToString("N0") + " miles from Sun";
			distToMercuryText.text = "Mercury: 35.98 million miles from Sun";
		}
		if (venus) {
//			float venusDist = (Mathf.Round((Vector3.Distance(venus.transform.position, sun.transform.position) * 1000f) * 0.001f) / 0.001f);
//			distToVenusText.text = "Venus: " + venusDist.ToString("N0") + " miles from Sun";
			distToVenusText.text = "Venus: 67.24 million miles from Sun";
		}
		if (earth) {
			//float earthDist = (Mathf.Round((Vector3.Distance(earth.transform.position, sun.transform.position) * 10000f) * 0.01f) / 0.01f);
			//distToEarthText.text = "Earth: " + earthDist.ToString("N0") + " miles from Sun";
			distToEarthText.text = "Earth: 92.96 million miles from Sun";
		}
		if (mars) {
			float marsDist = (Mathf.Round((Vector3.Distance(mars.transform.position, sun.transform.position) * 1000f) * 0.001f) / 0.001f);
			distToMarsText.text = "Mars: " + marsDist.ToString("N0") + " miles from Sun";
		}
		if (jupiter) {
			float jupiterDist = (Mathf.Round((Vector3.Distance(jupiter.transform.position, sun.transform.position) * 1000f) * 0.0001f) / 0.0001f);
			distToJupiterText.text = "Jupiter: " + jupiterDist.ToString("N0") + " miles from Sun";
		}
		if (saturn) {
			float saturnDist = (Mathf.Round((Vector3.Distance(saturn.transform.position, sun.transform.position) * 1000f) * 0.0001f) / 0.0001f);
			distToSaturnText.text = "Saturn: " + saturnDist.ToString("N0") + " miles from Sun";
		}
		if (neptune) {
			float neptuneDist = (Mathf.Round((Vector3.Distance(neptune.transform.position, sun.transform.position) * 1000f) * 0.0001f) / 0.0001f);
			distToNeptuneText.text = "Neptune: " + neptuneDist.ToString("N0") + " miles from Sun";
		}
		if (uranus) {
			float uranusDist = (Mathf.Round((Vector3.Distance(uranus.transform.position, sun.transform.position) * 1000f) * 0.0001f) / 0.0001f);
			distToUranusText.text = "Uranus: " + uranusDist.ToString("N0") + " miles from Sun";
		}
		if (jwst) {
			float jwstDist = (Mathf.Round((Vector3.Distance(jwst.transform.position, earth.transform.position) * 1000f) * 0.001f) / 0.001f);
			distToJWSTText.text = "JWST: " + jwstDist.ToString("N0") + " miles from Earth";
		}
	}
}
