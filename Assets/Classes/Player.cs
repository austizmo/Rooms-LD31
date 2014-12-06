using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public int health 	= 10;
	public int xp 		= 0;

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
}
