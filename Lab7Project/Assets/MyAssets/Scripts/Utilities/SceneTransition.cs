using UnityEngine;
using System.Collections;

public class SceneTransition : MonoBehaviour 
{
	public void TransitionToLevel (string levelName)
	{
		Application.LoadLevel(levelName);
	}
}
