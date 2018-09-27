using UnityEngine;
using System.Collections;

public class BallClass : MonoBehaviour 
{
	public float ballSpeedZ;
	public float ballSpeedX;
	public AudioSource aud;
	public AudioClip[] soundClips;
	Umpire umpire;
	float resetBallSpeed = 0.2f;

	// Use this for initialization
	void Start () 
	{
		ballSpeedX = ballSpeedZ = resetBallSpeed;
	}		
	
	// Update is called once per frame
	void Update () 
	{
		UpdateBallMovement ();	
	}

	/// <summary>
	/// Updates the ball movement with the transform.Translate method
	/// Feel free to check other transform methods
	/// </summary>
	void UpdateBallMovement()
	{
		transform.Translate (ballSpeedX, 0f, ballSpeedZ);
	}

	/// <summary>
	/// Raises the trigger enter event. This method is pre-written for us by Unity.
	/// When a collider component of one gameobject interacts with another we do something
	/// </summary>
	/// <param name="other">Other.</param>
	void OnTriggerEnter(Collider other) 
	{
		// If the ball hits a player 
			// vary the ballspeedX.
			// vary the ballspeedZ
		// (Random.Range is used to get a random value within a range)
		if (other.tag == "Player")
		{	
			ballSpeedX = Random.Range(0.95f, 1.75f) * - ballSpeedX; 
			ballSpeedZ = Random.Range(0.95f, 1.75f) * ballSpeedZ;

			// reset speed if too high
			if (ballSpeedX > 1.8 * resetBallSpeed)
			{
				ballSpeedX = resetBallSpeed;
			}
			if (ballSpeedZ > 1.8 * resetBallSpeed)
			{
				ballSpeedZ = resetBallSpeed;
			}

			aud.PlayOneShot (soundClips [0]); // paddle sound
		}

		// If the ball hits a wall 
			// reverse its direction
		if (other.tag == "Wall")
		{
			ballSpeedZ = -ballSpeedZ;
			aud.PlayOneShot (soundClips [1], 0.75f); // wall sound
		}	
	}
}
