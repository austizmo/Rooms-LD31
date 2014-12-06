using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public int health 	= 10;
	public int xp 		= 0;

	public float moveSpeed = 1;
	public float jumpSpeed = 10;

	public GameObject attackSprite;

	void Start() {
		Instantiate (attackSprite);
		attackSprite.transform.parent = gameObject.transform;
		attackSprite.transform.Translate (0.1f, 0, 0);
		attackSprite.SetActive (false);
	}

	void Update() {
		if (health <= 0) {
			Destroy(this.gameObject);
		}
	}

	void OnCollisionEnter(Collision collision) {
		Debug.Log (collision);
		if (collision.gameObject.GetComponent<Enemy> () != null) {
			health -= 1;
		}
	}

	void FixedUpdate() {
		float move = Input.GetAxis ("Horizontal");
		rigidbody.velocity = new Vector2 (move * moveSpeed, rigidbody.velocity.y);
		
		bool jump = Input.GetButtonDown ("Fire1");
		
		if(jump) 
			rigidbody.velocity = new Vector2 (rigidbody.velocity.x, jumpSpeed);
		
		bool attack = Input.GetButtonDown ("Fire2");
		
		if (attack) 
		{
			Attack ();
		}
	}

	void Attack() {
		Debug.Log ("attacking");
		attackSprite.SetActive (true);
	}
}
