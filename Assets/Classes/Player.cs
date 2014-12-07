using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public int health 	= 10;
	public int xp 		= 0;

	public float moveSpeed = 1;
	public float jumpSpeed = 10;

	private Weapon weapon;

	private float lastAttackTime;


	void Start() {
		weapon = gameObject.GetComponentInChildren<Weapon>();
		weapon.gameObject.SetActive (false);
	}

	void Update() {
		if (health <= 0) {
			Destroy(this.gameObject);
		}
		if (Time.time > lastAttackTime + weapon.attackDuration) {
			weapon.gameObject.SetActive(false);
		}
	}

	void OnCollisionEnter(Collision collision) {
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
		
		if (attack) {
			Attack ();
		} 
	}

	void Attack() {
		weapon.gameObject.SetActive (true);
		lastAttackTime = Time.time;
	}
}
