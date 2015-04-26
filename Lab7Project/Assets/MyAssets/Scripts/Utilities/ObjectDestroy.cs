using UnityEngine;
using System.Collections;

public class ObjectDestroy : MonoBehaviour 
{
	public float lifeSpan = 3f;

	void Start() {
		StartCoroutine (DelayCoroutine ());
	}

	private IEnumerator DelayCoroutine() {
		yield return new WaitForSeconds (this.lifeSpan);
		DestroyMe();
	}

	private void DestroyMe ()
	{
		Destroy(this.gameObject);
		Application.LoadLevel("MainMenu");
	}
}
