using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour 
{
	[SerializeField] private string levelToLoad = null;

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "Player")
		{
			Application.LoadLevel(this.levelToLoad);
		}
	}
}
