using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public int health 	= 10;
	public int xp 		= 0;

	public float moveSpeed = 1;
	public float jumpSpeed = 10;

	private Weapon attackSprite;
	private float lastAttackTime;
	public float attackDuration = 0.1f;

	void Start() {
		attackSprite = gameObject.GetComponentInChildren<Weapon>();
		attackSprite.gameObject.SetActive (false);
	}

	void Update() {
		if (health <= 0) {
			Destroy(this.gameObject);
		}
		if (Time.time > lastAttackTime + attackDuration) {
			attackSprite.gameObject.SetActive(false);
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
		Debug.Log ("attacking");
		attackSprite.gameObject.SetActive (true);
		lastAttackTime = Time.time;
	}
}
