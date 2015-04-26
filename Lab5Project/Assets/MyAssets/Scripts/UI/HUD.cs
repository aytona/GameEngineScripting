using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HUD : MonoBehaviour {
	public Text score;
	public Text highscore;
	public int coinCounter = 0;
	public int totalCoins;

	private static HUD instance = null;

	void Update() {
		GameObject[] coins = GameObject.FindGameObjectsWithTag("Coin");
		if (totalCoins > coins.Length) {
			coinCountUpdate();
		}
		PlayerData.Instance.SetScore((int) coinCounter);

		this.score.text = "Score: " + PlayerData.Instance.GetScore();
		this.highscore.text = "HighScore: " + PlayerData.Instance.GetHighscore();
	}

	void OnLevelWasLoaded() {
		if (Application.loadedLevelName == "MainMenu") {
			GameObject.Destroy(this.gameObject);
		}
		if (Application.loadedLevelName == "Level1") {
			GameObject[] coins = GameObject.FindGameObjectsWithTag("Coin");
			totalCoins = coins.Length;
		}
		if (Application.loadedLevelName == "Level2") {
			GameObject[] coins = GameObject.FindGameObjectsWithTag("Coin");
			totalCoins = coins.Length;
		}
		if (Application.loadedLevelName == "Level3") {
			GameObject[] coins = GameObject.FindGameObjectsWithTag("Coin");
			totalCoins = coins.Length;
		}
	}

	void Awake() {
		GameObject[] coins = GameObject.FindGameObjectsWithTag("Coin");
		totalCoins = coins.Length;
		if (instance == null) {
			// First instance of HUD being loaded.
			// Claim this instance.
			instance = this;

			// Make it persist throughout scene transitions.
			GameObject.DontDestroyOnLoad(this.gameObject);
		}
		else {
			// Instance already claimed. Destroy any additional HUD object.
			Destroy(this.gameObject);
		}
	}
	void coinCountUpdate() {
		coinCounter++;
		totalCoins--;
	}
}
