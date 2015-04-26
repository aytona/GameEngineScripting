using UnityEngine;
using System.Collections;

public class Switch : MonoBehaviour 
{
	[SerializeField] private GameObject barrier = null;
	private int waitTime = 3;

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "Player")
		{
			AudioManager.Instance.PlaySwitchClip();
			barrier.particleSystem.enableEmission = true;
			StartCoroutine(delayCoroutine());
		}
	}

	private IEnumerator delayCoroutine() {
		yield return new WaitForSeconds(waitTime);
		DestroyObject();
	}

	private void DestroyObject() {
		GameObject.Destroy(barrier);
	}
}
