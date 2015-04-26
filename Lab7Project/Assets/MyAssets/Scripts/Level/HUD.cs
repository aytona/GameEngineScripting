using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HUD : MonoBehaviour 
{
	public GameObject player;
	public Text score = null;
	public Text highScore = null;
	public Text health = null;
	public GameObject explosionPrefab;

	// Unity Script Singleton:

	private static HUD instance = null;

	void Awake ()
	{
		if (instance == null)
		{
			GameObject.DontDestroyOnLoad(this.gameObject);
			instance = this;
		}
		else
		{
			GameObject.Destroy(this.gameObject);
		}
	}
	
	// Update score and high score text values each frame.
	void Update ()
	{
		this.score.text = "Player Score: " + PlayerData.Instance.Score.ToString();
		this.highScore.text = "Player High Score: " + PlayerData.Instance.HighScore.ToString();
		if (PlayerData.Instance.Health == 2) {
			this.health.text = "Health: <color=yellow>" + PlayerData.Instance.Health.ToString() + "</color>";
		}
		if (PlayerData.Instance.Health == 1) {
			this.health.text = "Health: <color=red>" + PlayerData.Instance.Health.ToString() + "</color>";
		}
		if (PlayerData.Instance.Health == 0) {
			this.health.text = "Health: <color=#800000>" + PlayerData.Instance.Health.ToString() + "</color>";
		}

		if (PlayerData.Instance.Health <= 0) {
			DestroyMe();
		}
	}

	void OnLevelWasLoaded ()
	{
		if (Application.loadedLevelName == "MainMenu")
		{
			PlayerData.Instance.Score = 0;
			PlayerData.Instance.Health = 3;
			Destroy (this.gameObject);
		}
	}

	private void DestroyMe() {
		Vector2 pos = player.transform.position;
		Destroy (player);
		GameObject explosion = Instantiate(this.explosionPrefab) as GameObject;
		explosion.transform.position = pos;
	}
}
