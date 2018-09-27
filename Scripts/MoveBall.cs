using UnityEngine;
using System.Collections;

public class MoveBall : MonoBehaviour 
{

	public float rollingForce = 600f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		Move ();
	}

	void Move()
	{
		// if left arrow is pressed, roll ball left

		if (Input.GetKey(KeyCode.LeftArrow))
		{			
			// Get Rigidbody component of the ball,
			Rigidbody rb =  this.gameObject.GetComponent<Rigidbody>();

			// add a rolling force (torque)
			rb.AddTorque(0f, 0f, rollingForce);
		}

		// if right arrow is pressed

		if (Input.GetKey(KeyCode.RightArrow))
		{			
			// Get Rigidbody component of the ball,
			Rigidbody rb =  this.gameObject.GetComponent<Rigidbody>();

			// add a rolling force (torque)

			rb.AddTorque(0f, 0f, -rollingForce);
		}

		// if up arrow

		if (Input.GetKey(KeyCode.UpArrow))
		{			
			// Get Rigidbody component of the ball,
			Rigidbody rb =  this.gameObject.GetComponent<Rigidbody>();

			// add a rolling force (torque)

			rb.AddTorque(rollingForce, 0f, 0f);
		}

		// if down arrow
		if (Input.GetKey(KeyCode.DownArrow))
		{			
			// Get Rigidbody component of the ball,
			Rigidbody rb =  this.gameObject.GetComponent<Rigidbody>();

			// add a rolling force (torque)

			rb.AddTorque(-rollingForce, 0f, 0f);
		}
	}
}
