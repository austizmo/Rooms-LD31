using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{
	public float moveSpeed = 1;
	public float jumpSpeed = 10;

	void FixedUpdate() {
		float move = Input.GetAxis ("Horizontal");
		rigidbody.velocity = new Vector2 (move * moveSpeed, rigidbody.velocity.y);

		bool jump = Input.GetButtonDown ("Fire1");

		if(jump) 
			rigidbody.velocity = new Vector2 (rigidbody.velocity.x, jumpSpeed);
	}
}
