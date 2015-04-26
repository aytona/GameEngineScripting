using UnityEngine;
using System.Collections;

public class Turret : MonoBehaviour {

	/// <summary>
	/// The body rotation.
	/// </summary>
	public Rotation bodyRotation = null;

	/// <summary>
	/// The gun rotation.
	/// </summary>
	public Rotation gunRotation = null;

	/// <summary>
	/// The turret rotattion.
	/// </summary>
	public Rotation turretRotation = null;
	
	/// <summary>
	/// The rotation speed.
	/// </summary>
	public float rotationSpeed = 1;

	/// <summary>
	/// The projectile.
	/// </summary>
	public Projectile projectile = null;

	public Projectile spawner;

	void Awake(){
		this.turretRotation = this.gameObject.GetComponent<Rotation>();
	}

	void Update(){
		// Checks input each frame.
		CheckInput ();
	}

	private void CheckInput(){
		// Check input for body rotation.
		RotateBodyInput ();
		// Check input for gun rotation.
		RotateGunInput();
		// Check input for forward and backward movmeent.
		Move();
		// Rotate turret.
		RotateTurret();
		// Projectile fire.
		//FireInput();
	}

	private void RotateBodyInput(){
		// Check Input
		if(Input.GetKey (KeyCode.LeftArrow)) {
			// Rotate body clockwise
			this.bodyRotation.Rotate(-this.rotationSpeed);
		}
		if(Input.GetKey(KeyCode.RightArrow)) {
			// Rotate body counterclockwise
			this.bodyRotation.Rotate(this.rotationSpeed);
		}
	}

	private void RotateGunInput(){
		if(Input.GetKey (KeyCode.UpArrow)) {
			// Rotate gun upwards.
			this.gunRotation.Rotate (-this.rotationSpeed);
		}
		if(Input.GetKey(KeyCode.DownArrow)) {
			// Rotate gun downwards.
			this.gunRotation.Rotate (this.rotationSpeed);
		}
	}

	private void Move(){
		if(Input.GetKey(KeyCode.W)) {
			// Move forward.
			this.transform.Translate (Vector3.forward);
		}
		if(Input.GetKey(KeyCode.S)) {
			// Move backwards.
			this.transform.Translate (Vector3.back);
		}
	}

	private void RotateTurret() {
		if(Input.GetKey (KeyCode.D)) {
			// Rotate gun upwards.
			this.turretRotation.Rotate (this.rotationSpeed);
		}
		if(Input.GetKey(KeyCode.A)) {
			// Rotate gun downwards.
			this.turretRotation.Rotate (-this.rotationSpeed);
		}
	}

	//private void FireInput(){
	//	if(Input.GetKeyDown (KeyCode.Space)){
	//		GameObject projectile = Instantiate(this.projectile) as GameObject;
	//		projectile.transform.position = this.spawner.position;
	//		projectile.transform.eulerAngles = this.spawner.eulerAngles;
	//	}
	//}
}