using UnityEngine;
using System.Collections;

public class SceneLoader : MonoBehaviour 
{
	[SerializeField] private string levelName;

	void Awake ()
	{
		this.enabled = false;
	}

	void OnEnable ()
	{
		Application.LoadLevel(this.levelName);
	}
}
