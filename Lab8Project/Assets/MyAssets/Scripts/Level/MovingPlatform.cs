using UnityEngine;
using System.Collections;

public class MovingPlatform : MonoBehaviour 
{
	[SerializeField] private Vector2 movementDirection = Vector2.zero;
	[SerializeField] private float speed = 1;

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other && other.tag != "Player")
		{
			speed *= -1;
		}
	}

	void FixedUpdate ()
	{
		// Get the normalized direction. A normalized vector has magnitude 1.
		// Since we are multiplying the movement direction with the speed, we want to ensure that the movement direction
		// vector is exactly length 1; otherwise, multiplying a non-normalized movement direction with the speed value
		// will produce a false translation vector this tick.
		Vector3 normalizedDirection = (Vector3)this.movementDirection.normalized;
		this.transform.Translate(normalizedDirection * this.speed * Time.deltaTime);
	}
}
