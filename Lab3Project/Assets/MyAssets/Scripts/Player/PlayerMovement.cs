using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour 
{
	[SerializeField] private float speed = 1;
	[SerializeField] private Vector3 direction;

	public float SpeedPerFrame
	{
		get { return this.speed * Time.deltaTime; }
	}


	#region MonoBehaviour

	void Update ()
	{
		// Determine in which direction the player is moving.
		this.direction = DetectKeyboardInput();

		// Move the player in that direction.
		Move (this.direction);
	}

	#endregion MonoBehaviour


	private Vector3 DetectKeyboardInput ()
	{
		// Set our direction vector to zero.
		// Here we use Vector3.zero, which is equivalent to (0, 0, 0).
		Vector3 movementDirection = Vector3.zero;

		// Check which arrow key is pressed. We can ignore the z axis.
		// If all four arrow keys are pressed, the resulting vector will be (0, 0) (in Vector3 it is (0, 0, 0)). 
		// This is because all four direction vectors added together cancel each other out.
		// For example: 
		// Pressing left and right keys results in (1, 0) + (-1, 0) = (0, 0)
		// Pressing up and down keys results in (0, 1) + (0, -1) = (0, 0)
		// Pressing all four direction keys results in (1, 0) + (-1, 0) + (0, 1) + (0, -1) = (0, 0)
		// This also means that pressing right and up key at the same time results in diagonal motion: 
		// (1, 0) + (0, 1) = (1, 1)
		if (Input.GetKey(KeyCode.UpArrow))
		{
			// Add direction vector (0, 1) to movement direction.
			movementDirection += Vector3.up;
		} 

		if (Input.GetKey(KeyCode.DownArrow))
		{
			// Add direction vector (0, -1) to movement direction.
			movementDirection += Vector3.down;
		}

		if (Input.GetKey(KeyCode.LeftArrow))
		{
			// Add direction vector (-1, 0) to movement direction.
			movementDirection += Vector3.left;
		}

		if (Input.GetKey(KeyCode.RightArrow))
		{
			// Add direction vector (1, 0) to movement direction.
			movementDirection += Vector3.right;
		}

		// Return the resulting movement direction, based on the keyboard input.
		return movementDirection;
	}

	/// <summary>
	/// Move this object towards the specified movement direction.
	/// </summary>
	/// <param name="movementDirection">Movement direction.</param>
	private void Move (Vector3 movementDirection)
	{
		// Move my game object in the specified direction.
		// The amount by which this object moves this frame is added to the object's current position using Translate().
		// The amount of movement is provided by the SpeedPerFrame property.
		// The direction of movement is provided by the movementDirection parameter.
		// Since movementDirection is a Vector3, we need to typecast it to a Vector3, because Translate() requires
		// a Vector3 object type.
		this.gameObject.transform.Translate(movementDirection * this.SpeedPerFrame); 
	}

}
