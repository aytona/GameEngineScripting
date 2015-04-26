using UnityEngine;
using System.Collections;

public class HoverField : MonoBehaviour 
{
	[SerializeField] private float force = 25;

	void OnTriggerStay (Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			other.rigidbody.AddForce(Vector3.up * force, ForceMode.Acceleration);
		}
	}
}
