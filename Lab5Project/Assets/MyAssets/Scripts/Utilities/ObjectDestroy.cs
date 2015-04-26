using UnityEngine;
using System.Collections;

public class ObjectDestroy : MonoBehaviour 
{
	private void DestroyMe ()
	{
		Destroy(this.gameObject);
		Application.LoadLevel("MainMenu");
	}
}
