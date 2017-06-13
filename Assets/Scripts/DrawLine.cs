using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour {

    private LineRenderer lineRenderer;
    private float counter;
    private float dist;

    public Transform origin;
    public Transform destination;
    public float startWidth;
    public float endWidth;

    public float drawLineSpeed;

	// Use this for initialization
	void Start () {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.SetPosition(0, origin.localPosition);
        lineRenderer.SetWidth(startWidth, endWidth);

        dist = Vector3.Distance(origin.position, destination.localPosition);
	}
	
	// Update is called once per frame
	void Update () {
        renderLine();
	}

    void renderLine()
    {
        if (counter < dist)
        {
            counter += .1f / drawLineSpeed;

            float x = Mathf.Lerp(0, dist, counter);

            Vector3 pointA = origin.localPosition;
            Vector3 pointB = destination.localPosition;

            Vector3 pointAlongLine = x * Vector3.Normalize(pointB - pointA) + pointA;

            lineRenderer.SetPosition(1, pointAlongLine);
        }
    }
}
