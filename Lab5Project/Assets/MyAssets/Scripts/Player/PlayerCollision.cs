using UnityEngine;
using System.Collections;

public class PlayerCollision : MonoBehaviour 
{
	public GameObject explosionPrefab = null;

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "Wall" 
		    || other.tag == "Obstacle")
		{
			DestroyMe();
		}

		if (other.tag == "Barrier")
		{
			Destroy (other.gameObject);
			DestroyMe();
		}
	}

	private void DestroyMe ()
	{
		Destroy (this.gameObject);
		GameObject explosionObject = Instantiate(this.explosionPrefab) as GameObject;
		explosionObject.transform.position = this.transform.position;
	}
}
