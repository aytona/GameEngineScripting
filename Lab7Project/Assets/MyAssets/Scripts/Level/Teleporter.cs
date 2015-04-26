using UnityEngine;
using System.Collections;

public class Teleporter : MonoBehaviour 
{
	[SerializeField] private Transform destination = null;
	[SerializeField] private GameObject player = null;
	//[SerializeField] private Transform teleporter = null;
	private int delay = 1;

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "Player")
		{
			StartCoroutine(delayCoroutine());
			player.rigidbody2D.isKinematic = true;
			particleSystem.enableEmission = true;
			AudioManager.Instance.PlayTeleportClip();
		}
	}

	private IEnumerator delayCoroutine() {
		yield return new WaitForSeconds(delay);
		teleport();
	}

	private void teleport() {
		player.transform.position = destination.position;
		player.rigidbody2D.isKinematic = false;
		particleSystem.enableEmission = false;
	}
}
