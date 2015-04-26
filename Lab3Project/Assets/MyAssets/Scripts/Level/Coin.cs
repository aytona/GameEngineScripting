using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour
{
	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "Player")
		{
			Object.Destroy(this.gameObject);
		}
	}
}
