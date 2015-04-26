using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D target) {
		if (target.tag == "Player") {
			Destroy(this.gameObject);
		}
	}
}
