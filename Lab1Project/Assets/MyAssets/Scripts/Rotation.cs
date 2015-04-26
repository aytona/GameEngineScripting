using UnityEngine;
using System.Collections;

public class Rotation : MonoBehaviour
{
	[SerializeField] private float speed = 0;

	void Update ()
	{
		this.transform.Rotate(new Vector3(0, this.speed, 0));
	}
}

