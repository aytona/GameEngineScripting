using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	public float speed = 0.1f;

	void Start(){
		StartCoroutine(DestroyAfterDelay(3));
	}
	// Update is called once per frame
	void Update () {
		this.transform.Translate(new Vector3(0,0, this.speed));
	}

	private IEnumerator DestroyAfterDelay(float delay){
		yield return new WaitForSeconds(delay);
		GameObject.Destroy(this.gameObject);
	}
}
