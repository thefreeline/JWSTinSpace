using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreventCollisions : MonoBehaviour {

    public GameObject[] preventCollisionWith;

	// Use this for initialization
	void Start () {

        var thisCol = this.GetComponent<Collider>();

        for (int i = 0; i < preventCollisionWith.Length; i++)
        {
            var col = preventCollisionWith[i].GetComponent<Collider>();
            Physics.IgnoreCollision(thisCol, col);
        }
    }
}
