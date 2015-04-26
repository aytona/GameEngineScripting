using UnityEngine;
using System.Collections;

public class PlayerCollision : MonoBehaviour 
{
	[SerializeField] private float impactTolerance = 5f;

	void OnCollisionEnter2D (Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Wall")
		    || collision.gameObject.CompareTag("Barrier"))
		{
			if (collision.relativeVelocity.magnitude > this.impactTolerance)
			{
				AudioManager.Instance.PlayTooFastCollisionClip();
				PlayerData.Instance.Health = 0;
			}
			else
			{
				AudioManager.Instance.PlayCollisionClip();
				PlayerData.Instance.Health--;
			}
		}
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "Coin")
		{
			PlayerData.Instance.Score++;
			AudioManager.Instance.PlayCoinCollectClip();
			Destroy(other.gameObject);
		}
	}
}
