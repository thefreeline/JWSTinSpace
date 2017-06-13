using UnityEngine;
using System.Collections;

public class CloseInformationMenu : MonoBehaviour {


	public void OnTriggerEnter(){

		GameObject childObject = this.gameObject;
		string menuTag = "infoMenu";

		FindParentWithTag (childObject,menuTag);
	}

    //public void OnCollisionEnter(Collision collision)
    //{
    //    Debug.Log("Collision!");
    //    GameObject childObject = this.gameObject;
    //    string menuTag = "infoMenu";

    //    FindParentWithTag(childObject, menuTag);
    //}

    public void FindParentWithTag(GameObject childObject, string tag)
	{
		Transform t = childObject.transform;
		while (t.parent != null)
		{
			if (t.parent.tag == tag)
			{
                Debug.Log(t);
                t.GetComponent<AudioSource>().Stop();
                t.parent.transform.localPosition = new Vector3(0,0,0);
			}
			t = t.parent.transform;
		}
	}
}
