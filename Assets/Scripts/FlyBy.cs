using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyBy : MonoBehaviour {

    public GameObject startObj;
    public GameObject finishObj;

    public GameObject Obj1;
    private Vector3 Obj1CurrentSize;
    public Vector3 Obj1TargetSize;

    public GameObject Obj2;
    private Vector3 Obj2CurrentSize;
    public Vector3 Obj2TargetSize;

    public GameObject Obj3;
    private Vector3 Obj3CurrentSize;
    public Vector3 Obj3TargetSize;

    private Vector3 startMeasurePos;
    private Vector3 finishMeasurePos;
    private Vector3 cameraPos;
    private float distanceBtwnStartFinish;
    private float distanceFromFinalPos;
    private float distanceFromStartPos;
    private float travelRatio;

    // Use this for initialization
    void Start () {
        startMeasurePos = startObj.transform.position;
        finishMeasurePos = finishObj.transform.position;
        distanceBtwnStartFinish = Vector3.Distance(startMeasurePos, finishMeasurePos);

        //This could be DRYed
        //Get starting size of object 1
        Obj1CurrentSize = Obj1.transform.localScale;

        //Get starting size of object 2
        Obj2CurrentSize = Obj2.transform.localScale;

        //Get starting size of object 3
        Obj3CurrentSize = Obj3.transform.localScale;

    }
	
	// Update is called once per frame
	void Update () {
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
            Obj1.transform.localScale = Vector3.Lerp(Obj1CurrentSize, Obj1TargetSize, travelRatio);
            Obj2.transform.localScale = Vector3.Lerp(Obj2CurrentSize, Obj2TargetSize, travelRatio);
            Obj3.transform.localScale = Vector3.Lerp(Obj3CurrentSize, Obj3TargetSize, travelRatio);
        }
    }
}
