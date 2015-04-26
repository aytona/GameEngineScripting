using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {
	
	/// <summary>
	/// The projectile prefab.
	/// </summary>
	[SerializeField] private GameObject projectilePrefab = null;

	[SerializeField] private Transform projectileSpawn = null;

	void Awake() {

		InvokeRepeating("Spawn", 3, 3);
	}

	/*void Spawn(){
		GameObject projectile = Instantiate(this.projectilePrefab) as GameObject;
		projectile.transform.eulerAngles = this.projectileSpawn.eulerAngles;
		projectile.transform.position = this.projectileSpawn.position;
	}*/

	void Spawn() {
		GameObject projectile = Instantiate(this.projectilePrefab) as GameObject;
		projectile.transform.eulerAngles = this.projectileSpawn.eulerAngles;
		projectile.transform.position = this.projectileSpawn.position;
	}


}
