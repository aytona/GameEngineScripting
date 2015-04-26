using UnityEngine;
using System.Collections;

public class PlayerCollision : MonoBehaviour 
{
	void OnTriggerEnter2D (Collider2D other)
	{
		// Check if we collided with an object tagged "Wall".
		if (other.gameObject.tag == "Wall")
		{
			// We have collided with a wall. 
			// Destroy player.
			Destroy(this.gameObject);
		}
	}
}
