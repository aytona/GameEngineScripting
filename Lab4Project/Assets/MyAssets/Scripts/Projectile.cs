using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	public float speed = 1;
	public float lifeSpan = 5;

	// Update is called once per frame
	void Update () {
		this.transform.Translate(new Vector3(this.speed, 0, 0));
		StartCoroutine(DestroyAfterDelay());
	}

	IEnumerator DestroyAfterDelay() {
		yield return new WaitForSeconds(this.lifeSpan);
		GameObject.Destroy(this.gameObject);
	}

	void OnTriggerEnter2D (Collider2D other) {
		if(other.tag == "Wall") {
			Destroy(this.gameObject);
		}
	}
}
