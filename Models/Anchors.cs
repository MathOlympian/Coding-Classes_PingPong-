using UnityEngine;
using System.Collections;

public class Anchors : MonoBehaviour 
{	

	// Use this for initialization
	void Start () {
		
		Debug.Log(this.gameObject.GetComponent<HingeJoint> ().connectedAnchor);

		Debug.Log (this.gameObject.transform.position);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
