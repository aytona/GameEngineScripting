using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour 
{
	[SerializeField] private float force = 10;
	[SerializeField] private Vector2 direction;
	[SerializeField] private GameObject flame = null;

	void Update ()
	{
		// Determine in which direction the player is moving.
		this.direction = DetectKeyboardInput();

		// Move the player, based on input direction.
		Move (this.direction);

		// Rotate the player, based on input direction.
		Rotate(this.direction);
	}

	private Vector2 DetectKeyboardInput ()
	{
		// Set our direction vector to zero.
		// Here we use Vector2.zero, which is equivalent to (0, 0).
		Vector2 movementDirection = Vector2.zero;

		// Check which arrow key is pressed.
		// If all four arrow keys are pressed, the resulting vector will be (0, 0). 
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
			movementDirection += Vector2.up;
		} 

		if (Input.GetKey(KeyCode.DownArrow))
		{
			// Add direction vector (0, -1) to movement direction.
			movementDirection -= Vector2.up;
		}

		if (Input.GetKey(KeyCode.LeftArrow))
		{
			// Add direction vector (-1, 0) to movement direction.
			movementDirection -= Vector2.right;
		}

		if (Input.GetKey(KeyCode.RightArrow))
		{
			// Add direction vector (1, 0) to movement direction.
			movementDirection += Vector2.right;
		}

		// Return the resulting movement direction, based on the keyboard input.
		return movementDirection;
	}

	/// <summary>
	/// Move this object towards the specified movement direction.
	/// </summary>
	/// <param name="movementDirection">Movement direction.</param>
	private void Move (Vector2 movementDirection)
	{
		// Only check the positive, vertical input. Ignore all other movement directions.
		if (movementDirection.y > 0)
		{
			// TODO
			// this.rigidbody2D.AddForce(Vector2.up * this.force);

			// We want to move the player forward.
			// The forward direction is always "up" relative to the rocket, but is not up
			// relative to the world itself (global orientation).

			// We need to determine the player's forward direction in global space.
			// Since hte ship initially points up, the forward direction is the player's local
			// y axis, or Vector2.up.

			Vector2 globalForwardDierction = this.transform.TransformDirection(Vector2.up);

			// Now we apply a force to the player object.
			// - The direction of the force is equal to the plaer's global forward direction.
			// - The amount of force applied is equal to the 
			this.GetComponent<Rigidbody2D>().AddForce(globalForwardDierction * this.force);

			// Show flame.
			flame.SetActive(true);
		}
		else
		{
			// TODO
			// Hide flame.
			flame.SetActive(false);
		}
	}

	/// <summary>
	/// Rotate the player by applying torque. 
	/// Torque follows the left hand rule: positive torque rotates counter-clockwise.
	/// </summary>
	/// <param name="angle">Angle.</param>
	private void Rotate (Vector2 movementDirection)
	{
		if (movementDirection.x > 0)
		{
			// TODO
			this.GetComponent<Rigidbody2D>().AddTorque(-this.force);

			// Movement direction is to the right.
			// Apply torque (rotation force) in the clockwise direction.
		}
		else if (movementDirection.x < 0)
		{
			// Movement direction is to the left. 
			// Apply torque (rotatation force) in the counter-clockwise direction.
			this.GetComponent<Rigidbody2D>().AddTorque(this.force);
		}
	}

}
