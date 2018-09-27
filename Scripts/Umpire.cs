using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Umpire : MonoBehaviour 
{
	public GameObject ball;
	public GameObject[] players;
	public int playerScore1, playerScore2;
	public float ballSpeedX, ballSpeedZ;
	Vector3 pos1, pos2, ballPos;
	public Text scoreText1, scoreText2, gameOverText;

	private bool isGameOver;

	public bool IsGameOver
	{
		get
		{ 
			return isGameOver; 
		}
		set
		{ 
			isGameOver = value; 
		}
	}

	// Use this for initialization
	void Start () 
	{
		isGameOver = false;
		Initialize ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		PlayerScore ();
	}

	/// <summary>
	/// Restart the game after player has scored.
	/// </summary>
	void Restart()
	{
			// In English we want to,
		// - reset the ball speed to initial value
		// - remove gameover text from the screen
		ball.GetComponent<BallClass> ().ballSpeedX = ball.GetComponent<BallClass> ().ballSpeedZ = 0.2f;
		gameOverText.gameObject.SetActive(false);
	}

	/// <summary>
	/// Umpire executes this function when a player has scored.
	/// We used the Invoke method which allows us to call a function / method with a delay.
	/// </summary>
	void PlayerScore()
	{		
				// In English (for the each of the two players),
		// If ball position is beyond the player,
		   // - Increase the other player player's score by 1
		   // - Update the score board
		   // - Reset the ball's position
		   // - Reset the ball's speed
		   // - Check if game over 
		   // - Restart after 2 seconds

		if (ball.transform.position.x > players[0].transform.position.x)
		{
			playerScore2 += 1;
			scoreText2.text = "Player2:  " + playerScore2;
			ball.transform.position = ballPos;
			ball.GetComponent<BallClass> ().ballSpeedX = ball.GetComponent<BallClass> ().ballSpeedZ = 0f;
			GameOver ();
			Invoke ("Restart", 2f);

			// Play audio when a goal is score
			// Get the score clips from the ball class

			AudioClip scoreClip = ball.GetComponent<BallClass> ().soundClips [2];
			AudioSource mainAudioSource = ball.GetComponent<BallClass> ().aud;
			mainAudioSource.PlayOneShot (scoreClip);
		}

		if (ball.transform.position.x < players[1].transform.position.x)
		{
			playerScore1 += 1;
			scoreText1.text = "Player1:  " + playerScore1;
			ball.transform.position = ballPos;
			ball.GetComponent<BallClass> ().ballSpeedX = ball.GetComponent<BallClass> ().ballSpeedZ = 0f;
			GameOver ();
			Invoke ("Restart", 2f);

			// Play audio when a goal is score
			// Get the score clips from the ball class
			// 
			AudioClip scoreClip = ball.GetComponent<BallClass> ().soundClips [2];
			AudioSource mainAudioSource = ball.GetComponent<BallClass> ().aud;
			mainAudioSource.PlayOneShot (scoreClip);
		}
	}

	/// <summary>
	/// This is what happens when the game is over.
	/// </summary>
	void GameOver()
	{
		// In English,
		// If the any of players has scored 5 points,
			// Display game over
			// Reset the first player's position
			// Reset the second player's position
			// Reset the first player's score
			// Reset the second player's score

		if (playerScore1 == 10 || playerScore2 == 10) 
		{
			gameOverText.gameObject.SetActive (true);
			players[0].transform.position = pos1;
			players[1].transform.position = pos2;
			playerScore1 = 0; 
			playerScore2 = 0;
		}
	}

	void Initialize()
	{
		// In English we want to
		// get the initial position of the first player
		// get the initial position of the second player
		// get the initial position of the ball
		// Remove the game over text

		pos1 = players[0].transform.position;
		pos2 = players[1].transform.position;
		ballPos = ball.transform.position;
		gameOverText.gameObject.SetActive (false);
	}
}
