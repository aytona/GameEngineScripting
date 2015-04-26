using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// Keeps track of player score and displays it on the screen.
/// </summary>
public class PlayerScore : MonoBehaviour 
{
	/// <summary>
	/// Reference to the score UI object's text component.
	/// </summary>
	public Text scoreText = null;

	/// <summary>
	/// The score.
	/// </summary>
	private int score = 0;

	/// <summary>
	/// The total number of coins.
	/// </summary>
	private int coinCount = 0;


	void Awake ()
	{
		// Search the scene for all objects tagged "Coin".
		// If any are found, they are saved inside the GameObject[] array.
		GameObject[] coins = GameObject.FindGameObjectsWithTag("Coin");
		this.coinCount = coins.Length;
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		// Check if we collided with an object tagged "Coin".
		if (other.tag == "Coin")
		{
			// We have collided with a coin. 
			// Increment our score.
			this.score++;

			// Display the score.
			this.scoreText.text = "Coins Collected: " + this.score;

			// Destroy the coin.
			Destroy(other.gameObject);
		}

		if (this.score >= this.coinCount)
		{
			Application.LoadLevel("MainMenu");
		}
	}
}
