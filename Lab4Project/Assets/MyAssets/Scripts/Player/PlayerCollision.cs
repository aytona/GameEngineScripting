using UnityEngine;
using System.Collections;

public class PlayerCollision : MonoBehaviour 
{
	[SerializeField] private GameObject explosion = null;

	void OnTriggerEnter2D (Collider2D other)
	{
		// Instantiate the explosion prefab and store it in the explostionObject local variable.
		GameObject explosionObject = Object.Instantiate(this.explosion) as GameObject;
		
		// Set the global position of the explosion to the global position of the player.
		explosionObject.transform.position = this.gameObject.transform.position;

		if (other.tag == "Wall"){
			Destroy(this.gameObject);
		}
	}
}
