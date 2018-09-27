using UnityEngine;
using System.Collections;

public class PlayerClass : MonoBehaviour 
{

	public float moveSpeed = 0.3f; // Change this value to alter the speed of your paddle

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		MovePlayer ();
		ClampPlayerPaddle ();
	}


	/// <summary>
	/// Clamps the player paddle. Prevent paddle from entering the walls. 
	/// We used the Mathf.Clamp function. 
	/// Remember to check out other Mathf functions
	/// </summary>
	void ClampPlayerPaddle()
	{
		Vector3 position = transform.position;
		position.z = Mathf.Clamp (position.z, -6.7f, 10.0f);
		transform.position = position;
	}

	/// <summary>
	/// Moves the player. 
	/// Translate the player's paddle with keyboard keys using transform.Translate function.
	/// Remember to checkout other transform functions
	/// </summary>
	void MovePlayer()
	{
		if (gameObject.name == "Player 1") 
		{
			if(Input.GetKey(KeyCode.LeftArrow))
			{
				transform.Translate (0f, 0f, -moveSpeed);
			}

			if (Input.GetKey(KeyCode.RightArrow))
			{
				transform.Translate (0f, 0f, moveSpeed);
			}			
		}

		if (gameObject.name == "Player 2") 
		{
			if(Input.GetKey(KeyCode.A))
			{
				transform.Translate (0f, 0f, -moveSpeed);
			}

			if (Input.GetKey(KeyCode.D))
			{
				transform.Translate (0f, 0f, moveSpeed);
			}			
		}
	}
}
