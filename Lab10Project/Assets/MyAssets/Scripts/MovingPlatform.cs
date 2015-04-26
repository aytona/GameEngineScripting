using UnityEngine;
using System.Collections;


public class MovingPlatform : MonoBehaviour
{
	[SerializeField] private Transform start = null;
	[SerializeField] private Transform end = null;
	[SerializeField] private Vector3 direction = Vector3.zero;
	[SerializeField] private float speed = 10;
	[SerializeField] private float directionSwitchDelay = 4;

	void Awake ()
	{
		if (this.start != null 
		    && this.end != null)
		{
			this.direction = (this.end.localPosition - this.start.localPosition);
		}
	}

	void Start ()
	{
		this.direction.Normalize();
		this.speed = Mathf.Abs (this.speed);
	}

	void FixedUpdate ()
	{
		this.gameObject.transform.Translate (this.direction * this.speed * Time.fixedDeltaTime);
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.tag == "Landing")
		{
			StartCoroutine(WaitBeforeSwitchingDirection(this.directionSwitchDelay));
		}
	}

	private IEnumerator WaitBeforeSwitchingDirection (float delay)
	{
		float oldSpeed = this.speed;
		this.speed = 0;

		yield return new WaitForSeconds (delay);
		
		this.speed = oldSpeed;
		this.direction = -direction;
	}

}
