using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Rigidbody2D))]
public class PlayerCollision : MonoBehaviour 
{
	public GameObject explosionPrefab = null;

	[SerializeField] private float impactTolerance = 5f;

	void OnCollisionEnter2D (Collision2D other)
	{
		if (other.gameObject.tag == "Wall" && other.relativeVelocity.magnitude > this.impactTolerance)
		{
			AudioManager.Instance.PlayTooFastCollisionClip();
			DestroyMe();
		}
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "Wall" 
		    || other.tag == "Obstacle")
		{
			AudioManager.Instance.PlayCollisionClip();
			DestroyMe();
		}

		if (other.tag == "Barrier")
		{
			Destroy (other.gameObject);
			DestroyMe();
		}

		if (other.tag == "Coin")
		{
			PlayerData.Instance.Score++;
			AudioManager.Instance.PlayCoinCollectClip();
			Destroy (other.gameObject);
		}
	}

	private void DestroyMe ()
	{
		AudioManager.Instance.PlayExplosionClip();
		Destroy (this.gameObject);
		GameObject explosionObject = Instantiate(this.explosionPrefab) as GameObject;
		explosionObject.transform.position = this.transform.position;
	}
}
