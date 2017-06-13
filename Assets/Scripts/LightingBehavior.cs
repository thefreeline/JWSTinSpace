using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightingBehavior : MonoBehaviour {

    public Light light;
    public float intensity;

	public void modifyLights()
    {
        light.intensity = intensity;
    }
}
