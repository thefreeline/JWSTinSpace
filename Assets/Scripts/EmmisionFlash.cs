using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmmisionFlash : MonoBehaviour {

    public Color colorStart = Color.cyan;
    public Color colorEnd = Color.white;
    public float duration = 1.0F;
    private Renderer rend;
    private GameObject obj;
    private Material mat;

	// Use this for initialization
	void Start () {
        //rend = GetComponent<Renderer>();
        obj = this.gameObject;
        rend = obj.GetComponent<Renderer>();
        mat = rend.material;
    }
	
	
    private void Update()
    { 
        float lerp = Mathf.PingPong(Time.time, duration) / duration;
        rend.material.color = Color.Lerp(colorStart, colorEnd, lerp);
    }
}
