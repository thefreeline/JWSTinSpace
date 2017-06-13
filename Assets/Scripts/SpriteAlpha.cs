using UnityEngine;
using System.Collections;

public class SpriteAlpha : MonoBehaviour {

	private float alpha;

	// Use this for initialization
	void Start () {
		this.GetComponent<SpriteRenderer> ().color = new Color(1F,1F,1F,0.025F);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
