using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightIntesityByDistance : MonoBehaviour {

    public GameObject maxIntensityStart;
    public GameObject minIntensityEnd;

    public Light Light1;
    private float Light1CurrentIntensity;
    public float Light1TargetIntensity;


    private Vector3 startMeasurePos;
    private Vector3 finishMeasurePos;
    private Vector3 cameraPos;
    private float distanceBtwnStartFinish;
    private float distanceFromFinalPos;
    private float distanceFromStartPos;
    private float travelRatio;

    // Use this for initialization
    void Start()
    {
        startMeasurePos = maxIntensityStart.transform.position;
        finishMeasurePos = minIntensityEnd.transform.position;
        distanceBtwnStartFinish = Vector3.Distance(startMeasurePos, finishMeasurePos);

        //Get starting intensity of light 1
        Light1CurrentIntensity = Light1.intensity;

    }

    // Update is called once per frame
    void Update()
    {
        //Get camera position
        cameraPos = Camera.main.transform.position;

        //Get Distance from final position
        distanceFromFinalPos = Vector3.Distance(cameraPos, finishMeasurePos);

        //Get Distance from start position
        distanceFromStartPos = Vector3.Distance(cameraPos, startMeasurePos);

        //Calculate the percentage of distance travled between staring position and total distance between start and finish
        travelRatio = distanceFromStartPos / distanceBtwnStartFinish;

        if (distanceFromFinalPos < distanceBtwnStartFinish)
        {
            Light1.intensity = Mathf.Lerp(Light1CurrentIntensity, Light1TargetIntensity, travelRatio);
           
        }
    }
}
