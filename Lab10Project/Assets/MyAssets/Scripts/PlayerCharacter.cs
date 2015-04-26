using UnityEngine;
using System.Collections;

public class PlayerCharacter : MonoBehaviour 
{
	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.CompareTag("MovingPlatform"))
		{
			this.transform.parent = other.transform;
		}
	}
	
	void OnTriggerExit2D (Collider2D other)
	{
		if (other.CompareTag("MovingPlatform"))
		{
			this.transform.parent = null;
		}
	}
}
