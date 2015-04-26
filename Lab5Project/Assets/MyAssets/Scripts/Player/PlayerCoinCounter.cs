using UnityEngine;
using System.Collections;

public class PlayerCoinCounter : MonoBehaviour {

	public int coinCounter;

	void OnTriggerEnter2D(Collider2D target) {
		if (target.tag == "Coin") {
			coinCounter++;
			Destroy (target.gameObject);
		}
	}
	public int getCoinCounter() {
		return coinCounter;
	}
}
