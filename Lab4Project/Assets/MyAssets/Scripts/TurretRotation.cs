using UnityEngine;
using System.Collections;

public class TurretRotation : MonoBehaviour {

	[SerializeField] private float speed = 0;
	// Update is called once per frame
	void Update () {
		this.transform.Rotate(new Vector3(0, 0, this.speed));
	}
}
